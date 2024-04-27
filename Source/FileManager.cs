using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace TIFF_Crypter.Source
{
    internal class FileManager
    {
        /// <summary>
        /// Фильтр доступных к открытию и обработке файлов.
        /// </summary>
        private const string FileFilter = "TIFF (*.tiff; *.tif)|*.tiff; *.tif";

        /// <summary>
        /// Чек-бокс проверяющий нужно ли открыть путь к файлу, после сохранения.
        /// </summary>
        private CheckBox _openAfterSaving;

        /// <summary>
        /// Текстовое поле для отображения пути к файлу.
        /// </summary>
        private TextBox _filePathTextBox;

        public FileManager(CheckBox openAfterSaving, TextBox filePathTextBox)
        {
            _openAfterSaving = openAfterSaving;
            _filePathTextBox = filePathTextBox;
        }

        /// <summary>
        /// Открывает диалоговое окна для выбора файла.
        /// </summary>
        /// <returns>Открытый файл изображения.</returns>
        public Bitmap OpenImageFile(out bool fileIsEncrypted)
        {
            fileIsEncrypted = false;

            // Создаём новое диалоговое окно для открытия файлов.
            var fileDialog = new OpenFileDialog()
            {
                Filter = FileFilter,
                RestoreDirectory = true,
            };

            // Получаем результат диалога.
            DialogResult dialogResult = fileDialog.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                try
                {
                    // Возвращаем открытый пользователем файл изображения.
                    string filePath = fileDialog.FileName;
                    _filePathTextBox.Text = filePath;

                    // Проверяем был ли открытый файл зашифрован ранее.
                    fileIsEncrypted = ImageMetadataHandler.IsImageEncrypted(filePath);

                    return new Bitmap(filePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ExceptionMessages.OpenError(ex.Message));
                }
            }

            return null;
        }

        /// <summary>
        /// Открывает диалоговое окно для сохранения файла.
        /// </summary>
        /// <param name="imageFile">Сохраняемый файл.</param>
        public bool SuccessfulSaveFile(Bitmap imageFile, bool imageIsEcnrypted = true) 
        {
            // Проверяем валиден ли переданный для сохранения Bitmap.
            if (imageFile == null)
            {
                MessageBox.Show(ExceptionMessages.FileIsNull());
                return false;
            }

            // Создаём новое диалоговое окно для сохранения файлов.
            var fileDialog = new SaveFileDialog()
            {
                Filter = FileFilter,
                RestoreDirectory = true,
            };

            // Получаем результат диалога.
            DialogResult dialogResult = fileDialog.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                try
                {
                    // Если изображение было зашифрованно - добавляем метаданные, и наоборот.
                    if (imageIsEcnrypted)
                    {
                        imageFile = ImageMetadataHandler.AddEncryptionMetadata(imageFile);
                    }

                    // Сохраняем файл изображение по пути, который указал пользователь.
                    string filePath = fileDialog.FileName;
                    imageFile.Save(filePath, System.Drawing.Imaging.ImageFormat.Tiff);
                    imageFile.Dispose();

                    MessageBox.Show(ExceptionMessages.SaveFileMessage());
                    _filePathTextBox.Text = string.Empty;
                    
                    if (_openAfterSaving.Checked)
                    {
                        // Открываем путь к файлу после сохранения
                        Process.Start("explorer.exe", $"/select,\"{filePath}\"");
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ExceptionMessages.SaveError(ex.Message));
                }
            }

            return false;
        }
    }
}