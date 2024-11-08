using Core.Persistance.Repositories;

namespace Ticketz.Domain.Entities;

public class Customer : Entity<int>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PassportNumber { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public int OrderId { get; set; }
    public int? UserId { get; set; }

    public virtual User User { get; set; }
    public virtual ICollection<Order> Orders { get; set; }

    public Customer()
    {
        Orders = new HashSet<Order>();
    }

    public Customer(int id, string firstName, string lastName, string passportNumber, string phoneNumber, string email) : this()
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        PassportNumber = passportNumber;
        PhoneNumber = phoneNumber;
        Email = email;
    }
}