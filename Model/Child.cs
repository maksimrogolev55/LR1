namespace Model
{
    /// <summary>
    /// Хранение и обработка данных ребенка
    /// </summary>
    public class Child : PersonBase
    {
        /// <summary>
        /// Мать
        /// </summary>
        private Adult _mother;

        /// <summary>
        /// Отец
        /// </summary>
        private Adult _father;

        /// <summary>
        /// Место учебы
        /// </summary>
        private string _studyPlace;

        /// <summary>
        /// Новый экземпляр класса Child
        /// </summary>
        public Child(string name, string surname, int age, Gender gender,
            Adult mother, Adult father, string study)
            : base(name, surname, age, gender)
        {
            Mother = mother;
            Father = father;
            Study = study;
        }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Child() : this("Иван", "Иванов", 10, Gender.Male,
            null, null, "Школа №31")
        { }

        /// <summary>
        /// Максимальный возраст для ребенка
        /// </summary>
        public override int MaxAgeForType => 17;

        /// <summary>
        /// Получение и валидация матери
        /// </summary>
        public Adult Mother
        {
            get { return _mother; }
            set
            {
                if (value != null && value.Gender != Gender.Female)
                {
                    throw new ArgumentException(
                        $"Некорректный пол матери: ожидается женский пол");
                }
                _mother = value;
            }
        }

        /// <summary>
        /// Получение и валидация отца
        /// </summary>
        public Adult Father
        {
            get { return _father; }
            set
            {
                if (value != null && value.Gender != Gender.Male)
                {
                    throw new ArgumentException(
                        $"Некорректный пол отца: ожидается мужской пол");
                }
                _father = value;
            }
        }

        /// <summary>
        /// Получение и валидация места учебы
        /// </summary>
        public string Study
        {
            get { return _studyPlace; }
            set
            {
                _studyPlace = string.IsNullOrEmpty(value)
                    ? "Не указано"
                    : value;
            }
        }

        /// <summary>
        /// Получение и валидация возраста
        /// </summary>
        public override int Age
        {
            get { return base.Age; }
            set
            {
                if (value > MaxAgeForType)
                {
                    throw new ArgumentException($"Возраст ребенка " +
                        $"должен быть не более {MaxAgeForType} лет");
                }
                base.Age = value;
            }
        }

        /// <summary>
        /// Получение названия пола
        /// </summary>
        protected override string GenderRole => Gender switch
        {
            Gender.Male => "Мальчик",
            Gender.Female => "Девочка"
        };

        /// <summary>
        /// Получение информации
        /// </summary>
        public override string GetInfo()
        {
            string basic = GetBasicInfo();

            string motherInfo = Mother != null
                ? $"{Mother.Name} {Mother.Surname}"
                : "не указана";

            string fatherInfo = Father != null
                ? $"{Father.Name} {Father.Surname}"
                : "не указан";

            return $"Ребёнок\n{basic}\n" +
                   $"Мать: {motherInfo}\n" +
                   $"Отец: {fatherInfo}\n" +
                   $"Место учебы: {Study}";
        }

        /// <summary>
        /// Метод демонстрирует информацию об учебе
        /// </summary>
        public string GetStudyInfo()
        {
            return $"Место учебы: {Study}";
        }

        /// <summary>
        /// Метод демонстрирует информацию о родителях
        /// </summary>
        public string GetParentsInfo()
        {
            //TODO: RSDN+
            string motherInfo = Mother != null
                ? $"{Mother.Name} {Mother.Surname}"
                : "не указана";

            string fatherInfo = Father != null
                ? $"{Father.Name} {Father.Surname}"
                : "не указан";

            return $"Родители: мать - {motherInfo}, отец - {fatherInfo}";
        }
    }
}
