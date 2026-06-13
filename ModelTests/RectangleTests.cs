using Model;
using NUnit.Framework;

namespace ModelTests
{
    public class RectangleTests
    {

        [TestCase(3.0, 4.0,  TestName = "Создание Rectangle 3x4")]
        [TestCase(1.0, 1.0,  TestName = "Создание Rectangle 1x1 (квадрат)")]
        [TestCase(10.0, 5.5, TestName = "Создание Rectangle 10x5.5")]
        public void ConstructorWithWidthAndHeightSetsProperties(double width, double height)
        {
            var rect = new Rectangle(width, height);

            Assert.AreEqual(width,  rect.Width,  TestTools.Tolerance);
            Assert.AreEqual(height, rect.Height, TestTools.Tolerance);
        }

        [Test(Description = "Конструктор по умолчанию создаёт Rectangle без исключений")]
        public void DefaultConstructorCreatesRectangleWithoutException()
        {
            Assert.DoesNotThrow(() => new Rectangle());
        }

        [Test(Description = "Validate на корректном Rectangle не выбрасывает исключений")]
        public void ValidateOnValidRectangleDoesNotThrow()
        {
            var rect = new Rectangle(3.0, 4.0);

            Assert.DoesNotThrow(() => rect.Validate());
        }

        [TestCase(3.0, 4.0, 7.0, TestName = "Установка Width через свойство на 7.0")]
        public void SettingWidthSetsCorrectValue(double width, double height, double newWidth)
        {
            var rect = new Rectangle(width, height);

            rect.Width = newWidth;

            Assert.AreEqual(newWidth, rect.Width, TestTools.Tolerance);
        }

        [TestCase(3.0, 4.0, 9.0, TestName = "Установка Height через свойство на 9.0")]
        public void SettingHeightSetsCorrectValue(double width, double height, double newHeight)
        {
            var rect = new Rectangle(width, height);

            rect.Height = newHeight;

            Assert.AreEqual(newHeight, rect.Height, TestTools.Tolerance);
        }

        [TestCase(3.0,  4.0,  12.0, TestName = "CalculateArea для 3x4 = 12")]
        [TestCase(5.0,  5.0,  25.0, TestName = "CalculateArea для 5x5 = 25")]
        [TestCase(2.5,  4.0,  10.0, TestName = "CalculateArea для 2.5x4 = 10")]
        public void CalculateAreaReturnsCorrectValue(
            double width, double height, double expectedArea)
        {
            var rect = new Rectangle(width, height);

            double area = rect.CalculateArea();

            Assert.AreEqual(expectedArea, area, TestTools.Tolerance);
        }

        [TestCase(3.0, 4.0, TestName = "GetInfo содержит ширину, высоту и площадь для 3x4")]
        [TestCase(7.0, 2.5, TestName = "GetInfo содержит ширину, высоту и площадь для 7x2.5")]
        public void GetInfoContainsWidthHeightAndArea(double width, double height)
        {
            var rect = new Rectangle(width, height);

            string info = rect.GetInfo();

            Assert.IsTrue(info.Contains(width.ToString("F2")));
            Assert.IsTrue(info.Contains(height.ToString("F2")));
            Assert.IsTrue(info.Contains(rect.CalculateArea().ToString("F2")));
        }

        [Test(Description = "GetShapeType возвращает «Прямоугольник»")]
        public void GetShapeTypeReturnsPryamougolnik()
        {
            var rect = new Rectangle(3.0, 4.0);

            string type = rect.GetShapeType();

            Assert.AreEqual("Прямоугольник", type);
        }


        [TestCase(-1.0,                    4.0, TestName = "Создание Rectangle с шириной -1.0")]
        [TestCase(0.0,                     4.0, TestName = "Создание Rectangle с шириной 0.0")]
        [TestCase(double.NaN,              4.0, TestName = "Создание Rectangle с шириной NaN")]
        [TestCase(double.PositiveInfinity, 4.0, TestName = "Создание Rectangle с шириной +Infinity")]
        [TestCase(double.NegativeInfinity, 4.0, TestName = "Создание Rectangle с шириной -Infinity")]
        public void ConstructorWithInvalidWidthThrowsArgumentException(
            double invalidWidth, double height)
        {
            Assert.Throws<ArgumentException>(() => new Rectangle(invalidWidth, height));
        }


        [TestCase(3.0, -1.0,                    TestName = "Создание Rectangle с высотой -1.0")]
        [TestCase(3.0, 0.0,                     TestName = "Создание Rectangle с высотой 0.0")]
        [TestCase(3.0, double.NaN,              TestName = "Создание Rectangle с высотой NaN")]
        [TestCase(3.0, double.PositiveInfinity, TestName = "Создание Rectangle с высотой +Infinity")]
        [TestCase(3.0, double.NegativeInfinity, TestName = "Создание Rectangle с высотой -Infinity")]
        public void ConstructorWithInvalidHeightThrowsArgumentException(
            double width, double invalidHeight)
        {
            Assert.Throws<ArgumentException>(() => new Rectangle(width, invalidHeight));
        }


        [TestCase(-1.0,                    TestName = "Validate с шириной -1.0")]
        [TestCase(0.0,                     TestName = "Validate с шириной 0.0")]
        [TestCase(double.NaN,              TestName = "Validate с шириной NaN")]
        [TestCase(double.PositiveInfinity, TestName = "Validate с шириной +Infinity")]
        [TestCase(double.NegativeInfinity, TestName = "Validate с шириной -Infinity")]
        public void ValidateWithInvalidWidthThrowsArgumentException(double invalidWidth)
        {
            var rect = new Rectangle();
            rect.Width  = invalidWidth;
            rect.Height = 4.0;

            Assert.Throws<ArgumentException>(() => rect.Validate());
        }

        [TestCase(-1.0,                    TestName = "Validate с высотой -1.0")]
        [TestCase(0.0,                     TestName = "Validate с высотой 0.0")]
        [TestCase(double.NaN,              TestName = "Validate с высотой NaN")]
        [TestCase(double.PositiveInfinity, TestName = "Validate с высотой +Infinity")]
        [TestCase(double.NegativeInfinity, TestName = "Validate с высотой -Infinity")]
        public void ValidateWithInvalidHeightThrowsArgumentException(double invalidHeight)
        {
            var rect = new Rectangle();
            rect.Width  = 3.0;
            rect.Height = invalidHeight;

            Assert.Throws<ArgumentException>(() => rect.Validate());
        }
    }
}
