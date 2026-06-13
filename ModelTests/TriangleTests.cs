using Model;
using NUnit.Framework;

namespace ModelTests
{
    /// <summary>
    /// Класс для тестирования класса Triangle.
    /// </summary>
    public class TriangleTests
    {
        // ПОЗИТИВНЫЕ ТЕСТЫ

        [TestCase(3.0, 4.0, 5.0,  TestName = "Создание Triangle 3-4-5 (прямоугольный)")]
        [TestCase(5.0, 5.0, 5.0,  TestName = "Создание Triangle 5-5-5 (равносторонний)")]
        [TestCase(6.0, 8.0, 10.0, TestName = "Создание Triangle 6-8-10")]
        public void ConstructorWithSidesSetsProperties(
            double sideA, double sideB, double sideC)
        {
            // Act
            var triangle = new Triangle(sideA, sideB, sideC);

            // Assert
            Assert.AreEqual(sideA, triangle.SideA, TestTools.Tolerance);
            Assert.AreEqual(sideB, triangle.SideB, TestTools.Tolerance);
            Assert.AreEqual(sideC, triangle.SideC, TestTools.Tolerance);
        }

        [Test(Description = "Конструктор по умолчанию создаёт Triangle без исключений")]
        public void DefaultConstructorCreatesTriangleWithoutException()
        {
            // Act & Assert
            Assert.DoesNotThrow(() => new Triangle());
        }

        [Test(Description = "Validate на корректном Triangle не выбрасывает исключений")]
        public void ValidateOnValidTriangleDoesNotThrow()
        {
            // Arrange
            var triangle = new Triangle(3.0, 4.0, 5.0);

            // Act & Assert
            Assert.DoesNotThrow(() => triangle.Validate());
        }

        [Test(Description = "Установка SideA через свойство")]
        public void SettingSideASetsCorrectValue()
        {
            // Arrange
            var triangle = new Triangle();
            // Act
            triangle.SideA = 7.0;
            // Assert
            Assert.AreEqual(7.0, triangle.SideA, TestTools.Tolerance);
        }

        [Test(Description = "Установка SideB через свойство")]
        public void SettingSideBSetsCorrectValue()
        {
            // Arrange
            var triangle = new Triangle();
            // Act
            triangle.SideB = 8.0;
            // Assert
            Assert.AreEqual(8.0, triangle.SideB, TestTools.Tolerance);
        }

        [Test(Description = "Установка SideC через свойство")]
        public void SettingSideCSetsCorrectValue()
        {
            // Arrange
            var triangle = new Triangle();
            // Act
            triangle.SideC = 9.0;
            // Assert
            Assert.AreEqual(9.0, triangle.SideC, TestTools.Tolerance);
        }

        [TestCase(3.0, 4.0, 5.0,  6.0,          TestName = "CalculateArea для 3-4-5 = 6.0")]
        [TestCase(5.0, 5.0, 5.0,  10.825317547,  TestName = "CalculateArea для 5-5-5")]
        [TestCase(6.0, 8.0, 10.0, 24.0,          TestName = "CalculateArea для 6-8-10 = 24.0")]
        public void CalculateAreaReturnsCorrectValue(
            double sideA, double sideB, double sideC, double expectedArea)
        {
            // Arrange
            var triangle = new Triangle(sideA, sideB, sideC);

            // Act
            double area = triangle.CalculateArea();

            // Assert
            Assert.AreEqual(expectedArea, area, TestTools.Tolerance);
        }

        [TestCase(3.0, 4.0, 5.0, TestName = "GetInfo содержит стороны и площадь для 3-4-5")]
        [TestCase(5.0, 5.0, 5.0, TestName = "GetInfo содержит стороны и площадь для 5-5-5")]
        public void GetInfoContainsSidesAndArea(double sideA, double sideB, double sideC)
        {
            // Arrange
            var triangle = new Triangle(sideA, sideB, sideC);

            // Act
            string info = triangle.GetInfo();

            // Assert
            Assert.IsTrue(info.Contains(sideA.ToString("F2")));
            Assert.IsTrue(info.Contains(sideB.ToString("F2")));
            Assert.IsTrue(info.Contains(sideC.ToString("F2")));
            Assert.IsTrue(info.Contains(triangle.CalculateArea().ToString("F2")));
        }

        [Test(Description = "GetShapeType возвращает «Треугольник»")]
        public void GetShapeTypeReturnsTreeugolnik()
        {
            // Arrange
            var triangle = new Triangle(3.0, 4.0, 5.0);

            // Act & Assert
            Assert.AreEqual("Треугольник", triangle.GetShapeType());
        }

        // НЕГАТИВНЫЕ ТЕСТЫ — невалидная сторона A

        [TestCase(-1.0,                    4.0, 5.0, TestName = "Создание Triangle со стороной A = -1.0")]
        [TestCase(0.0,                     4.0, 5.0, TestName = "Создание Triangle со стороной A = 0.0")]
        [TestCase(double.NaN,              4.0, 5.0, TestName = "Создание Triangle со стороной A = NaN")]
        [TestCase(double.PositiveInfinity, 4.0, 5.0, TestName = "Создание Triangle со стороной A = +Infinity")]
        [TestCase(double.NegativeInfinity, 4.0, 5.0, TestName = "Создание Triangle со стороной A = -Infinity")]
        public void ConstructorWithInvalidSideAThrowsArgumentException(
            double invalidSideA, double sideB, double sideC)
        {
            Assert.Throws<ArgumentException>(
                () => new Triangle(invalidSideA, sideB, sideC));
        }

        // НЕГАТИВНЫЕ ТЕСТЫ — невалидная сторона B

        [TestCase(3.0, -1.0,                    5.0, TestName = "Создание Triangle со стороной B = -1.0")]
        [TestCase(3.0, 0.0,                     5.0, TestName = "Создание Triangle со стороной B = 0.0")]
        [TestCase(3.0, double.NaN,              5.0, TestName = "Создание Triangle со стороной B = NaN")]
        [TestCase(3.0, double.PositiveInfinity, 5.0, TestName = "Создание Triangle со стороной B = +Infinity")]
        [TestCase(3.0, double.NegativeInfinity, 5.0, TestName = "Создание Triangle со стороной B = -Infinity")]
        public void ConstructorWithInvalidSideBThrowsArgumentException(
            double sideA, double invalidSideB, double sideC)
        {
            Assert.Throws<ArgumentException>(
                () => new Triangle(sideA, invalidSideB, sideC));
        }

        // НЕГАТИВНЫЕ ТЕСТЫ — невалидная сторона C

        [TestCase(3.0, 4.0, -1.0,                    TestName = "Создание Triangle со стороной C = -1.0")]
        [TestCase(3.0, 4.0, 0.0,                     TestName = "Создание Triangle со стороной C = 0.0")]
        [TestCase(3.0, 4.0, double.NaN,              TestName = "Создание Triangle со стороной C = NaN")]
        [TestCase(3.0, 4.0, double.PositiveInfinity, TestName = "Создание Triangle со стороной C = +Infinity")]
        [TestCase(3.0, 4.0, double.NegativeInfinity, TestName = "Создание Triangle со стороной C = -Infinity")]
        public void ConstructorWithInvalidSideCThrowsArgumentException(
            double sideA, double sideB, double invalidSideC)
        {
            Assert.Throws<ArgumentException>(
                () => new Triangle(sideA, sideB, invalidSideC));
        }

        // НЕГАТИВНЫЕ ТЕСТЫ — нарушение неравенства треугольника

        [TestCase(1.0,  2.0,  10.0, TestName = "Triangle: A+B <= C (1+2<=10)")]
        [TestCase(1.0,  10.0, 2.0,  TestName = "Triangle: A+C <= B (1+2<=10)")]
        [TestCase(10.0, 1.0,  2.0,  TestName = "Triangle: B+C <= A (1+2<=10)")]
        [TestCase(1.0,  1.0,  2.0,  TestName = "Triangle: вырожденный (1+1=2)")]
        public void ConstructorViolatingTriangleInequalityThrowsArgumentException(
            double sideA, double sideB, double sideC)
        {
            Assert.Throws<ArgumentException>(
                () => new Triangle(sideA, sideB, sideC));
        }

        // НЕГАТИВНЫЕ ТЕСТЫ — Validate через setter + Validate()

        [TestCase(-1.0,                    TestName = "Validate со стороной A = -1.0")]
        [TestCase(0.0,                     TestName = "Validate со стороной A = 0.0")]
        [TestCase(double.NaN,              TestName = "Validate со стороной A = NaN")]
        [TestCase(double.PositiveInfinity, TestName = "Validate со стороной A = +Infinity")]
        [TestCase(double.NegativeInfinity, TestName = "Validate со стороной A = -Infinity")]
        public void ValidateWithInvalidSideAThrowsArgumentException(double invalidSideA)
        {
            // Arrange
            var triangle = new Triangle();
            triangle.SideA = invalidSideA;
            triangle.SideB = 4.0;
            triangle.SideC = 5.0;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => triangle.Validate());
        }

        [TestCase(-1.0,                    TestName = "Validate со стороной B = -1.0")]
        [TestCase(0.0,                     TestName = "Validate со стороной B = 0.0")]
        [TestCase(double.NaN,              TestName = "Validate со стороной B = NaN")]
        [TestCase(double.PositiveInfinity, TestName = "Validate со стороной B = +Infinity")]
        [TestCase(double.NegativeInfinity, TestName = "Validate со стороной B = -Infinity")]
        public void ValidateWithInvalidSideBThrowsArgumentException(double invalidSideB)
        {
            // Arrange
            var triangle = new Triangle();
            triangle.SideA = 3.0;
            triangle.SideB = invalidSideB;
            triangle.SideC = 5.0;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => triangle.Validate());
        }

        [TestCase(-1.0,                    TestName = "Validate со стороной C = -1.0")]
        [TestCase(0.0,                     TestName = "Validate со стороной C = 0.0")]
        [TestCase(double.NaN,              TestName = "Validate со стороной C = NaN")]
        [TestCase(double.PositiveInfinity, TestName = "Validate со стороной C = +Infinity")]
        [TestCase(double.NegativeInfinity, TestName = "Validate со стороной C = -Infinity")]
        public void ValidateWithInvalidSideCThrowsArgumentException(double invalidSideC)
        {
            // Arrange
            var triangle = new Triangle();
            triangle.SideA = 3.0;
            triangle.SideB = 4.0;
            triangle.SideC = invalidSideC;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => triangle.Validate());
        }

        [Test(Description = "Validate: нарушение неравенства треугольника через setters")]
        public void ValidateViolatingTriangleInequalityThrowsArgumentException()
        {
            // Arrange
            var triangle = new Triangle();
            triangle.SideA = 1.0;
            triangle.SideB = 2.0;
            triangle.SideC = 10.0;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => triangle.Validate());
        }
    }
}
