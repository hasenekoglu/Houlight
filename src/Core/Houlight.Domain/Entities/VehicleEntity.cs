using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Houlight.Domain.Entities;

public class VehicleEntity : BaseEntity
{
    public string PlateNumber { get; set; }
    public int Capacity { get; set; }
    public bool IsAvailable { get; set; } = false;

    public int CurrentWeight { get; set; } = 0;
    public int CurrentVolume { get; set; } = 0;

    public Guid LogisticsCompanyId { get; set; }
    public Guid? AssignedDriverId { get; set; }
    public Guid VehicleTypeId { get; set; } 

    public virtual LogisticsCompanyEntity LogisticsCompanyEntity { get; set; } = null!; 
    public virtual VehicleTypeEntity VehicleTypeEntity { get; set; }
    public virtual DriverEntity? AssignedDriver { get; set; }

}

