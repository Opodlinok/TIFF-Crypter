using System.Drawing.Imaging;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Runtime.Serialization;

namespace TIFF_Crypter.Source
{
    internal class ImageMetadataHandler
    {
        public const string MetadataValue = "TIFF_Crypter";

        public static bool IsImageEncrypted(string imagePath)
        {
            // Загружаем изображение.
            Image image = Image.FromFile(imagePath);

            // Ищем PropertyItem с нужным нам ID.
            PropertyItem propItem = image.PropertyItems.FirstOrDefault(p => p.Id == 0x0112);

            if (propItem != null)
            {
                // Извлекаем значение из метаданных и сравниваем его с ожидаемым значением.
                string metadataValue = Encoding.ASCII.GetString(propItem.Value);
                metadataValue = metadataValue.TrimEnd('\0');
                return metadataValue == MetadataValue;
            }
            else
            {
                return false;
            }
        }

        public static Bitmap AddEncryptionMetadata(Bitmap imageFile)
        {
            // Конвертируем Bitmap в Image.
            Image image = (Image)imageFile;

            // Открываем PropertyItem и добавляем методанные по ID.
            PropertyItem propItem = (PropertyItem)FormatterServices.GetUninitializedObject(typeof(PropertyItem));
            propItem.Id = 0x0112;
            propItem.Type = 2;
            byte[] metadataBytes = Encoding.ASCII.GetBytes(MetadataValue);
            propItem.Len = metadataBytes.Length;
            propItem.Value = metadataBytes;

            // Добавляем метаданные к изображению.
            image.SetPropertyItem(propItem);

            Bitmap newBitmap = new Bitmap(image.Width, image.Height);
            using (Graphics g = Graphics.FromImage(newBitmap))
            {
                g.DrawImage(image, 0, 0);
                newBitmap.SetResolution(image.HorizontalResolution, image.VerticalResolution);

                // Добавляем пользовательские метаданные к новому Bitmap.
                newBitmap.SetPropertyItem(propItem);
            }

            return newBitmap;
        }
    }
}