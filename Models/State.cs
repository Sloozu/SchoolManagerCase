using SchoolManager.Models.Db;

namespace SchoolManager.Models;

/**
 * This object reflects the fetched state from the Pupil Service and the Class Service.
 */
public class State
{
    public List<Pupil> Pupils { get; set; } = new();

    public List<Class> Classes { get; set; } = new();
}
