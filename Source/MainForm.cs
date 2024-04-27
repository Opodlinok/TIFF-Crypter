using System.Drawing;
using System.Windows.Forms;
using TIFF_Crypter.Source;

namespace TIFF_Crypter
{
    /// <summary>
    /// View основной формы программы.
    /// </summary>
    public partial class MainForm : Form
    {
        private FileManager _fileManager;
        private Bitmap _openedImageFile;
        private bool _imageIsEcnrypted;

        public MainForm()
        {
            InitializeComponent();
            Initialize();
        }

        /// <summary>
        /// Инициализация сервисов и ивентов.
        /// </summary>
        public void Initialize() 
        {
            // Инициализируем новый сервис по работе с файлами.
            _fileManager = new FileManager(OpenAfterCheckBox, FilePathTextBox);

            // Прокидываем ивенты на UI элементы.
            EncryptButton.Click += (sender, e) =>
            {
                // Проверяем, если изображение уже зашифрованно - не допускаем выполнение операции.
                if (_imageIsEcnrypted)
                {
                    MessageBox.Show(ExceptionMessages.AlreadyEncryptedFile());
                    return;
                }

                Bitmap encryptedImage = FileCrypter.GetCryptedImage(_openedImageFile, UpdateOperationProgressBar);
                
                if (encryptedImage != null)
                {
                    _openedImageFile = encryptedImage;
                    _imageIsEcnrypted = true;
                }
            };

            DecryptButton.Click += (sender, e) =>
            {
                // Проверяем, если изображение не зашифрованно - не допускаем выполнение операции.
                if (!_imageIsEcnrypted)
                {
                    MessageBox.Show(ExceptionMessages.NotEncryptedFile());
                    return;
                }

                Bitmap decryptedImage = FileCrypter.GetCryptedImage(_openedImageFile, UpdateOperationProgressBar, encrypt: false);

                if (decryptedImage != null)
                {
                    _openedImageFile = decryptedImage;
                    _imageIsEcnrypted = false;
                }
            };

            SaveFileButton.Click += (sender, e) =>
            {
                if (_fileManager.SuccessfulSaveFile(_openedImageFile, _imageIsEcnrypted))
                {
                    _openedImageFile = null;
                }
            };

            OpenFileButton.Click += (sender, e) =>
            {
                _openedImageFile = _fileManager.OpenImageFile(out bool ImageIsEcnrypted);
                _imageIsEcnrypted = ImageIsEcnrypted;
            };
        }

        /// <summary>
        /// Обновление прогресса шифрования.
        /// </summary>
        /// <param name="value">Текущее значение прогресса операции.</param>
        private void UpdateOperationProgressBar(int value) 
        {
            int minValue = OperationProgressBar.Minimum;
            int maxValue = OperationProgressBar.Maximum;

            // Clamp для значения, поскольку .NET Core < 2.0 не поддерживает Math.Clamp.
            value = (value < minValue) 
                ? minValue : (value > maxValue) 
                ? maxValue : value;

            OperationProgressBar.Value = value;
        }
    }
}