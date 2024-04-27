using System.Windows.Forms;

namespace TIFF_Crypter.Source
{
    internal class ExceptionMessages
    {
        private const string RuCultureName = "ru-RU";

        private static MessagesLocalized _engLocalization = new MessagesLocalized()
        {
            FileIsNull = "No image file.",
            SaveFileMessage = "Saved successfully!",
            NotEncryptedFile = "The image file is not encrypted!",
            AlreadyEncryptedFile = "The image file already encrypted!",
            OperationСompleted = "Operation completed!",
            OperationError = "Operation error: ",
            SaveError = "Saving error: ",
            OpenError = "Opening error: ",
            StartError = "This application must be run with administrator rights!",
        };

        private static MessagesLocalized _ruLocalization = new MessagesLocalized()
        {
            FileIsNull = "Пустой файл изображения.",
            SaveFileMessage = "Успешно сохранено!",
            NotEncryptedFile = "Файл изображения не зашифрован!",
            AlreadyEncryptedFile = "Файл изображения уже зашифрован!",
            OperationСompleted = "Операция выполнена!",
            OperationError = "Ошибка при выполнении операции: ",
            SaveError = "Ошибка при сохранении файла: ",
            OpenError = "Ошибка при открытии файла: ",
            StartError = "Это приложение должно быть запущено от имени администратора!",
        };

        // Получить контейнер сообщений в зависимости от текущей локализации.
        public static MessagesLocalized GetCurrentLocalization()
        {
            InputLanguage currentLanguage = InputLanguage.DefaultInputLanguage;

            if (currentLanguage.Culture.Name == RuCultureName)
            {
                return _ruLocalization;
            }

            return _engLocalization;
        }

        #region LocalizedStrings
        public static string FileIsNull()
            => GetCurrentLocalization().FileIsNull;

        public static string SaveFileMessage()
            => GetCurrentLocalization().SaveFileMessage;

        public static string NotEncryptedFile()
            => GetCurrentLocalization().NotEncryptedFile;

        public static string AlreadyEncryptedFile()
            => GetCurrentLocalization().AlreadyEncryptedFile;

        public static string OperationСompleted()
            => GetCurrentLocalization().OperationСompleted;

        public static string OperationError(string errorMessage)
            => $"{GetCurrentLocalization().OperationError}{errorMessage}";

        public static string SaveError(string errorMessage)
            => $"{GetCurrentLocalization().SaveError}{errorMessage}";

        public static string OpenError(string errorMessage)
            => $"{GetCurrentLocalization().OpenError}{errorMessage}";

        public static string StartError(string errorMessage)
            => $"{GetCurrentLocalization().StartError}{errorMessage}";
        #endregion

        /// <summary>
        /// Локализированный контейнер сообщений.
        /// </summary>
        public class MessagesLocalized
        {
            public string FileIsNull { get; internal set; }
            public string SaveFileMessage { get; internal set; }
            public string NotEncryptedFile { get; internal set; }
            public string AlreadyEncryptedFile { get; internal set; }
            public string OperationСompleted { get; internal set; }
            public string OperationError { get; internal set; }
            public string SaveError { get; internal set; }
            public string OpenError { get; internal set; }
            public string StartError { get; internal set; }
        }
    }
}