using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace baralla_projecte
{
    public enum EnumPal
    {

        //Trebol (♠), Pica (♣), Cor (♥), Diamant (♦) 
        [Description("♣")] TREBOL,
        [Description("♠")] PICA,
        [Description("♥")] COR,
        [Description("♦")] DIAMANT
    }
}