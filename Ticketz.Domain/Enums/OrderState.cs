using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticketz.Domain.Enums;

public enum OrderState
{    
    Sales = 1,
    Refund = 2,
    Reservastion = 3,
    Cancel = 4
}
