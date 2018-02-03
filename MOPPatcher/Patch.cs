using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOPPatcher
{
    abstract class Patch
    {
        public abstract void Apply(ROM rom);
    }
}
