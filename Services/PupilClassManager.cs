using SchoolManager.Models;
using SchoolManager.Models.Diff;

namespace SchoolManager.Services;

/**
 * This class manages the division of pupils into classes.
 *
 * It's your job to implement the UpdatePupilClassDivision method and the Diff method.
 */
public static class PupilClassManager
{
    /// <summary>
    /// Updates the division of pupils into classes based on the provided assignments.
    /// </summary>
    /// <param name="state">The current state of pupils and classes.</param>
    /// <param name="request">The request containing new pupil-class assignments.</param>
    /// <returns>A new State reflecting the updated assignments.</returns>
    /// <exception cref="Exception">
    /// Thrown if:
    /// - An assignment references a non-existing class or pupil.
    /// - A pupil is assigned to multiple classes.
    /// - Any pupil is not assigned to a class after processing.
    /// - Any class exceeds its maximum allowed number of pupils.
    /// </exception>
    public static State UpdatePupilClassDivision(State state, Request request)
    {
        // Validate: all class IDs in assignments must exist
        var classIds = state.Classes.Select(c => c.Id).ToHashSet();
        foreach (var assignment in request.Assignments)
        {
            if (!classIds.Contains(assignment.ClassId))
            {
                throw new Exception($"Class with id {assignment.ClassId} does not exist.");
            }
        }

        // Validate: all pupil IDs in assignments must exist
        var pupilIds = state.Pupils.Select(p => p.Id).ToHashSet();
        foreach (var assignment in request.Assignments)
        {
            if (!pupilIds.Contains(assignment.PupilId))
            {
                throw new Exception($"Pupil with id {assignment.PupilId} does not exist.");
            }
        }

        // Validate: no duplicate pupil IDs in assignments (each pupil can only be assigned to one class)
        var duplicatePupilId = request.Assignments
            .GroupBy(a => a.PupilId)
            .Where(g => g.Count() > 1)
            .Select(g => g.Key)
            .FirstOrDefault();
        if (duplicatePupilId != 0)
        {
            throw new Exception("Duplicate pupil IDs provided.");
        }

        // Clone the state to avoid mutating the original
        var newState = new State
        {
            Pupils = state.Pupils.Select(p => new Models.Db.Pupil
            {
                Id = p.Id,
                Name = p.Name,
                ClassName = p.ClassName,
                FollowUpNumber = p.FollowUpNumber
            }).ToList(),
            Classes = state.Classes.Select(c => new Models.Db.Class
            {
                Id = c.Id,
                ClassName = c.ClassName,
                TeacherName = c.TeacherName,
                MaxAmountOfPupils = c.MaxAmountOfPupils,
                AmountOfPupils = 0
            }).ToList()
        };

        // Map assignments by pupil for quick lookup
        var assignmentsByPupil = request.Assignments.ToDictionary(a => a.PupilId, a => a.ClassId);

        // Update pupils' class if present in assignments
        foreach (var pupil in newState.Pupils)
        {
            if (assignmentsByPupil.TryGetValue(pupil.Id, out int newClassId))
            {
                // Assign the pupil to the new class
                var classObj = newState.Classes.FirstOrDefault(c => c.Id == newClassId);
                if (classObj != null)
                {
                    pupil.ClassName = classObj.ClassName;
                }
            }
        }

        // For each class, update AmountOfPupils and assign FollowUpNumber based on alphabetical order
        foreach (var classObj in newState.Classes)
        {
            var pupilsInClass = newState.Pupils
                .Where(p => p.ClassName == classObj.ClassName)
                .OrderBy(p => p.Name)
                .ToList();
            for (int i = 0; i < pupilsInClass.Count; i++)
            {
                // FollowUpNumber is 1-based index in alphabetical order
                pupilsInClass[i].FollowUpNumber = i + 1;
            }
            classObj.AmountOfPupils = pupilsInClass.Count;
        }

        // After assignments, ensure every pupil is assigned to a class
        foreach (var pupil in newState.Pupils)
        {
            if (string.IsNullOrEmpty(pupil.ClassName))
            {
                throw new Exception($"Pupil with id {pupil.Id} is not assigned to a class.");
            }
        }

        // After assignments, ensure no class exceeds MaxAmountOfPupils
        foreach (var classObj in newState.Classes)
        {
            if (classObj.AmountOfPupils > classObj.MaxAmountOfPupils)
            {
                throw new Exception($"Class {classObj.ClassName} has too many pupils assigned.");
            }
        }

        return newState;
    }

    /// <summary>
    /// Calculates the difference between the old and new state, returning the pupils and classes that have changed.
    /// </summary>
    /// <param name="oldState">The previous state.</param>
    /// <param name="newState">The updated state.</param>
    /// <returns>A tuple containing a list of updated pupils and a list of updated classes.</returns>
    public static (List<UpdatedPupil>, List<UpdatedClass>) Diff(State oldState, State newState)
    {
        var updatedPupils = new List<UpdatedPupil>();
        var updatedClasses = new List<UpdatedClass>();

        // Compare pupils: add to diff if ClassName or FollowUpNumber changed
        foreach (var newPupil in newState.Pupils)
        {
            var oldPupil = oldState.Pupils.FirstOrDefault(p => p.Id == newPupil.Id);
            if (oldPupil == null || oldPupil.ClassName != newPupil.ClassName || oldPupil.FollowUpNumber != newPupil.FollowUpNumber)
            {
                updatedPupils.Add(new UpdatedPupil
                {
                    PupilId = newPupil.Id,
                    ClassName = newPupil.ClassName,
                    FollowUpNumber = newPupil.FollowUpNumber
                });
            }
        }

        // Compare classes: add to diff if AmountOfPupils changed
        foreach (var newClass in newState.Classes)
        {
            var oldClass = oldState.Classes.FirstOrDefault(c => c.Id == newClass.Id);
            if (oldClass == null || oldClass.AmountOfPupils != newClass.AmountOfPupils)
            {
                updatedClasses.Add(new UpdatedClass
                {
                    ClassId = newClass.Id,
                    AmountOfPupils = newClass.AmountOfPupils
                });
            }
        }

        return (updatedPupils, updatedClasses);
    }
}
