using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Advanced;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.PixelFormats;

namespace NoChainSwap.Domain.Impl.Core
{
    public static class Utils
    {
        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }
        public static void Copy<TParent, TChild>(TParent parent, TChild child)
        {
            var parentProperties = parent.GetType().GetProperties();
            var childProperties = child.GetType().GetProperties();

            foreach (var parentProperty in parentProperties)
            {
                foreach (var childProperty in childProperties)
                {
                    if (parentProperty.Name == childProperty.Name && parentProperty.PropertyType == childProperty.PropertyType)
                    {
                        try
                        {
                            childProperty.SetValue(child, parentProperty.GetValue(parent));
                        }
                        catch (Exception) { break; }
                        break;
                    }
                }
            }
        }

        /*
        public static void ChangeImageColor(Image<Rgba32> image, System.Drawing.Color newColor)
        {
            for (int y = 0; y < image.Height; y++)
            {
                Span<Rgba32> row = image.GetPixelRowSpan(y);
                for (int x = 0; x < row.Length; x++)
                {
                    if (image.GetPixelRowSpan(y)[x].A > 0)
                    {
                        image.GetPixelRowSpan(y)[x] = new Rgba32(newColor.R, newColor.G, newColor.B, byte.MaxValue);
                    }
                }
            }
        }

        public static Bitmap ImageSharpToBitMap(Image<Rgba32> image)
        {
            try
            {
                Bitmap imgResize;
                using (var memoryStream = new MemoryStream())
                {
                    var imageEncoder = image.GetConfiguration().ImageFormatsManager.FindEncoder(PngFormat.Instance);
                    image.Save(memoryStream, imageEncoder);

                    memoryStream.Seek(0, SeekOrigin.Begin);

                    imgResize = new Bitmap(memoryStream);
                }
                return imgResize;
            }
            catch (Exception err)
            {
                throw;
            }

        }


        public static Image<Rgba32> BitMapToImageSharp(Bitmap image)
        {
            try
            {
                byte[] imgBytes;
                using (var memoryStream = new MemoryStream())
                {
                    image.Save(memoryStream, ImageFormat.Png);
                    imgBytes = memoryStream.ToArray();
                }
                return Image<Rgba32>.Load(imgBytes);
            }
            catch (Exception err)
            {
                throw;
            }

        }
        */
    }
}
