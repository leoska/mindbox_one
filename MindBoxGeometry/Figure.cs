namespace MindBoxGeometry;

/// <summary>
/// Абстрактный класс фигуры
/// Для наследников требуется перегрузить метод CalculateSquare с описанием необходимой формулы вычисления фигуры
/// </summary>
public abstract class Figure
{
    /// <summary>
    /// Возвращаем площадь фигуры
    /// </summary>
    public double Square => CalculateSquare();

    /// <summary>
    /// Перегружаемая функция для вычисления площади фигуры
    /// </summary>
    /// <returns>Площадь заданной фигуры</returns>
    protected abstract double CalculateSquare();
}
