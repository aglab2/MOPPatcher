using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOPPatcher
{
    class ROM
    {
        byte[] data;
        public readonly string name;

        public ROM(string name)
        {
            this.name = name;
            ReadData();
        }

        public void ReadData()
        {
            Data = File.ReadAllBytes(name);
        }

        public void WriteData()
        {
            File.WriteAllBytes(name, data);
        }

        public byte[] Data { get => data; set => data = value; }
    }
}
