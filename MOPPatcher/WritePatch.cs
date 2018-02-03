using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOPPatcher
{
    class WritePatch : Patch
    {
        Dictionary<int, byte[]> regions;

        public WritePatch()
        {
            regions = new Dictionary<int, byte[]>();
        }

        public void AddRegion(int start, byte[] data)
        {
            regions[start] = data;
        }

        public override void Apply(ROM rom)
        {
            foreach (int start in regions.Keys)
            {
                byte[] region = regions[start];
                Array.Copy(region, 0, rom.Data, start, region.Length);
            }
        }
    }
}
