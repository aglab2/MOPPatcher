using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOPPatcher
{
    class ReplacePatch : Patch
    {
        Dictionary<byte[], byte[]> replacePatterns;
        int offsetExcludeStart, offsetExcludeEnd;

        int jumpLength;

        static bool EqualTillLength(byte[] a1, int a1from, byte[] a2, int a2from, int len)
        {
            for (int i = 0; i < len; i++)
            {
                if (a1[i + a1from] != a2[i + a2from])
                {
                    return false;
                }
            }

            return true;
        }

        public ReplacePatch(int jumpLength, int offsetExcludeStart, int offsetExcludeEnd)
        {
            this.replacePatterns = new Dictionary<byte[], byte[]>();
            this.jumpLength = jumpLength;
            this.offsetExcludeStart = offsetExcludeStart;
            this.offsetExcludeEnd = offsetExcludeEnd;
        }

        public void AddPattern(byte[] pattern, byte[] replace)
        {
            replacePatterns[pattern] = replace;
        }

        public override void Apply(ROM rom)
        {
            for (int offset = 0; offset < rom.Data.Length; offset += jumpLength)
            {
                if (offset >= offsetExcludeStart && offset <= offsetExcludeEnd)
                    continue;

                foreach (byte[] pattern in replacePatterns.Keys)
                {
                    if (EqualTillLength(pattern, 0, rom.Data, offset, pattern.Length))
                    {
                        byte[] replace = replacePatterns[pattern];
                        Array.Copy(replace, 0, rom.Data, offset, replace.Length);
                    }
                }
            }
        }
    }
}
