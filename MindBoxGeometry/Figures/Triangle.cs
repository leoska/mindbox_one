namespace MindBoxGeometry.Figures;

/// <summary>
/// Класс треугольника
/// Площадь треугольника можно вычислить множествами способами в зависимости от известных входных данных.
/// В данном классе приводится пример реализации:
///  * Через основание и высоту;
///  * Через 3 стороны по формуле Герона.
/// </summary>
public sealed class Triangle : Figure
{
    /// <summary>
    /// Тип треугольника
    /// </summary>
    public TriangleTypes Type { get; } 
    
    /// <summary>
    /// Первая сторона
    /// </summary>
    public double FirstSide { get; }
    
    /// <summary>
    /// Вторая сторона
    /// </summary>
    public double SecondSide { get; }
    
    /// <summary>
    /// Третья сторона
    /// </summary>
    public double ThirdSide { get; }
    
    /// <summary>
    /// Основание треугольника
    /// </summary>
    public double Base { get; }
    
    /// <summary>
    /// Высота треугольника
    /// </summary>
    public double Height { get; }

    /// <summary>
    /// Конструктор треугольника через 3 стороны
    /// </summary>
    /// <param name="firstSide">Первая сторона треугольника</param>
    /// <param name="secondSide">Вторая сторона треугольника</param>
    /// <param name="thirdSide">Третья сторона треугольника</param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public Triangle(double firstSide, double secondSide, double thirdSide)
    {
        if (firstSide < 0 || secondSide < 0 || thirdSide < 0)
            throw new ArgumentOutOfRangeException("[Triangle -> constructor] Sides cannot be a negative!");
        
        if (firstSide > secondSide + thirdSide)
            throw new ArgumentOutOfRangeException("[Triangle -> constructor] Incorrect sides! firstSide more that sum of two others.");
        
        if (secondSide > firstSide + thirdSide)
            throw new ArgumentOutOfRangeException("[Triangle -> constructor] Incorrect sides! secondSide more that sum of two others.");
        
        if (thirdSide > firstSide + secondSide)
            throw new ArgumentOutOfRangeException("[Triangle -> constructor] Incorrect sides! thirdSide more that sum of two others.");
        
        FirstSide = firstSide;
        SecondSide = secondSide;
        ThirdSide = thirdSide;

        Type = TriangleTypes.ThreeSides;
    }

    /// <summary>
    /// Конструктор треугольника через основание и высоту
    /// </summary>
    /// <param name="baseTriagnle">Основание треугольника</param>
    /// <param name="height">Высота треугольника</param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public Triangle(double baseTriagnle, double height)
    {
        if (baseTriagnle < 0)
            throw new ArgumentOutOfRangeException("[Triangle -> constructor] baseTriagnle cannot be a negative!");
        
        if (height < 0)
            throw new ArgumentOutOfRangeException("[Triangle -> constructor] height cannot be a negative!");

        Base = baseTriagnle;
        Height = height;

        Type = TriangleTypes.BaseHeight;
    }

    /// <summary>
    /// Вычисление площади треугольника в зависимости от его типа
    /// </summary>
    /// <returns>Площадь заданной фигуры</returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    protected override double CalculateSquare()
    {
        switch (Type)
        {
            case TriangleTypes.BaseHeight:
                return 0.5f * Base * Height;

            case TriangleTypes.ThreeSides:
                var halfPerimeter = (FirstSide + SecondSide + ThirdSide) / 2f;
                var firstCoef = halfPerimeter - FirstSide;
                var secondCoef = halfPerimeter - SecondSide;
                var thirdCoef = halfPerimeter - ThirdSide;
                return Math.Sqrt(halfPerimeter * firstCoef * secondCoef * thirdCoef);  

            default:
                throw new ArgumentOutOfRangeException($"[Triangle -> type] Incorrect triangle type [{Type.ToString()}]!");
        }
    }

    /// <summary>
    /// Проверка на прямоугольный треугольник
    /// Если выполняется теорема Пифагора квадрат большей стороны равен сумме квадратов двух других сторон
    /// </summary>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public bool CheckIsRightAngled()
    {
        if (Type != TriangleTypes.ThreeSides)
            throw new Exception("[Triangle -> CheckIsRightAngled] Triangle must be type of with three sides!");
        
        var maxSide = new [] { FirstSide, SecondSide, ThirdSide }.Max();
        
        var maxSideSum = Math.Pow(maxSide, 2f) + Math.Pow(maxSide, 2f);
        var firstSqr = Math.Pow(FirstSide, 2f);
        var secondSqr = Math.Pow(SecondSide, 2f);
        var thirdSqr = Math.Pow(ThirdSide, 2f);
        
        var TOLERANCE = 0.000000001;

        return Math.Abs(maxSideSum - (firstSqr + secondSqr + thirdSqr)) < TOLERANCE;
    }
    
    public enum TriangleTypes
    {
        BaseHeight,
        ThreeSides
    }
}