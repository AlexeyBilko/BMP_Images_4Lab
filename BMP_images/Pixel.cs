using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMP_images
{
    public class Pixel
    {
        public uint Green { get; set; }
        public uint Blue { get; set; }
        public uint Red { get; set; }

        public Pixel()
        {
            Green = 0;
            Blue = 0;
            Red = 0;
        }

        public Pixel(int g, int b, int r)
        {
            Green = (uint)g;
            Blue = (uint)b;
            Red = (uint)r;
        }

        public void ChangeColors(int g, int b, int r)
        {
            Green += (uint)g;
            Blue += (uint)b;
            Red += (uint)r;
        }
    }
}
