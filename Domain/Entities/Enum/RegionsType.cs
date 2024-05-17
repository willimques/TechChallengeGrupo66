using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Enum
{
    public enum RegionsType
    {
        [Description("Norte")]
        Norte = 1,
        [Description("Nordeste")]
        Nordeste = 2,
        [Description("Centro-Oeste")]
        CentroOeste = 3,
        [Description("Sudeste")]
        Sudeste = 4,
        [Description("Sul")]
        Sul = 5,
    }
}
