using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Houlight.Domain.Entities;

public class LogisticsCompanyEntity : BaseEntity
{
    public string CompanyName { get; set; }
    public string CompanyAddress { get; set; }
    public string CompanyPhoneNumber { get; set; }
    public string CompanyEmail { get; set; }

    public virtual ICollection<DriverEntity>? DriverEntities { get; set; } 
    public virtual ICollection<VehicleEntity>? VehicleEntities { get; set; }
}

