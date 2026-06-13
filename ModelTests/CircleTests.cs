using Model;
using NUnit.Framework;

namespace ModelTests
{
    public class CircleTests
    {
        [Test(Description = "ShapeBase.Validate() вызывается без исключений через Circle")]
        public void ShapeBaseValidateDoesNotThrow()
        {
            ShapeBase shape = new Circle(1.0);
            Assert.DoesNotThrow(() => shape.Validate());
        }

        [TestCase(1.0, TestName = "Создание Circle с радиусом 1.0")]
        [TestCase(5.5, TestName = "Создание Circle с радиусом 5.5")]
        [TestCase(100.0, TestName = "Создание Circle с радиусом 100.0")]
        public void ConstructorWithRadiusSetsProperty(double radius)
        {
            var circle = new Circle(radius);
            Assert.AreEqual(radius, circle.Radius, TestTools.Tolerance);
        }

        [Test(Description = "Конструктор по умолчанию создаёт Circle без исключений")]
        public void DefaultConstructorCreatesCircleWithoutException()
        {
            Assert.DoesNotThrow(() => new Circle());
        }

        [Test(Description = "Validate на корректном Circle не выбрасывает исключений")]
        public void ValidateOnValidCircleDoesNotThrow()
        {
            var circle = new Circle(5.0);
            Assert.DoesNotThrow(() => circle.Validate());
        }

        [TestCase(3.0, 5.0, TestName = "Установка Radius через свойство на 5.0")]
        [TestCase(1.0, 2.5, TestName = "Установка Radius через свойство на 2.5")]
        public void SettingRadiusSetsCorrectValue(double initial, double newRadius)
        {
            var circle = new Circle(initial);
            circle.Radius = newRadius;
            Assert.AreEqual(newRadius, circle.Radius, TestTools.Tolerance);
        }

        [TestCase(1.0, Math.PI * 1.0 * 1.0, TestName = "CalculateArea для радиуса 1.0")]
        [TestCase(5.0, Math.PI * 5.0 * 5.0, TestName = "CalculateArea для радиуса 5.0")]
        [TestCase(2.5, Math.PI * 2.5 * 2.5, TestName = "CalculateArea для радиуса 2.5")]
        public void CalculateAreaReturnsCorrectValue(double radius, double expectedArea)
        {
            var circle = new Circle(radius);
            double area = circle.CalculateArea();
            Assert.AreEqual(expectedArea, area, TestTools.Tolerance);
        }

        [TestCase(3.0, TestName = "GetInfo содержит радиус и площадь для радиуса 3.0")]
        [TestCase(7.5, TestName = "GetInfo содержит радиус и площадь для радиуса 7.5")]
        public void GetInfoContainsRadiusAndArea(double radius)
        {
            var circle = new Circle(radius);
            string info = circle.GetInfo();
            Assert.IsTrue(info.Contains(radius.ToString("F2")));
            Assert.IsTrue(info.Contains(circle.CalculateArea().ToString("F2")));
        }

        [Test(Description = "GetShapeType возвращает «Круг»")]
        public void GetShapeTypeReturnsKrug()
        {
            var circle = new Circle(1.0);
            Assert.AreEqual("Круг", circle.GetShapeType());
        }

        [TestCase(-1.0, TestName = "Создание Circle с радиусом -1.0")]
        [TestCase(0.0, TestName = "Создание Circle с радиусом 0.0")]
        [TestCase(double.NaN, TestName = "Создание Circle с радиусом NaN")]
        [TestCase(double.PositiveInfinity, TestName = "Создание Circle с радиусом +Infinity")]
        [TestCase(double.NegativeInfinity, TestName = "Создание Circle с радиусом -Infinity")]
        public void ConstructorWithInvalidRadiusThrowsArgumentException(double invalidRadius)
        {
            Assert.Throws<ArgumentException>(() => new Circle(invalidRadius));
        }

        [TestCase(-1.0, TestName = "Validate с радиусом -1.0")]
        [TestCase(0.0, TestName = "Validate с радиусом 0.0")]
        [TestCase(double.NaN, TestName = "Validate с радиусом NaN")]
        [TestCase(double.PositiveInfinity, TestName = "Validate с радиусом +Infinity")]
        [TestCase(double.NegativeInfinity, TestName = "Validate с радиусом -Infinity")]
        public void ValidateWithInvalidRadiusThrowsArgumentException(double invalidRadius)
        {
            var circle = new Circle();
            circle.Radius = invalidRadius;
            Assert.Throws<ArgumentException>(() => circle.Validate());
        }
    }
}