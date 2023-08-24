namespace Web.Domain;


public class Client
{
    public required int Id { get; set; }

    public required Guid Guid { get; set; }

    public required string Name { get; set; }

    public required int UserId { get; set; }
}
