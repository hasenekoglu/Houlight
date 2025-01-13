using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Houlight.Domain.Enums;

    public enum LoadType
    {
        GeneralCargo = 1,           // Genel kargo
        PerishableGoods = 2,        // Bozulabilir ürünler
        HazardousMaterials = 3,     // Tehlikeli maddeler
        FragileItems = 4,           // Kırılabilir eşyalar
        BulkCargo = 5,              // Dökme kargo
        Liquid = 6,                 // Sıvı kargo
        HighValue = 7,              // Yüksek değerli ürünler
        TemperatureSensitive = 8,   // Sıcaklık hassas ürünler
        DangerousGoods = 9         // Tehlikeli mallar
    }

