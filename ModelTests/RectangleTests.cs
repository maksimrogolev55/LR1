using Model;
using NUnit.Framework;

namespace ModelTests
{
    /// <summary>
    /// Класс для тестирования класса Rectangle.
    /// </summary>
    public class RectangleTests
    {
        // ПОЗИТИВНЫЕ ТЕСТЫ

        [TestCase(3.0, 4.0,  TestName = "Создание Rectangle 3x4")]
        [TestCase(1.0, 1.0,  TestName = "Создание Rectangle 1x1 (квадрат)")]
        [TestCase(10.0, 5.5, TestName = "Создание Rectangle 10x5.5")]
        public void ConstructorWithWidthAndHeightSetsProperties(double width, double height)
        {
            // Act
            var rect = new Rectangle(width, height);

            // Assert
            Assert.AreEqual(width,  rect.Width,  TestTools.Tolerance);
            Assert.AreEqual(height, rect.Height, TestTools.Tolerance);
        }

        [Test(Description = "Конструктор по умолчанию создаёт Rectangle без исключений")]
        public void DefaultConstructorCreatesRectangleWithoutException()
        {
            // Act & Assert
            Assert.DoesNotThrow(() => new Rectangle());
        }

        [Test(Description = "Validate на корректном Rectangle не выбрасывает исключений")]
        public void ValidateOnValidRectangleDoesNotThrow()
        {
            // Arrange
            var rect = new Rectangle(3.0, 4.0);

            // Act & Assert
            Assert.DoesNotThrow(() => rect.Validate());
        }

        [TestCase(3.0, 4.0, 7.0, TestName = "Установка Width через свойство на 7.0")]
        public void SettingWidthSetsCorrectValue(double width, double height, double newWidth)
        {
            // Arrange
            var rect = new Rectangle(width, height);

            // Act
            rect.Width = newWidth;

            // Assert
            Assert.AreEqual(newWidth, rect.Width, TestTools.Tolerance);
        }

        [TestCase(3.0, 4.0, 9.0, TestName = "Установка Height через свойство на 9.0")]
        public void SettingHeightSetsCorrectValue(double width, double height, double newHeight)
        {
            // Arrange
            var rect = new Rectangle(width, height);

            // Act
            rect.Height = newHeight;

            // Assert
            Assert.AreEqual(newHeight, rect.Height, TestTools.Tolerance);
        }

        [TestCase(3.0,  4.0,  12.0, TestName = "CalculateArea для 3x4 = 12")]
        [TestCase(5.0,  5.0,  25.0, TestName = "CalculateArea для 5x5 = 25")]
        [TestCase(2.5,  4.0,  10.0, TestName = "CalculateArea для 2.5x4 = 10")]
        public void CalculateAreaReturnsCorrectValue(
            double width, double height, double expectedArea)
        {
            // Arrange
            var rect = new Rectangle(width, height);

            // Act
            double area = rect.CalculateArea();

            // Assert
            Assert.AreEqual(expectedArea, area, TestTools.Tolerance);
        }

        [TestCase(3.0, 4.0, TestName = "GetInfo содержит ширину, высоту и площадь для 3x4")]
        [TestCase(7.0, 2.5, TestName = "GetInfo содержит ширину, высоту и площадь для 7x2.5")]
        public void GetInfoContainsWidthHeightAndArea(double width, double height)
        {
            // Arrange
            var rect = new Rectangle(width, height);

            // Act
            string info = rect.GetInfo();

            // Assert
            Assert.IsTrue(info.Contains(width.ToString("F2")));
            Assert.IsTrue(info.Contains(height.ToString("F2")));
            Assert.IsTrue(info.Contains(rect.CalculateArea().ToString("F2")));
        }

        [Test(Description = "GetShapeType возвращает «Прямоугольник»")]
        public void GetShapeTypeReturnsPryamougolnik()
        {
            // Arrange
            var rect = new Rectangle(3.0, 4.0);

            // Act
            string type = rect.GetShapeType();

            // Assert
            Assert.AreEqual("Прямоугольник", type);
        }

        // НЕГАТИВНЫЕ ТЕСТЫ — конструктор, невалидная ширина

        [TestCase(-1.0,                    4.0, TestName = "Создание Rectangle с шириной -1.0")]
        [TestCase(0.0,                     4.0, TestName = "Создание Rectangle с шириной 0.0")]
        [TestCase(double.NaN,              4.0, TestName = "Создание Rectangle с шириной NaN")]
        [TestCase(double.PositiveInfinity, 4.0, TestName = "Создание Rectangle с шириной +Infinity")]
        [TestCase(double.NegativeInfinity, 4.0, TestName = "Создание Rectangle с шириной -Infinity")]
        public void ConstructorWithInvalidWidthThrowsArgumentException(
            double invalidWidth, double height)
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Rectangle(invalidWidth, height));
        }

        // НЕГАТИВНЫЕ ТЕСТЫ — конструктор, невалидная высота

        [TestCase(3.0, -1.0,                    TestName = "Создание Rectangle с высотой -1.0")]
        [TestCase(3.0, 0.0,                     TestName = "Создание Rectangle с высотой 0.0")]
        [TestCase(3.0, double.NaN,              TestName = "Создание Rectangle с высотой NaN")]
        [TestCase(3.0, double.PositiveInfinity, TestName = "Создание Rectangle с высотой +Infinity")]
        [TestCase(3.0, double.NegativeInfinity, TestName = "Создание Rectangle с высотой -Infinity")]
        public void ConstructorWithInvalidHeightThrowsArgumentException(
            double width, double invalidHeight)
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Rectangle(width, invalidHeight));
        }

        // НЕГАТИВНЫЕ ТЕСТЫ — Validate через setter + Validate()

        [TestCase(-1.0,                    TestName = "Validate с шириной -1.0")]
        [TestCase(0.0,                     TestName = "Validate с шириной 0.0")]
        [TestCase(double.NaN,              TestName = "Validate с шириной NaN")]
        [TestCase(double.PositiveInfinity, TestName = "Validate с шириной +Infinity")]
        [TestCase(double.NegativeInfinity, TestName = "Validate с шириной -Infinity")]
        public void ValidateWithInvalidWidthThrowsArgumentException(double invalidWidth)
        {
            // Arrange
            var rect = new Rectangle();
            rect.Width  = invalidWidth;
            rect.Height = 4.0;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => rect.Validate());
        }

        [TestCase(-1.0,                    TestName = "Validate с высотой -1.0")]
        [TestCase(0.0,                     TestName = "Validate с высотой 0.0")]
        [TestCase(double.NaN,              TestName = "Validate с высотой NaN")]
        [TestCase(double.PositiveInfinity, TestName = "Validate с высотой +Infinity")]
        [TestCase(double.NegativeInfinity, TestName = "Validate с высотой -Infinity")]
        public void ValidateWithInvalidHeightThrowsArgumentException(double invalidHeight)
        {
            // Arrange
            var rect = new Rectangle();
            rect.Width  = 3.0;
            rect.Height = invalidHeight;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => rect.Validate());
        }
    }
}
