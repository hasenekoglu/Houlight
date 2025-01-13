using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Houlight.Domain.Entities;

public class VehicleEntity : BaseEntity<Guid>
{
    public string PlateNumber { get; set; }
    public int Capacity { get; set; }
    public bool IsAvailable { get; set; } = false;

    public int CurrentWeight { get; set; } = 0;
    public int CurrentVolume { get; set; } = 0;

    public Guid LogisticsCompanyId { get; set; }
    public Guid AssignedDriverId { get; set; }

    public virtual LogisticsCompanyEntity LogisticsCompanyEntity { get; set; } = null!; 
    public virtual ICollection<VehicleType> VehicleTypes { get; set; } = new List<VehicleType>();
    public virtual DriverEntity? AssignedDriver { get; set; }
}

