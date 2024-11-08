using Core.Persistance.Repositories;

namespace Ticketz.Domain.Entities;

public class User : Entity<int>
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public virtual ICollection<Customer> Customers { get; set; }

    public User()
    {
        Customers = new HashSet<Customer>();
    }

    public User(string name, string lastName, string email, string password)
    {
        Name = name;
        LastName = lastName;
        Email = email;
        Password = password;
    }
}