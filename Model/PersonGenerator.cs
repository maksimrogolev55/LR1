using System;

namespace Model
{
    /// <summary>
    /// Представляет статические методы для генерации взрослого или ребенка
    /// </summary>
    public static class PersonGenerator
    {
        private static Random random = new Random();

        /// <summary>
        /// Заполняет базовые данные для случайного человека
        /// </summary>
        public static void FillRandomPerson(PersonBase person, Gender? gender = null)
        {
            string[] maleNames = { "Алексей", "Дмитрий", "Иван", "Сергей",
                                   "Андрей", "Максим", "Егор", "Артём" };
            string[] femaleNames = { "Анна", "Елена", "Мария", "Ольга",
                                     "Татьяна", "Наталья", "Дарья", "Полина" };
            string[] surnamesMale = { "Иванов", "Смирнов", "Кузнецов", "Попов",
                                      "Волков", "Соколов", "Лебедев", "Морозов" };
            string[] surnamesFemale = { "Иванова", "Смирнова", "Кузнецова", "Попова",
                                        "Волкова", "Соколова", "Лебедева", "Морозова" };

            person.Gender = gender ?? (Gender)random.Next(2);

            switch (person.Gender)
            {
                case Gender.Male:
                    person.Name = maleNames[random.Next(maleNames.Length)];
                    person.Surname = surnamesMale[random.Next(surnamesMale.Length)];
                    break;
                case Gender.Female:
                    person.Name = femaleNames[random.Next(femaleNames.Length)];
                    person.Surname = surnamesFemale[random.Next(surnamesFemale.Length)];
                    break;
            }
        }

        /// <summary>
        /// Заполняет данные для взрослого
        /// </summary>
        public static void FillAdult(Adult adult)
        {
            int age = random.Next(18, 70);

            string[] workPlaces = { "Газпром", "Яндекс", "Сбербанк", "РЖД",
                                   "Ростелеком", null, null };

            string workPlace = workPlaces[random.Next(workPlaces.Length)];
            string passport = $"{random.Next(1000, 10000)} {random.Next(100000, 1000000)}";

            adult.Age = age;
            adult.Passport = passport;
            adult.Workplace = workPlace;

            // 50% шанс создать партнёра
            if (random.Next(2) == 0)
            {
                Gender partnerGender = adult.Gender == Gender.Male
                    ? Gender.Female
                    : Gender.Male;
                adult.Partner = GetRandomAdult(partnerGender);
            }
        }

        /// <summary>
        /// Заполняет данные для ребенка
        /// </summary>
        public static void FillChild(Child child)
        {
            int age = random.Next(1, 17);

            string[] studyPlaces = { "Школа №31", "Детский сад №5", "Гимназия №2",
                                    "Лицей №3", null };

            string studyPlace = studyPlaces[random.Next(studyPlaces.Length)];

            child.Age = age;
            child.Study = studyPlace;

            Adult father = GetRandomAdult(Gender.Male);
            child.Father = father;

            Adult mother = GetRandomAdult(Gender.Female);
            child.Mother = mother;

            mother.Surname = father.Surname + "а";

            switch (child.Gender)
            {
                case Gender.Male:
                    child.Surname = father.Surname;
                    break;
                case Gender.Female:
                    child.Surname = mother.Surname;
                    break;
            }
        }

        /// <summary>
        /// Генерирует случайного взрослого
        /// </summary>
        public static Adult GetRandomAdult(Gender? gender = null)
        {
            Adult adult = new Adult();
            FillRandomPerson(adult, gender);
            FillAdult(adult);
            return adult;
        }

        /// <summary>
        /// Генерирует случайного ребенка
        /// </summary>
        public static Child GetRandomChild()
        {
            Child child = new Child();
            FillRandomPerson(child);
            FillChild(child);
            return child;
        }

        /// <summary>
        /// Генерирует случайную персону
        /// </summary>
        public static PersonBase GetRandomPerson()
        {
            return random.Next(2) == 0
                ? GetRandomAdult()
                : GetRandomChild();
        }
    }
}
