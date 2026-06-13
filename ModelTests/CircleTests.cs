using Model;
using NUnit.Framework;

namespace ModelTests
{
    /// <summary>
    /// Класс для тестирования класса Circle.
    /// </summary>
    public class CircleTests
    {
        // ПОЗИТИВНЫЕ ТЕСТЫ

        [TestCase(1.0,   TestName = "Создание Circle с радиусом 1.0")]
        [TestCase(5.5,   TestName = "Создание Circle с радиусом 5.5")]
        [TestCase(100.0, TestName = "Создание Circle с радиусом 100.0")]
        public void ConstructorWithRadiusSetsProperty(double radius)
        {
            // Act
            var circle = new Circle(radius);

            // Assert
            Assert.AreEqual(radius, circle.Radius, TestTools.Tolerance);
        }

        [Test(Description = "Конструктор по умолчанию создаёт Circle без исключений")]
        public void DefaultConstructorCreatesCircleWithoutException()
        {
            // Act & Assert
            Assert.DoesNotThrow(() => new Circle());
        }

        [Test(Description = "Validate на корректном Circle не выбрасывает исключений")]
        public void ValidateOnValidCircleDoesNotThrow()
        {
            // Arrange
            var circle = new Circle(5.0);

            // Act & Assert
            Assert.DoesNotThrow(() => circle.Validate());
        }

        [TestCase(3.0, 5.0, TestName = "Установка Radius через свойство на 5.0")]
        [TestCase(1.0, 2.5, TestName = "Установка Radius через свойство на 2.5")]
        public void SettingRadiusSetsCorrectValue(double initial, double newRadius)
        {
            // Arrange
            var circle = new Circle(initial);

            // Act
            circle.Radius = newRadius;

            // Assert
            Assert.AreEqual(newRadius, circle.Radius, TestTools.Tolerance);
        }

        [TestCase(1.0,  Math.PI * 1.0 * 1.0,   TestName = "CalculateArea для радиуса 1.0")]
        [TestCase(5.0,  Math.PI * 5.0 * 5.0,   TestName = "CalculateArea для радиуса 5.0")]
        [TestCase(2.5,  Math.PI * 2.5 * 2.5,   TestName = "CalculateArea для радиуса 2.5")]
        public void CalculateAreaReturnsCorrectValue(double radius, double expectedArea)
        {
            // Arrange
            var circle = new Circle(radius);

            // Act
            double area = circle.CalculateArea();

            // Assert
            Assert.AreEqual(expectedArea, area, TestTools.Tolerance);
        }

        [TestCase(3.0, TestName = "GetInfo содержит радиус и площадь для радиуса 3.0")]
        [TestCase(7.5, TestName = "GetInfo содержит радиус и площадь для радиуса 7.5")]
        public void GetInfoContainsRadiusAndArea(double radius)
        {
            // Arrange
            var circle = new Circle(radius);

            // Act
            string info = circle.GetInfo();

            // Assert
            Assert.IsTrue(info.Contains(radius.ToString("F2")));
            Assert.IsTrue(info.Contains(circle.CalculateArea().ToString("F2")));
        }

        [Test(Description = "GetShapeType возвращает «Круг»")]
        public void GetShapeTypeReturnsKrug()
        {
            // Arrange
            var circle = new Circle(1.0);

            // Act
            string type = circle.GetShapeType();

            // Assert
            Assert.AreEqual("Круг", type);
        }

        // НЕГАТИВНЫЕ ТЕСТЫ — конструктор

        [TestCase(-1.0,                    TestName = "Создание Circle с радиусом -1.0")]
        [TestCase(0.0,                     TestName = "Создание Circle с радиусом 0.0")]
        [TestCase(double.NaN,              TestName = "Создание Circle с радиусом NaN")]
        [TestCase(double.PositiveInfinity, TestName = "Создание Circle с радиусом +Infinity")]
        [TestCase(double.NegativeInfinity, TestName = "Создание Circle с радиусом -Infinity")]
        public void ConstructorWithInvalidRadiusThrowsArgumentException(double invalidRadius)
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Circle(invalidRadius));
        }

        // НЕГАТИВНЫЕ ТЕСТЫ — Validate через setter + Validate()

        [TestCase(-1.0,                    TestName = "Validate с радиусом -1.0")]
        [TestCase(0.0,                     TestName = "Validate с радиусом 0.0")]
        [TestCase(double.NaN,              TestName = "Validate с радиусом NaN")]
        [TestCase(double.PositiveInfinity, TestName = "Validate с радиусом +Infinity")]
        [TestCase(double.NegativeInfinity, TestName = "Validate с радиусом -Infinity")]
        public void ValidateWithInvalidRadiusThrowsArgumentException(double invalidRadius)
        {
            // Arrange
            var circle = new Circle();
            circle.Radius = invalidRadius; // setter не валидирует — ставим напрямую

            // Act & Assert
            Assert.Throws<ArgumentException>(() => circle.Validate());
        }
    }
}
