using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaBite.Domain.Model
{
    public enum Rating
    {
        Undefined = 0,
        Bad = 1,
        Ok = 2,
        Good = 3,
        Delicious = 4,
        Best = 5,
    }

    public enum Operation
    {
        Undefined = 0,
        Create = 1,
        Update = 2,
    }

}
