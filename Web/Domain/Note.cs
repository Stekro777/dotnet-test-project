namespace Web.Domain;

public class Note
{
    public required int Id { get; set; }

    public required Guid Guid { get; set; }

    public required string Title { get; set; }

    public string? Content { get; set; }
}

