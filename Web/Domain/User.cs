namespace Web.Domain;

public class User
{
    public required int Id { get; set; }

    public required Guid Guid { get; set; }

    public required string FirstName { get; set; }

    public required string LastName { get; set; }

    public required DateTime Created { get; set; }

    public virtual ICollection<Client>? Clients { get; } = new List<Client>();
}