using Model;
using NUnit.Framework;

namespace ModelTests
{
    /// <summary>
    /// Класс для тестирования класса ShapeGenerator.
    /// </summary>
    public class ShapeGeneratorTests
    {
        // ПОЗИТИВНЫЕ ТЕСТЫ

        [Test(Description = "GetRandomCircle возвращает Circle с положительным радиусом")]
        public void GetRandomCircleReturnsCircleWithPositiveRadius()
        {
            // Act
            var circle = ShapeGenerator.GetRandomCircle();

            // Assert
            Assert.IsNotNull(circle);
            Assert.IsInstanceOf<Circle>(circle);
            Assert.Greater(circle.Radius, 0);
        }

        [Test(Description = "GetRandomRectangle возвращает Rectangle с положительными сторонами")]
        public void GetRandomRectangleReturnsRectangleWithPositiveSides()
        {
            // Act
            var rect = ShapeGenerator.GetRandomRectangle();

            // Assert
            Assert.IsNotNull(rect);
            Assert.IsInstanceOf<Rectangle>(rect);
            Assert.Greater(rect.Width, 0);
            Assert.Greater(rect.Height, 0);
        }

        [Test(Description = "GetRandomTriangle возвращает Triangle с валидными сторонами")]
        public void GetRandomTriangleReturnsTriangleWithValidSides()
        {
            // Act
            var triangle = ShapeGenerator.GetRandomTriangle();

            // Assert
            Assert.IsNotNull(triangle);
            Assert.IsInstanceOf<Triangle>(triangle);
            Assert.Greater(triangle.SideA, 0);
            Assert.Greater(triangle.SideB, 0);
            Assert.Greater(triangle.SideC, 0);
            // Проверка неравенства треугольника
            Assert.IsTrue(triangle.SideA + triangle.SideB > triangle.SideC);
            Assert.IsTrue(triangle.SideA + triangle.SideC > triangle.SideB);
            Assert.IsTrue(triangle.SideB + triangle.SideC > triangle.SideA);
        }

        [Test(Description = "GetRandomShape возвращает ShapeBase (одну из трёх фигур)")]
        public void GetRandomShapeReturnsShapeBase()
        {
            // Вызываем многократно, чтобы покрыть все ветки switch
            bool hasCircle = false;
            bool hasRectangle = false;
            bool hasTriangle = false;

            for (int i = 0; i < 300; i++)
            {
                var shape = ShapeGenerator.GetRandomShape();
                Assert.IsNotNull(shape);
                Assert.IsInstanceOf<ShapeBase>(shape);

                if (shape is Circle)    hasCircle    = true;
                if (shape is Rectangle) hasRectangle = true;
                if (shape is Triangle)  hasTriangle  = true;

                if (hasCircle && hasRectangle && hasTriangle)
                    break;
            }

            Assert.IsTrue(hasCircle,    "GetRandomShape никогда не вернул Circle");
            Assert.IsTrue(hasRectangle, "GetRandomShape никогда не вернул Rectangle");
            Assert.IsTrue(hasTriangle,  "GetRandomShape никогда не вернул Triangle");
        }

        [Test(Description = "GetRandomShape возвращает фигуру с положительной площадью")]
        public void GetRandomShapeReturnsShapeWithPositiveArea()
        {
            // Act
            var shape = ShapeGenerator.GetRandomShape();

            // Assert
            Assert.Greater(shape.CalculateArea(), 0);
        }
    }
}
