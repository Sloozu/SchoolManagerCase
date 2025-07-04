namespace SchoolManager.Models.Diff;

/**
 * This object reflects an updated pupil, that will be sent to the downstream Pupil Service, in batch.
 */
public class UpdatedPupil
{
    public int PupilId { get; set; }

    public string? ClassName { get; set; }

    public int? FollowUpNumber { get; set; }
}
