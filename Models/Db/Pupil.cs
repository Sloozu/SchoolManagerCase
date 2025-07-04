namespace SchoolManager.Models.Db;

/**
 * This object reflects a pupil in the database of the Pupil Service.
 */
public class Pupil
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? ClassName { get; set; }

    public int? FollowUpNumber { get; set; }
}
