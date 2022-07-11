namespace MindBoxGeometry.Figures;

/// <summary>
/// Круг
/// </summary>
public sealed class Circle : Figure
{
    /// <summary>
    /// Радиус круга
    /// </summary>
    public double Radius { get; }

    /// <summary>
    /// Конструктор класса Круг
    /// </summary>
    /// <param name="radius">Радиус круга</param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public Circle(double radius)
    {
        if(radius < 0)
            throw new ArgumentOutOfRangeException("[Circle -> constructor] radius cannot be a negative!");
        
        Radius = radius;
    }
    
    /// <summary>
    /// Формула вычисления круга по радиусу -> pi * r ^ 2
    /// </summary>
    /// <returns>Площадь заданной фигуры</returns>
    protected override double CalculateSquare()
    {
        return Math.PI * Math.Pow(Radius, 2f);
    }
}