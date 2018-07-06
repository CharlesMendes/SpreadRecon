using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace starkdev.spreadrecon.model.Enum
{
    [DefaultValue(Desenvolvimento)]
    public enum ConectorDataBaseEnum
    {
        [EnumMember]
        [Description("SpreadReconDB_DES")]
        Desenvolvimento = 0,

        [EnumMember]
        [Description("SpreadReconDB_HOM")]
        Homologacao = 1,

        [EnumMember]
        [Description("SpreadReconDB_PRD")]
        Producao = 2
    }
}
