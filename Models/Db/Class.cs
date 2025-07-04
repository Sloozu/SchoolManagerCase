namespace SchoolManager.Models.Db;

/**
 * This object reflects a class in the database of the Class Service.
 */
public class Class
{
    public int Id { get; set; }

    public string? ClassName { get; set; }

    public string? TeacherName { get; set; }

    public int MaxAmountOfPupils { get; set; }

    public int AmountOfPupils { get; set; }
}
