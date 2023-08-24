namespace Web.Domain;

public class Project
{
    public required int Id { get; set; }

    public required Guid Guid { get; set; }

    public required string Name { get; set; }

    public required DateTime Created { get; set; }

    public required int ClientId { get; set; }

    public required Client Client { get; set; }

    public ICollection<Note>? Notes { get; set; }
}