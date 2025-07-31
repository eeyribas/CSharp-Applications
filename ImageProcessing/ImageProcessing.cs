using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcessing
{
    public static class ImageProcessing
    {
        public static Bitmap ScaleBitmap(Bitmap sourceBMP, int width, int height)
        {
            Bitmap result = new Bitmap(width, height);
            using (Graphics graphics = Graphics.FromImage(result))
                graphics.DrawImage(sourceBMP, 0, 0, width, height);

            return result;
        }

        public static Image GetCopyImage(string path)
        {
            using (Image image = Image.FromFile(path))
            {
                Bitmap bitmap = new Bitmap(image);

                return bitmap;
            }
        }

        public static Color GetOppositeColor(Color color)
        {
            Color returnColor = Color.FromArgb(color.R > 127 ? 0 : 255, color.G > 127 ? 0 : 255, color.B > 127 ? 0 : 255);
            
            return returnColor;
        }

        public static List<Bitmap> SplitImage(string path, Size pictureBoxSize)
        {
            if (File.Exists(path))
            {
                using (Image inputImage = Image.FromFile(path))
                {
                    List<Bitmap> returnList = new List<Bitmap>();
                    Bitmap bInputImage = new Bitmap(inputImage);
                    if (bInputImage.Size.Height < pictureBoxSize.Height)
                    {
                        returnList.Add(bInputImage);

                        return returnList;
                    }
                    else
                    {
                        returnList = SplitHorizontal(bInputImage, pictureBoxSize.Height, pictureBoxSize.Width);
                        
                        return returnList;
                    }
                }
            }
            else
            {
                return null;
            }
        }

        public static List<Bitmap> SplitHorizontal(Bitmap bInputImage, int rowscountOutputImages, int pictureBoxWidth)
        {
            const int scrollBarHeight = 20;
            List<Bitmap> returnList = new List<Bitmap>();

            if (bInputImage.Width > pictureBoxWidth)
                rowscountOutputImages -= scrollBarHeight;

            if (bInputImage.Height > rowscountOutputImages)
            {
                for (int rowIndex = 0; rowIndex < bInputImage.Height - rowscountOutputImages; rowIndex += rowscountOutputImages)
                {
                    Rectangle rect = new Rectangle(0, rowIndex, bInputImage.Width, rowscountOutputImages);
                    Bitmap roi = bInputImage.Clone(rect, bInputImage.PixelFormat);
                    returnList.Add(roi);
                }
            }
            else
            {
                returnList.Add(bInputImage);
            }

            return returnList;
        }

        private static Bitmap Blur(Bitmap image, Rectangle rectangle, Int32 blurSize)
        {
            Bitmap blurred = new Bitmap(image.Width, image.Height);

            if (blurSize % 2 == 0)
                blurSize -= 1;
            if (blurSize <= 0)
                return image;

            if (image != null)
            {
                using (Graphics graphics = Graphics.FromImage(blurred))
                    graphics.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height),
                        new Rectangle(0, 0, image.Width, image.Height), GraphicsUnit.Pixel);

                for (Int32 xx = rectangle.X; xx < rectangle.X + rectangle.Width; xx++)
                {
                    for (Int32 yy = rectangle.Y; yy < rectangle.Y + rectangle.Height; yy++)
                    {
                        Int32 avgR = 0, avgG = 0, avgB = 0;
                        Int32 blurPixelCount = 0;

                        for (Int32 x = xx; (x < xx + blurSize && x < image.Width); x++)
                        {
                            for (Int32 y = yy; (y < yy + blurSize && y < image.Height); y++)
                            {
                                Color pixel = blurred.GetPixel(x, y);

                                avgR += pixel.R;
                                avgG += pixel.G;
                                avgB += pixel.B;

                                blurPixelCount++;
                            }
                        }

                        avgR = avgR / blurPixelCount;
                        avgG = avgG / blurPixelCount;
                        avgB = avgB / blurPixelCount;

                        for (Int32 x = xx; x < xx + blurSize && x < image.Width && x < rectangle.Width; x++)
                        {
                            for (Int32 y = yy; y < yy + blurSize && y < image.Height && y < rectangle.Height; y++)
                                blurred.SetPixel(x, y, Color.FromArgb(avgR, avgG, avgB));
                        }
                    }
                }
            }

            return blurred;
        }

        public static Bitmap GetScreenShot(ref Form form)
        {
            Bitmap screenshot = new Bitmap(form.Width, form.Height);
            Graphics graphics = Graphics.FromImage(screenshot as Image);
            graphics.CopyFromScreen(form.Location.X, form.Location.Y, 0, 0, screenshot.Size);

            return screenshot;
        }

        public static void UnBlurMe(Form form)
        {
            string objectKey = "1623102020";
            if (form.Controls.ContainsKey(objectKey))
                form.Controls.RemoveByKey(objectKey);
        }

        public static void BlueMe(Form form, int size)
        {
            Bitmap image = GetScreenShot(ref form);
            if (image != null)
            {
                image = Blur(image, new Rectangle(0, 0, form.Width, form.Height), size);

                PictureBox pb = new PictureBox();
                pb.BorderStyle = BorderStyle.None;
                pb.Size = form.Size;
                pb.Location = new System.Drawing.Point(0, 0);
                pb.Image = image;
                pb.Name = "1623102020";
                form.Controls.Add(pb);
                pb.BringToFront();
            }
        }

        public static Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);

            return returnImage;
        }

        public static Image ImageFromRawBgraArray(byte[] arr, int width, int height)
        {
            var output = new Bitmap(width, height);
            var rect = new Rectangle(0, 0, width, height);
            var bmpData = output.LockBits(rect, ImageLockMode.ReadWrite, output.PixelFormat);
            var ptr = bmpData.Scan0;
            Marshal.Copy(arr, 0, ptr, arr.Length);
            output.UnlockBits(bmpData);

            return output;
        }
    }
}
