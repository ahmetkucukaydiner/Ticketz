using Core.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticketz.Domain.Entities;

public class Airline : Entity<int>
{
    public string Name { get; set; }
    public string IATACode { get; set; }
    public Uri LogoURL { get; set; }

    public virtual ICollection<Order> Orders { get; set; }

    public Airline()
    {
        Orders = new HashSet<Order>();
    }

    public Airline(int id, string name, string iataCode, Uri logoURL) : this()
    {
        Name = name;
        IATACode = iataCode;
        Id = id;
        LogoURL = logoURL;
    }
}