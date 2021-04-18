using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMP_images
{
    class Program
    {
        static void Main(string[] args)
        {
            Image image = new Image("input.bmp");
            image.Converts("output.bmp", 8);

            Console.WriteLine("Enlarging image " + 4 + " times... Done.");
            Console.WriteLine("Written result to " + "output.bmp");
            //Image image = new Image(args[0]);
            //image.Converts(args[1], Convert.ToInt32(args[2]));

            //Console.WriteLine("Enlarging image " + args[2] + " times... Done.");
            //Console.WriteLine("Written result to " + args[1]);
        }
    }
}
