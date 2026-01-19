using System.Reflection;
using System.Text.RegularExpressions;

namespace Model
{
    /// <summary>
    /// Хранение и обработка персональных данных.
    /// </summary>
    public class Person
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
        /// Инициализируем новый экземпляр класса Person.
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="surname">Фамилия</param>
        /// <param name="age">Возраст</param>
        /// <param name="gender">Пол</param>
        public Person(string name, string surname, int age, Gender gender)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Gender = gender;
        }

        /// <summary>
        /// Создаение нового экземпляра класса Person по умолчанию.
        /// </summary>
        public Person() { }

        /// <summary>
        /// Получение и валидация имени.
        /// </summary>
        public string Name
        {
            get { return _name; }
            set
            {
                //TODO: validation+
                _name = Validate(value, "Имя");
                // Проверяем, есть ли уже фамилия
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
                // Проверяем, есть ли уже имя
                if (!string.IsNullOrEmpty(_name))
                {
                    EnsureLanguage();
                }
            }
        }

        /// <summary>
        /// Получение и валидация возраста.
        /// </summary>
        public int Age
        {
            get { return _age; }
            set
            {
                if (value < MinAge || value > MaxAge)
                {
                    throw new Exception($"{nameof(Age)} должен быть от " +
                        $"{MinAge} до {MaxAge}!");
                }
                _age = value;
            }
        }

        /// <summary>
        /// Получение и валидация пола.
        /// </summary>
        public Gender Gender
        {
            get { return _gender; }
            set
            {
                _gender = value;
            }
        }

        /// <summary>
        /// Проверка строки, содержащей только кириллические символы
        /// </summary>
        private const string RussianPattern = @"^[а-яА-ЯёЁ]+(?:-[а-яА-ЯёЁ]+)?$";

        /// <summary>
        /// Проверка строки, содержащей только латинские символы
        /// </summary>
        private const string LatinPattern = @"^[a-zA-Z]+(?:-[a-zA-Z]+)?$";

        /// <summary>
        /// Проверяет корректность входной строки по заданным правилам
        /// </summary>
        /// <param name="value">Проверяемая строка</param>
        /// <param name="fieldName">Название поля</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">при неверном вводе</exception>
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
        /// <exception cref="InvalidOperationException">при несовпадении</exception>
        private void EnsureLanguage()
        {
            // Проверяем, что оба поля установлены
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
        /// Генерирует случайного человека с данными для тестирования.
        /// </summary>
        /// <returns>Возвращает новый экземпляр класса Person</returns>
        public static Person GetRandomPerson()
        {
            Random random = new Random();

            string[] maleNames = { "Даздраперм", "Баламут", "Велимудр",
                                   "Пересвет", "Радомир", "Светозар",
                                   "Тихомир", "Ярополк" };

            string[] femaleNames = { "Октябрина", "Даздрана", "Искра",
                                     "Виленина", "Гертруда", "Сталина",
                                     "Ревмира", "Люция" };

            string[] surnamesMale = { "Весельчаков", "Хохотушкин", "Пузиков",
                                      "Картошкин", "Борщов", "Пельменев",
                                      "Самоваров", "Балалайкин" };

            string[] surnamesFemale = { "Весельчакова", "Хохотушкина", "Пузикова",
                                        "Картошкина", "Борщова", "Пельменева",
                                        "Самоварова", "Балалайкина" };

            var gender = random.Next(2) == 0
                ? Gender.Male
                : Gender.Female;

            int age = random.Next(MinAge, MaxAge);

            string name = gender == Gender.Male
                ? maleNames[random.Next(maleNames.Length)]
                : femaleNames[random.Next(femaleNames.Length)];

            string surname = gender == Gender.Male
                ? surnamesMale[random.Next(surnamesMale.Length)]
                : surnamesFemale[random.Next(surnamesFemale.Length)];

            return new Person(name, surname, age, gender);
        }
    }
}
