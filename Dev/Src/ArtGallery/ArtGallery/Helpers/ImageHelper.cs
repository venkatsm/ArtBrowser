using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

namespace ArtGallery.Helpers
{
    public static class ImageHelper
    {
        public static string UploadImage(HttpPostedFileBase file, string rootFolder, string path, bool generateThumbnail = false)
        {
            if (file.ContentLength != 0)
            {
                string folder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, rootFolder);
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                file.SaveAs(path);
            }

            if (generateThumbnail)
            {
                GenerateThumbnail(file, rootFolder, path);
            }

            string relativePath = MakeRelative(path, AppDomain.CurrentDomain.BaseDirectory);
            return relativePath;
        }

        private static void GenerateThumbnail(HttpPostedFileBase file, string rootFolder, string fileName)
        {
            using (var image = Image.FromStream(file.InputStream, true, true)) /* Creates Image from specified data stream */
            {
                using (var thumb = image.GetThumbnailImage(
                     100, /* width*/
                     100, /* height*/
                     () => false,
                     IntPtr.Zero))
                {
                    var jpgInfo = ImageCodecInfo.GetImageEncoders().Where(codecInfo => codecInfo.MimeType == "image/png").First(); /* Returns array of image encoder objects built into GDI+ */
                    using (var encParams = new EncoderParameters(1))
                    {
                        var appDataThumbnailPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, rootFolder, "thumbnails");
                        if (!Directory.Exists(appDataThumbnailPath))
                        {
                            Directory.CreateDirectory(appDataThumbnailPath);
                        }
                        string outputPath = Path.Combine(appDataThumbnailPath, "thumb_" + fileName);
                        long quality = 100;
                        encParams.Param[0] = new EncoderParameter(Encoder.Quality, quality);
                        thumb.Save(outputPath, jpgInfo, encParams);
                    }
                }
            }
        }

        private static string MakeRelative(string filePath, string referencePath)
        {
            var fileUri = new Uri(filePath);
            var referenceUri = new Uri(referencePath);
            return "/" + referenceUri.MakeRelativeUri(fileUri).ToString();
        }

    }
}