namespace SchoolManager.Models.Diff;

/**
 * This object reflects an updated class, that will be sent to the downstream Class Service, in batch.
 */
public class UpdatedClass
{
    public int ClassId { get; set; }

    public int AmountOfPupils { get; set; }
}
