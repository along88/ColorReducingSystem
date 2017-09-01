using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;

namespace ColorService
{
    public class ColorOperator : IColorOperator
    {
        public List<Color> GetDiscreetColorList(Bitmap bitmap)
        {
            List<Color> colorList = new List<Color>();
            for (var y = 0; y < bitmap.Height; y++)
            {
                for (var x = 0; x < bitmap.Width; x++)
                {
                    colorList.Add(bitmap.GetPixel(x, y));
                }
            }

            var distinctColors = colorList.Distinct().ToList();
            return distinctColors;
        }

        public void ExceptGivenColorFillImageWIthReplacementColor(Bitmap bitmap, Color givenColor, Color replacementColor)
        {
            for (var y = 0; y < bitmap.Height; y++)
            {
                for (var x = 0; x < bitmap.Width; x++)
                {
                    //issuse over here
                    if (bitmap.GetPixel(x, y) == givenColor)
                    {
                        //bitmap.SetPixel(x, y, replacementColor);

                    }
                    if (bitmap.GetPixel(x, y) != givenColor)
                    {
                        bitmap.SetPixel(x, y, replacementColor);
                    }
                }
            }
        }

        public void ReplaceColor(Bitmap bitmap, Color originalColor, Color replacementColor)
        {
            for (var y = 0; y < bitmap.Height; y++)
            {
                for (var x = 0; x < bitmap.Width; x++)
                {
                    //issuse over here
                    if (bitmap.GetPixel(x, y) == originalColor)
                    {
                        bitmap.SetPixel(x, y, replacementColor);

                    }
                    if (bitmap.GetPixel(x, y) != originalColor)
                    {
                       // bitmap.SetPixel(x, y, replacementColor);
                    }
                }
            }
        }

        public unsafe void ReplaceColorUnsafe(Bitmap bitmap, byte[] originalColor, byte[] replacementColor)
        {
            if (originalColor.Length != replacementColor.Length)
            {
                throw new ArgumentException("Original and Replacement arguments are in different pixel formats.");
            }

            if (originalColor.SequenceEqual(replacementColor))
            {
                return;
            }

            var data = bitmap.LockBits(new Rectangle(System.Drawing.Point.Empty, bitmap.Size),
                ImageLockMode.ReadWrite,
                bitmap.PixelFormat);

            var bpp = System.Drawing.Image.GetPixelFormatSize(data.PixelFormat);

            //            if (originalColor.Length != bpp)
            //            {
            //                throw new ArgumentException("Original and Replacement arguments and the bitmap are in different pixel format.");
            //            }

            var start = (byte*)data.Scan0;
            var end = start + data.Stride;

            for (var px = start; px < end; px += bpp)
            {
                var match = true;

                for (var bit = 0; bit < bpp; bit++)
                {
                    if (px[bit] != originalColor[bit])
                    {
                        match = false;
                        break;
                    }
                }

                if (!match)
                {
                    continue;
                }

                for (var bit = 0; bit < bpp; bit++)
                {
                    px[bit] = replacementColor[bit];
                }
            }

            bitmap.UnlockBits(data);
        }


        public List<Point> GetRectangleEdgePointsWithGivenColorOnBitMap(Bitmap bitmap, Color fetchColor)
        {
            List<Point> points = new List<Point>();
            for (int i = 0; i < bitmap.Height; i++)
            {
                for (int j = 0; j < bitmap.Width; j++)
                {
                    if (bitmap.GetPixel(j, i) == fetchColor)
                    {
                        points.Add(new Point(i, j));
                    }
                }
            }

            var y = points.Min(p => p.X);
            var x = points.Min(p => p.Y);
            var bY = points.Max(p => p.X);
            var bX = points.Max(p => p.Y);

            List<Point> stupidPointspoints = new List<Point>() { new Point(x, y), new Point(x, bY), new Point(bX, y), new Point(bX, bY) };


            return stupidPointspoints;
        }

    }
}