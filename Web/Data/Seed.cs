using System;
using Web.Domain;

namespace Web.Data;

public class Seed
{
    public void SeedData(DataContext context)
    {

        var user = new User
        {
            Id = 1,
            Guid = Guid.NewGuid(),
            Created = DateTime.Now,
            FirstName = "Steffen",
            LastName = "Krogstad"
        };

        var user2 = new User
        {
            Id = 2,
            Guid = Guid.NewGuid(),
            Created = DateTime.Now,
            FirstName = "Nils",
            LastName = "Pettersen"
        };


        var vpff = new Client
        {
            Id = 1,
            Name = "VPFF",
            Guid = Guid.NewGuid(),
            UserId = 1
        };

        var folketeateret = new Client
        {
            Id = 2,
            Name = "Folketeateret",
            Guid = Guid.NewGuid(),
            UserId = 1
        };

        var drewHolding = new Client
        {
            Id = 3,
            Name = "Drew Holding",
            Guid = Guid.NewGuid(),
            UserId = 1
        };

        var listClients = new List<Client>
        {
            folketeateret,
            vpff,
            drewHolding
        };

        //Seeding Users
        context.Users.Add(user);
        context.Users.Add(user2);

        //Seeding Clients
        context.Clients.Add(vpff);
        context.Clients.Add(folketeateret);
        context.Clients.Add(drewHolding);

        context.SaveChanges();
    }
}

