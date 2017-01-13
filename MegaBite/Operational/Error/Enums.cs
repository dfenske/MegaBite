using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaBite.Operational.Error
{
    public enum ErrorReason : int
    {
        Unknown,
        Validation,
        Unhandled,
        WebAPI,
    }

}
