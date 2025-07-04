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
    public static State UpdatePupilClassDivision(State state, Request request)
    {
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

        // Map assignments by pupil
        var assignmentsByPupil = request.Assignments.ToDictionary(a => a.PupilId, a => a.ClassId);

        // Update pupils' class if present in assignments
        foreach (var pupil in newState.Pupils)
        {
            if (assignmentsByPupil.TryGetValue(pupil.Id, out int newClassId))
            {
                var classObj = newState.Classes.FirstOrDefault(c => c.Id == newClassId);
                if (classObj != null)
                {
                    pupil.ClassName = classObj.ClassName;
                }
            }
        }

        // For each class, update AmountOfPupils and FollowUpNumber for pupils in that class
        foreach (var classObj in newState.Classes)
        {
            var pupilsInClass = newState.Pupils
                .Where(p => p.ClassName == classObj.ClassName)
                .OrderBy(p => p.Name)
                .ToList();
            for (int i = 0; i < pupilsInClass.Count; i++)
            {
                pupilsInClass[i].FollowUpNumber = i + 1;
            }
            classObj.AmountOfPupils = pupilsInClass.Count;
        }

        return newState;
    }

    public static (List<UpdatedPupil>, List<UpdatedClass>) Diff(State oldState, State newState)
    {
        var updatedPupils = new List<UpdatedPupil>();
        var updatedClasses = new List<UpdatedClass>();

        // Compare pupils
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

        // Compare classes
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
