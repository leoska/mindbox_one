using System;
using NUnit.Framework;
using MindBoxGeometry.Figures;

namespace MindBoxGeometryTests;

[TestFixture]
public class Tests
{
    #region Circle

    /// <summary>
    /// Тест на отрицательный радиус круга
    /// </summary>
    [Test]
    public void CircleNegativeRadiusTest()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Circle(-2f));
    }

    /// <summary>
    /// Тестируем вычисление площади круга
    /// </summary>
    [Test]
    public void CircleCalcSquareTest()
    {
        Assert.AreEqual(Math.PI, (new Circle(1f).Square));
        Assert.AreEqual(Math.PI * Math.Pow(2f, 2), (new Circle(2f).Square));
    }

    #endregion

    #region RightTriangle

    /// <summary>
    /// Тестируем отрицательные стороны прямоугольного треугольника
    /// </summary>
    [Test]
    public void RightTriangleNegativeSidesTest()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new RightTriangle(-1f, 0f));
        Assert.Throws<ArgumentOutOfRangeException>(() => new RightTriangle(0f, -1f));
    }

    /// <summary>
    /// Тестируем вычисление площади прямоугольного треугольника
    /// </summary>
    [Test]
    public void RightTriangleCalcSquareTest()
    {
        Assert.AreEqual(6f, (new RightTriangle(4f, 3f)).Square);
    }

    #endregion

    #region Triangle

    /// <summary>
    /// Тестируем отрицательные стороны треугольника
    /// </summary>
    [Test]
    public void TriangleNegativeSidesTest()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(-1f, 0f, 0f));
        Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(0f, -1f, 0f));
        Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(0f, 0f, -1f));
    }

    /// <summary>
    /// Тестируем отрицательное основание и высоту треугольника
    /// </summary>
    [Test]
    public void TriangleNegativeBaseHeightTest()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(-1f, 0f));
        Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(0f, -1f));
    }

    /// <summary>
    /// Тестируем вычисление площади треугольника
    /// </summary>
    [Test]
    public void TriangleCalcSquareTest()
    {
        Assert.AreEqual(6f, (new Triangle(4f, 3f)).Square);
        Assert.AreEqual(6f, (new Triangle(3f, 4f, 5f)).Square);
    }

    /// <summary>
    /// Тестируем определение на прямоугольный треугольник
    /// </summary>
    [Test]
    public void TriangleIsRightAngleTest()
    {
        Assert.AreEqual(true, (new Triangle(3f, 4f, 5f)).CheckIsRightAngled());
    }
    
    /// <summary>
    /// Тестируем определение на НЕ прямоугольный треугольник
    /// </summary>
    [Test]
    public void TriangleIsNotRightAngleTest()
    {
        Assert.AreEqual(false, (new Triangle(6f, 2f, 7f)).CheckIsRightAngled());
    }

    /// <summary>
    /// Тестируем невозможность определение на прямоугольный треугольник без заданных сторон
    /// </summary>
    [Test]
    public void TriangleIsRightAngleExceptTest()
    {
        Assert.Throws<Exception>(() => (new Triangle(4f, 3f)).CheckIsRightAngled());
    }

    #endregion
}