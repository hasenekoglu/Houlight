using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Houlight.Domain.Entities;


public class VehicleTypeEntity : BaseEntity
{
    public string Type { get; set; }
    public string Description { get; set; }

    public virtual ICollection<VehicleEntity> VehicleEntities { get; set; } 
}