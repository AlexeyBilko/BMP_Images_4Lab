using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMP_images
{
    public class Header
    {
        public UInt16 type { get; set; }
        public UInt32 size { get; set; }
        public UInt16 reserved1 { get; set; }
        public UInt16 reserved2 { get; set; }
        public UInt32 headersize { get; set; }
        public UInt32 infosize { get; set; }
        public UInt32 width { get; set; }
        public UInt32 height { get; set; }
        public UInt16 biPlanes { get; set; }
        public UInt16 bits { get; set; }
        public UInt32 biCompression { get; set; }
        public UInt32 biSizeImage { get; set; }
        public UInt32 biXPelsPerMeter { get; set; }
        public UInt32 biYPelsPerMeter { get; set; }
        public UInt32 biClrUsed { get; set; }
        public UInt32 biClrImportant { get; set; }
        //2*5=10
        //4*11=44
        //10+44=54
        public void ChangeSize(int k)
        {
            width *= (uint)k;
            height *= (uint)k;
            uint padding = (4 - ((width * 3) % 4)) % 4;
            size = 54 + height * width * 3 + padding * height;
        }
    }

}
