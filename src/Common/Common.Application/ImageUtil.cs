using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace Common.Application;

public static class ImageConvertor
{
    /// <summary>
    /// برای کوچک کردن عکس از این متد استفاده کنید
    /// </summary>
    /// <param name="inputImagePath">آدرس عکس را وارد کنید</param>
    /// <param name="outputPath">مسیری که قراره فایل بیت مپ ذخیره شود </param>
    /// <param name="newWidth">عرض عکس</param>
    /// <param name="new_height">ارتفاع عکس</param>

    public static void CreateBitMap(string inputImagePath, string outputPath, int newWidth, int new_height)
    {

        var inputDirectory = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{inputImagePath.Replace("/", "\\")}");
        #region OutPut
        var pathSplit = inputImagePath.Split('/');
        var imageName = pathSplit[^1];

        var folderName = Path.Combine(Directory.GetCurrentDirectory(), outputPath.Replace("/", "\\"));
        if (!Directory.Exists(folderName))
        {
            //Create Folder
            Directory.CreateDirectory(folderName);
        }
        var outputDirectory = Path.Combine(folderName, imageName);

        #endregion
        Image_resize(inputDirectory, outputDirectory, newWidth, new_height);
    }
    private static void Image_resize(string input_Image_Path, string output_Image_Path, int new_Width, int new_Height)
    {
        const long quality = 50L;
        Bitmap source_Bitmap = new Bitmap(input_Image_Path);
        double dblWidth_origial = source_Bitmap.Width;
        double dblHeigth_origial = source_Bitmap.Height;
        double relation_heigth_width = dblHeigth_origial / dblWidth_origial;
        //int new_Height = (int)(new_Width * relation_heigth_width);
        var new_DrawArea = new Bitmap(new_Width, new_Height);
        using (var graphic_of_DrawArea = Graphics.FromImage(new_DrawArea))
        {
            graphic_of_DrawArea.CompositingQuality = CompositingQuality.HighSpeed;

            graphic_of_DrawArea.InterpolationMode = InterpolationMode.HighQualityBicubic;

            graphic_of_DrawArea.CompositingMode = CompositingMode.SourceCopy;

            graphic_of_DrawArea.DrawImage(source_Bitmap, 0, 0, new_Width, new_Height);

            using (var output = System.IO.File.Open(output_Image_Path, FileMode.Create))
            {

                var qualityParamId = System.Drawing.Imaging.Encoder.Quality;

                var encoderParameters = new EncoderParameters(1);

                encoderParameters.Param[0] = new EncoderParameter(qualityParamId, quality);

                var codec = ImageCodecInfo.GetImageDecoders().FirstOrDefault(c => c.FormatID == ImageFormat.Jpeg.Guid);

                new_DrawArea.Save(output, codec, encoderParameters);

                output.Close();

            }
            graphic_of_DrawArea.Dispose();
        }
        source_Bitmap.Dispose();
    }


    #region CompresImage
    /// <summary>
    /// 
    /// </summary>
    /// <param name="imagePath">آدرس عکس</param>
    /// <param name="destPath">آدرس ذخیره عکس</param>
    /// <param name="quality">عددی بین 0 تا 100</param>
    public static void CompressImage(string imagePath, string destPath, long quality)
    {
        var inputDirectory = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{imagePath.Replace("/", "\\")}");
        var fileName = Path.GetFileName(inputDirectory);
        var outputDirectory = Path.Combine(Directory.GetCurrentDirectory(), destPath);
        if (!Directory.Exists(outputDirectory))
        {
            //Create Folder
            Directory.CreateDirectory(outputDirectory);
        }

        outputDirectory = Path.Combine(outputDirectory, fileName);
        using (Bitmap bmp1 = new Bitmap(inputDirectory))
        {
            ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);

            Encoder qualityEncoder = Encoder.Quality;

            EncoderParameters myEncoderParameters = new EncoderParameters(1);

            EncoderParameter myEncoderParameter = new EncoderParameter(qualityEncoder, quality);

            myEncoderParameters.Param[0] = myEncoderParameter;
            bmp1.Save(outputDirectory, jpgEncoder, myEncoderParameters);
        }
    }
    private static ImageCodecInfo GetEncoder(ImageFormat format)
    {
        ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
        foreach (ImageCodecInfo codec in codecs)
        {
            if (codec.FormatID == format.Guid)
            {
                return codec;
            }
        }
        return null;
    }
    #endregion
}