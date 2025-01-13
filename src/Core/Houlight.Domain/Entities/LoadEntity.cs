using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Houlight.Domain.Enums;

namespace Houlight.Domain.Entities;

public class LoadEntity : BaseEntity<Guid>

{
    public string FromLocation { get; set; }
    public string ToLocation { get; set; }
    public LoadType LoadType { get; set; }
    public int Weight { get; set; }
    public int Volume { get; set; }
    public string? Description { get; set; }
    public DateTime? DeliveryDate { get; set; }
    public LoadStatus Status { get; set; } = LoadStatus.Pending;
    public decimal? CustomerExpectedPrice { get; set; }
    public decimal? CompanyOfferedPrice { get; set; }


    public Guid CustomerId { get; set; }
    public Guid? LogisticsCompanyId { get; set; }
    public Guid? AssignedVehicleId { get; set; }
    public Guid? AssignedDriverId { get; set; }


    public virtual CustomerEntity CustomerEntity { get; set; } = null!;
    public virtual LogisticsCompanyEntity? LogisticsCompanyEntity { get; set; }
    public virtual VehicleEntity? VehicleEntity { get; set; }
    public virtual DriverEntity? DriverEntity { get; set; }
}

