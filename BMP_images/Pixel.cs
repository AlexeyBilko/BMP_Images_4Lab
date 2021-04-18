using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMP_images
{
    public class Pixel
    {
        public byte Green { get; set; }
        public byte Blue { get; set; }
        public byte Red { get; set; }

        public Pixel()
        {
            Green = 0;
            Blue = 0;
            Red = 0;
        }

        public Pixel(int r, int g, int b)
        {
            Green = (byte)g;
            Blue = (byte)b;
            Red = (byte)r;
        }
    }
}
