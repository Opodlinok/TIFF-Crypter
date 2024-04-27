using System;
using System.Drawing;
using System.Windows.Forms;

namespace TIFF_Crypter.Source
{
    internal class FileCrypter
    {
        /// <summary>
        /// Генератор ключей перемешивания.
        /// </summary>
        /// <param name="length">Длина изображения.</param>
        /// <returns>Сгенерированный ключ перемешивания.</returns>
        private static int[] GenerateShuffleKey(int length)
        {
            int[] key = new int[length];
            for (int i = 0; i < length; i++)
            {
                key[i] = i;
            }

            // Перемешивание ключа шифрования, с фиксированным сидом для воспроизводимости.
            Random rnd = new Random(12345);
            for (int i = 0; i < length; i++)
            {
                int j = rnd.Next(length);
                int temp = key[i];
                key[i] = key[j];
                key[j] = temp;
            }

            return key;
        }

        /// <summary>
        /// Шифрует получаемое изображение путём перемешивания.
        /// </summary>
        /// <param name="image">Целевое изображение.</param>
        /// <param name="encrypt">Зашифровывать или расшифровывать изображение (По умолчанию зашифровывать).</param>
        /// <returns></returns>
        public static Bitmap GetCryptedImage(Bitmap image, Action<int> operationProgress = null, bool encrypt = true)
        {
            // Проверяем валиден ли файл изображения.
            if (image == null)
            {
                MessageBox.Show(ExceptionMessages.FileIsNull());
                return null;
            }

            int width = image.Width;
            int height = image.Height;
            Bitmap resultImage = new Bitmap(width, height);

            // Генерируем ключи перемешивания.
            int[] xKey = GenerateShuffleKey(width);
            int[] yKey = GenerateShuffleKey(height);

            // Перебираем изображение по ширине и высоте.
            try
            {
                int totalPixels = width * height;
                int processedPixels = default;
                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        // Перемешиваем пиксели.
                        int newX = encrypt ? xKey[x] : Array.IndexOf(xKey, x);
                        int newY = encrypt ? yKey[y] : Array.IndexOf(yKey, y);

                        // Устанавливаем перемешанные пиксели итоговому изображению.
                        Color pixelColor = image.GetPixel(x, y);
                        resultImage.SetPixel(newX, newY, pixelColor);

                        // Увеличиваем количество обработанных пикселей и выводим прогресс.
                        processedPixels++;
                        int progressPercentage = (int)((double)processedPixels / totalPixels * 100);
                        operationProgress?.Invoke(progressPercentage);
                    }
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ExceptionMessages.OperationError(ex.Message));
                return null;
            }

            MessageBox.Show(ExceptionMessages.OperationСompleted());
            operationProgress?.Invoke(default);
            return resultImage;
        }
    }
}