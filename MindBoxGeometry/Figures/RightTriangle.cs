namespace MindBoxGeometry.Figures;

/// <summary>
/// Прямоугольный треугольник
/// Площадь можно вычислить, если:
///  * Известны оба катета -> Площадь прямоугольного треугольника равна половине произведения его катетов;
///  * Известны гипотенуза и высота -> Площадь прямоугольного треугольника равна половине произведения гипотенузы на высоту, проведенную к гипотенузе.
/// </summary>
public sealed class RightTriangle : Figure
{
    /// <summary>
    /// Один катет — это высота проведенная ко второму катету.
    /// </summary>
    public double CathetusHeight { get; }

    /// <summary>
    /// Нижний второй катет
    /// </summary>
    public double Cathetus { get; }

    /// <summary>
    /// Конструктор прямоугольного треугольника
    /// </summary>
    /// <param name="cathetus">Нижний катет</param>
    /// <param name="cathetusHeight">Катет, как высота проведенная к нижнему катету</param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public RightTriangle(double cathetus, double cathetusHeight)
    {
        if (cathetus < 0)
            throw new ArgumentOutOfRangeException("[RightTriangle -> constructor] cathetus cannot be a negative!");
        
        if (cathetusHeight < 0)
            throw new ArgumentOutOfRangeException("[RightTriangle -> constructor] cathetus as height cannot be a negative!");
        
        Cathetus = cathetus;
        CathetusHeight = cathetusHeight;
    }

    /// <summary>
    /// Площадь прямоугольного треугольника равна половине произведения его катетов
    /// </summary>
    /// <returns>Площадь заданной фигуры</returns>
    protected override double CalculateSquare()
    {
        return (Cathetus * CathetusHeight) / 2f;
    }
}