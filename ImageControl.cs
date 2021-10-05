using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using DirectXTexNet;


namespace Skyrim_Background_Injector
{
    public class ImageControl : IDisposable
    {

        public static Size GetImageSize(string path)
        {
            using (System.Drawing.Image imageToCheck = GetImageFast(path))
            {
                return imageToCheck.Size;
            }
        }

        private static System.Drawing.Image GetImageFast(string path)
        {
            using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None, 4096, FileOptions.SequentialScan))
            {
                return System.Drawing.Image.FromStream(fileStream, false, false);
            }
        }

        private static Size GetSizeScaled(Size imageSize, Size containerSize)
        {
            float aspectRatio = (float)imageSize.Width / (float)imageSize.Height;

            // Try scaling Height fixing Width value
            int newWidth = containerSize.Width;
            int newHeight = Convert.ToInt32(Math.Ceiling(newWidth / aspectRatio));

            if (newHeight < containerSize.Height)
            {
                // Scaled Height is too small,
                // scaling Width fixing Height value
                newHeight = containerSize.Height;
                newWidth = Convert.ToInt32(Math.Ceiling(newHeight * aspectRatio));
            }

            return new Size(newWidth, newHeight);
        }

        //public static void ProcessImageToDds(String inputImagePath, String outputDdsPath)
        //{
        //    Bitmap processedImage = processImage(inputImagePath);

        //    SaveImageToDds(processedImage, outputDdsPath, inputImagePath);
        //}

        //private static Bitmap processImage(String inputImagePath)
        //{
        //    /*Bitmap bTemp = new Bitmap(2048, 2048, PixelFormat.Format32bppPArgb);

        //    using (Graphics g = Graphics.FromImage(bTemp))
        //    {
        //        g.SmoothingMode = SmoothingMode.AntiAlias;
        //        g.CompositingQuality = CompositingQuality.HighQuality;
        //        g.PixelOffsetMode = PixelOffsetMode.HighQuality;
        //        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
        //        g.CompositingMode = CompositingMode.SourceCopy;

        //        g.Clear(Color.Black);

        //        using (Image i = GetImage(inputImagePath, LoadingSpeed.Slow))
        //        {
        //            Size scaledImageSize = GetSizeScaled(i.Size, new Size(1920, 1080));

        //            Rectangle srcRectangle = new Rectangle(0, 0, scaledImageSize.Width, scaledImageSize.Height);
        //            Rectangle destRectangle = new Rectangle(63, 337, 1920, 1080);

        //            using (var wrapMode = new ImageAttributes())
        //            {
        //                // Prevents ghosting around the image borders 
        //                wrapMode.SetWrapMode(WrapMode.TileFlipXY);

        //                g.DrawImage(i, destRectangle, srcRectangle.X, srcRectangle.Y, srcRectangle.Width, srcRectangle.Height, GraphicsUnit.Pixel, wrapMode);
        //            }
        //        }
        //    }

        //    return bTemp;*/
        //    return null;
        //}

        //private static void SaveImageToDds(Bitmap bitmap, String outputDdsPath, String inputImagePath)
        //{
        //    int imageSize;
        //    IntPtr imagePointer;
        //    //((Bitmap)image).GetRaw
        //    using (MemoryStream sourceImageStream = new MemoryStream())
        //    {
        //        Skyrim_Background_Injector.Properties.Resources.black_background.Save(sourceImageStream, ImageFormat.Bmp);
                
        //        imageSize = (int)sourceImageStream.Length;
        //        imagePointer = Marshal.AllocHGlobal(imageSize);

        //        Marshal.Copy(sourceImageStream.ToArray(), 0, imagePointer, imageSize);
        //    }

        //    /*byte[] bitmapRaw = BmpToBytes_Unsafe(bitmap);

        //    imageSize = bitmapRaw.Length;
        //    imagePointer = Marshal.AllocHGlobal(imageSize);

        //    Marshal.Copy(bitmapRaw, 0, imagePointer, imageSize);*/

        //    //bitmap.
        //    //var scratchImage = DirectXTexNet.TexHelper.Instance.LoadFromWICMemory(imagePointer, imageSize, DirectXTexNet.WIC_FLAGS.NONE);

        //    DirectXTexNet.ScratchImage bg = DirectXTexNet.TexHelper.Instance.LoadFromWICMemory(imagePointer, imageSize, DirectXTexNet.WIC_FLAGS.NONE); ;
            

        //    var scratchImage = DirectXTexNet.TexHelper.Instance.LoadFromWICFile(inputImagePath, DirectXTexNet.WIC_FLAGS.NONE);
        //    Size scaledImageSize = GetSizeScaled(new Size(scratchImage.GetImage(0).Width, scratchImage.GetImage(0).Height), new Size(1920, 1080));
        //    var scratchImageSized = scratchImage.Resize(scaledImageSize.Width, scaledImageSize.Height, DirectXTexNet.TEX_FILTER_FLAGS.CUBIC);

        //    DirectXTexNet.TexHelper.Instance.CopyRectangle(scratchImageSized.GetImage(0), 0, 0, 1920, 1080, bg.GetImage(0), DirectXTexNet.TEX_FILTER_FLAGS.CUBIC, 30, 30);

        //    Marshal.FreeHGlobal(imagePointer);

        //    //c.Resize

        //    scratchImage.Dispose();

        //    scratchImageSized.Dispose();

        //    using (var scratchImageCompressed = bg.Compress(DirectXTexNet.DXGI_FORMAT.BC1_UNORM, DirectXTexNet.TEX_COMPRESS_FLAGS.DEFAULT, 0.5f))
        //    {
        //        //scratchImage.
        //        bg.Dispose();
        //        scratchImageCompressed.SaveToDDSFile(DirectXTexNet.DDS_FLAGS.NONE, outputDdsPath);
        //    }
        //}

        public ImageControl()
        {
            InitializeBackground();
            isDisposed = false;
        }

        public void Dispose()
        {
            DisposeBackground();
            isDisposed = true;
        }

        private Boolean isDisposed;
        private IntPtr backgroundPointer;
        private int backgroundSize;

        private void InitializeBackground()
        {
            using (MemoryStream sourceImageStream = new MemoryStream())
            {
                Skyrim_Background_Injector.Properties.Resources.black_background.Save(sourceImageStream, ImageFormat.Bmp);

                backgroundSize = (int)sourceImageStream.Length;
                backgroundPointer = Marshal.AllocHGlobal(backgroundSize);

                Marshal.Copy(sourceImageStream.ToArray(), 0, backgroundPointer, backgroundSize);
            }
        }

        private void DisposeBackground()
        {
            Marshal.FreeHGlobal(backgroundPointer);
        }

        public void ProcessImageToDds(String inputImagePath, String outputDdsPath)
        {
            if (isDisposed)
            {
                throw new Exception("[IMGCTRL-01] Can't process a disposed background!");
            }

            var backgroundScratchImage = TexHelper.Instance.LoadFromWICMemory(backgroundPointer, backgroundSize, WIC_FLAGS.NONE);

            var rawScratchImage = TexHelper.Instance.LoadFromWICFile(inputImagePath, WIC_FLAGS.NONE);
            
            var scaledImageSize = GetSizeScaled(new Size(rawScratchImage.GetImage(0).Width, rawScratchImage.GetImage(0).Height), new Size(1920, 1080));

            using (var scaledRawScratchImage = rawScratchImage.Resize(scaledImageSize.Width, scaledImageSize.Height, TEX_FILTER_FLAGS.LINEAR))
            {
                rawScratchImage.Dispose();

                TexHelper.Instance.CopyRectangle(scaledRawScratchImage.GetImage(0), 0, 0, 1920, 1080, backgroundScratchImage.GetImage(0), TEX_FILTER_FLAGS.POINT, 63, 337);
            }

            var mipMapScratchImage = backgroundScratchImage.GenerateMipMaps(TEX_FILTER_FLAGS.POINT, 0);

            backgroundScratchImage.Dispose();

            using (var scratchImageCompressed = mipMapScratchImage.Compress(DXGI_FORMAT.BC1_UNORM, TEX_COMPRESS_FLAGS.DEFAULT, 0.5f))
            {
                mipMapScratchImage.Dispose();

                scratchImageCompressed.SaveToDDSFile(DDS_FLAGS.NONE, outputDdsPath);
            }

        }

    }

}
