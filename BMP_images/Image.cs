using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMP_images
{
    public class Image
    {
        //Header header;
        List<byte> headerInfo;
        public Pixel[][] pixels;
        int BMPImageSize;
        int width;
        int height;


        public Image(string path)
        {
            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                //bfType            2   Персонажи «БМ»
                //bfSize            4   Размер файла в байтах                       <------------
                //bfReserved1       2   Не используется -должно быть равно нулю
                //bfReserved2       2   Не используется -должно быть равно нулю
                //bfOffBits         4   Смещение к началу пиксельных данных

                //biSize            4   Размер заголовка -должен быть не менее 40
                //biWidth           4   Ширина изображения в пикселях               <------------
                //biHeight          4   Высота изображения в пикселях               <------------
                //biPlanes          2   Должно быть 1
                //biBitCount        2   Бит на пиксель - 1, 4, 8, 16, 24 или 32
                //biCompression     4   Тип сжатия(0 = без сжатия)
                //biSizeImage       4   Размер изображения -может быть нулевым для несжатых изображений.
                //biXPelsPerMeter   4   Предпочтительное разрешение в пикселях на метр
                //biYPelsPerMeter   4   Предпочтительное разрешение в пикселях на метр
                //biClrUsed         4   Фактически используемые записи Number Color Map
                //biClrImportant    4   Количество значащих цветов

                headerInfo = new List<byte>();
                reader.ReadBytes(2);

                BMPImageSize = reader.ReadInt32();

                headerInfo.AddRange(reader.ReadBytes(12));

                width = reader.ReadInt32();
                height = reader.ReadInt32();

                headerInfo.AddRange(reader.ReadBytes(28));

                //header = new Header();
                //header.type = Convert.ToUInt16(reader.ReadUInt16());
                //header.size = Convert.ToUInt32(reader.ReadUInt32());
                //header.reserved1 = Convert.ToUInt16(reader.ReadUInt16());
                //header.reserved2 = Convert.ToUInt16(reader.ReadUInt16());
                //header.infosize = Convert.ToUInt32(reader.ReadUInt32());
                //header.width = Convert.ToUInt32(reader.ReadUInt32());
                //header.height = Convert.ToUInt32(reader.ReadUInt32());
                //header.biPlanes = Convert.ToUInt16(reader.ReadUInt16());
                //header.bits = Convert.ToUInt16(reader.ReadUInt16());
                //header.biCompression = Convert.ToUInt32(reader.ReadUInt32());
                //header.biSizeImage = Convert.ToUInt32(reader.ReadUInt32());
                //header.biXPelsPerMeter = Convert.ToUInt32(reader.ReadUInt32());
                //header.biYPelsPerMeter = Convert.ToUInt32(reader.ReadUInt32());
                //header.biClrUsed = Convert.ToUInt32(reader.ReadUInt32());
                //header.biClrImportant = Convert.ToUInt32(reader.ReadUInt32());

                int countOfIgnoreBits = 3 - (Convert.ToInt32(width) * 3 - 1) % 4;

                pixels = new Pixel[height][];

                for (int i = 0; i < height; i++)
                {
                    pixels[i] = new Pixel[width];
                    for (int j = 0; j < width; j++)
                    {
                        byte r = reader.ReadByte();
                        byte g = reader.ReadByte();
                        byte b = reader.ReadByte();
                        pixels[i][j] = new Pixel(r,g,b);
                    }
                    reader.ReadBytes(countOfIgnoreBits);
                }
            }
        }

        public void Converts(string newPath, int count)
        {
            width *= count;
            height *= count;
            int padding = (4 - ((width * 3) % 4)) % 4;
            BMPImageSize = 54 + height * width * 3 + padding * height;

            using (BinaryWriter writer = new BinaryWriter(File.Open(newPath, FileMode.Create)))
            {
                //writer.Write(header.type);
                //writer.Write(header.size);
                //writer.Write(header.reserved1);
                //writer.Write(header.reserved2);
                //writer.Write(header.headersize);
                //writer.Write(header.infosize);
                //writer.Write(header.width);
                //writer.Write(header.height);
                //writer.Write(header.biPlanes);
                //writer.Write(header.bits);
                //writer.Write(header.biCompression);
                //writer.Write(header.biSizeImage);
                //writer.Write(header.biXPelsPerMeter);
                //writer.Write(header.biYPelsPerMeter);
                //writer.Write(header.biClrUsed);
                //writer.Write(header.biClrImportant);
                writer.Write('B');
                writer.Write('M');
                writer.Write(BMPImageSize);
                for (int i = 0; i < 12; i++)
                {
                    writer.Write(headerInfo[i]);
                }
                writer.Write(width);
                writer.Write(height);
                for (int i = 12; i < headerInfo.Count; i++)
                {
                    writer.Write(headerInfo[i]);
                }

                int countOfIgnoreBits = 3 - (Convert.ToInt32(width) * 3 - 1) % 4;

                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        writer.Write(pixels[i/count][j/count].Red);
                        writer.Write(pixels[i/count][j/count].Green);
                        writer.Write(pixels[i/count][j/count].Blue);
                    }
                    for (int k = 0; k < countOfIgnoreBits; k++)
                    {
                        writer.Write(0x00);
                    }
                }
            }
        }
    }
}
