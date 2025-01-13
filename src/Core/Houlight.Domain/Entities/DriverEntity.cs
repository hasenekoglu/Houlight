using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Houlight.Domain.Enums;

namespace Houlight.Domain.Entities;

public class DriverEntity : BaseEntity<Guid>
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string LicenseNumber { get; set; }
    public int PhoneNumber { get; set; }
    public string Email { get; set; }
    public DriverStatus DriverStatus { get; set; } = DriverStatus.OffDuty;

    public Guid LogisticsCompanyId { get; set; }

    public virtual LogisticsCompanyEntity LogisticsCompanyEntity { get; set; } = null!;
}

