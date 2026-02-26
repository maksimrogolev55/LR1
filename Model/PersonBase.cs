using System.Text.RegularExpressions;

namespace Model
{
    /// <summary>
    /// Хранение и обработка персональных данных.
    /// </summary>
    public abstract class PersonBase
    {
        /// <summary>
        /// Имя человека
        /// </summary>
        private string _name;

        /// <summary>
        /// Фамилия человека
        /// </summary>
        private string _surname;

        /// <summary>
        /// Возраст человека
        /// </summary>
        private int _age;

        /// <summary>
        /// Минимальный возраст человека
        /// </summary>
        private const int MinAge = 0;

        /// <summary>
        /// Максимальный возраст человека
        /// </summary>
        private const int MaxAge = 123;

        /// <summary>
        /// Пол человека
        /// </summary>
        private Gender _gender;

        /// <summary>
        /// Инициализируем новый экземпляр класса PersonBase.
        /// </summary>
        protected PersonBase(string name, string surname, int age, Gender gender)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Gender = gender;
        }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        protected PersonBase() { }

        /// <summary>
        /// Получение и валидация имени.
        /// </summary>
        public string Name
        {
            get { return _name; }
            set
            {
                _name = Validate(value, "Имя");
                if (!string.IsNullOrEmpty(_surname))
                {
                    EnsureLanguage();
                }
            }
        }

        /// <summary>
        /// Получение и валидация фамилии.
        /// </summary>
        public string Surname
        {
            get { return _surname; }
            set
            {
                _surname = Validate(value, "Фамилия");
                if (!string.IsNullOrEmpty(_name))
                {
                    EnsureLanguage();
                }
            }
        }

        /// <summary>
        /// Минимальный возраст для конкретного типа
        /// </summary>
        public virtual int MinAgeForType => MinAge;

        /// <summary>
        /// Максимальный возраст для конкретного типа
        /// </summary>
        public virtual int MaxAgeForType => MaxAge;

        /// <summary>
        /// Получение и валидация возраста.
        /// </summary>
        public virtual int Age
        {
            get { return _age; }
            set
            {
                if (value < MinAgeForType || value > MaxAgeForType)
                {
                    throw new Exception($"{nameof(Age)} должен быть от " +
                        $"{MinAgeForType} до {MaxAgeForType}!");
                }
                _age = value;
            }
        }

        //TODO: autoproperty+
        /// <summary>
        /// Получение пола.
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Пол в текстовом виде
        /// </summary>
        protected abstract string GenderRole { get; }

        /// <summary>
        /// Проверка строки, содержащей только кириллические символы
        /// </summary>
        private const string RussianPattern = @"^[а-яА-ЯёЁ]+(?:-[а-яА-ЯёЁ]+)?$";

        /// <summary>
        /// Проверка строки, содержащей только латинские символы
        /// </summary>
        private const string LatinPattern = @"^[a-zA-Z]+(?:-[a-zA-Z]+)?$";

        /// <summary>
        /// Проверяет корректность входной строки
        /// </summary>
        private static string Validate(string value, string fieldName)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException(
                    $"{fieldName} не может быть пустым " +
                    $"или состоять только из пробелов.");
            }

            bool isRussian = Regex.IsMatch(value, RussianPattern);
            bool isLatin = Regex.IsMatch(value, LatinPattern);

            if (!isRussian && !isLatin)
            {
                throw new ArgumentException(
                    $"{fieldName} может содержать только русские буквы" +
                    $" ИЛИ только английские буквы. " +
                    $"Двойное имя/фамилия допускается через дефис.");
            }

            var textInfo =
                System.Globalization.CultureInfo.CurrentCulture.TextInfo;
            return textInfo.ToTitleCase(value.ToLowerInvariant());
        }

        /// <summary>
        /// Проверка на совпадение алфавитов имени и фамилии.
        /// </summary>
        private void EnsureLanguage()
        {
            if (string.IsNullOrEmpty(_name) || string.IsNullOrEmpty(_surname))
            {
                return;
            }

            bool nameIsRussian = Regex.IsMatch(_name, RussianPattern);
            bool surnameIsRussian = Regex.IsMatch(_surname, RussianPattern);

            if (nameIsRussian != surnameIsRussian)
            {
                throw new InvalidOperationException(
                    $"Язык имени и фамилии не совпадает. " +
                    "Имя и фамилия должны быть на одном языке.");
            }
        }

        /// <summary>
        /// Проверяет корректность ввода данных
        /// </summary>
        protected static string ValidateText(string value, string fieldName)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException(
                    $"Поле {fieldName} не может быть пустым " +
                    $"или состоять только из пробелов.");
            }
            return value;
        }

        /// <summary>
        /// Абстрактный метод получения информации
        /// </summary>
        public abstract string GetInfo();

        /// <summary>
        /// Формирование строки с базовой информацией
        /// </summary>
        protected string GetBasicInfo()
        {
            return $"{Name} {Surname}\nПол: {GenderRole}, возраст: {Age}";
        }
    }
}