namespace SchoolManager.Models;

/**
 * This object reflects an incoming update request from the frontend.
 */
public class Request
{
    public List<Assignment> Assignments { get; set; } = new();
}
