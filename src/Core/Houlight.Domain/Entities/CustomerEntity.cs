using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Houlight.Domain.Entities;

public class CustomerEntity : BaseEntity
{
   
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public int PhoneNumber { get; set; }


    public virtual ICollection<LoadEntity>? LoadEntities { get; set; } 

}

