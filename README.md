# Mindbox test
## Площадь фигуры
Библиотека поставляет интерфейс IFigureWithArea и классы Circle, Triangle и FigureWithoutType<TFigureProperties>.
Для быстрого подсчета площади круга или треугольника без создания экземляра воспользуйтесь статическими методами CalculateArea в классах Circle и Triangle соответственно.
Библиотека соответствует следующим условиям:
1. Легкость добавления других фигур
Фигуру можно создать, используя экземляр FigureWithoutType. Для быстрого прототипирования можно также унаследоваться от этого же класса. В сложных сценариях, можно реализовать IFigureWithArea напрямую. Для примеров, обращайтесь ниже.
2. Вычисление площади фигуры без знания типа фигуры
Для этого создан класс FigureWithoutType. Достаточно передать в конструктор метод, вычисляющий площадь, и свойства фигуры, необходимые для подсчета.
3. Проверка на то, является ли треугольник прямоугольным
В классе Triangle реализовано свойство IsRightAngled, а также, для удобства быстрого подсчета, добавлен статический метод CheckIsRightAngled.
### FigureWithoutType<TFigureProperties>
Класс FigureWithoutType<TFigureProperties> очень удобно использовать для создания фигур "на лету":
```
IFigureWithArea CreateSquare(double side) => new FigureWithoutType<double>(s => s * s, side);
```
Если необходимо выбросить исключение при передачи неверных данных, то можно использовать конструктор принимающий функцию проверки:
```
IFigureWithArea CreateSquare(double side) =>
        new FigureWithoutType<double>
        (s => { if (s <= 0) throw new ArgumentOutOfRangeException(); }, s => s * s, side);
```
Для передачи нескольких аргументов, можно воспользоваться кортежами.
```
public IFigureWithArea CreateRectangle(double firstSide, double secondSide)
{
    Console.WriteLine($"Создаю прямоугольник со сторонами {firstSide} и {secondSide} ...");
    try
    {
        var rect = new FigureWithoutType<(double first, double second)>
            (t => { if (t.first <= 0 || t.second <= 0) throw new ArgumentOutOfRangeException(); },
            t => t.first * t.second, (firstSide, secondSide));
        Console.WriteLine("Прямоугольник создан.");
        Console.WriteLine("Первая сторона прямоугольника: " + rect.FigureArgs.first);
        Console.WriteLine("Вторая сторона прямоугольника: " + rect.FigureArgs.second);
        Console.WriteLine("Если увеличить вторую сторону прямоугольника в два раза, то площадь будет равна "
            + rect.CalculateAreaFunc((firstSide, secondSide * 2)));
        return rect;
    }
    catch (ArgumentOutOfRangeException)
    {
        Console.WriteLine("Переданы неверные данные!");
        throw;
    }
}
```
Класс FigureWithoutType можно использовать для быстрого прототипирования (как в примере ниже), но рекомендуется реализовывать IFigureWithArea напрямую, чтобы не вносить лишнюю сложность, например, не использовать свойство FigureProperties, а использовать свойства класса, такое как Radius в классе Circle или свойства сторон в классе Triangle.
```
public class Rectangle : FigureWithoutType<(double FirstSide, double SecondSide)>
{
    public Rectangle(double firstSide, double secondSide)
        : base(t => { if (t.FirstSide <= 0 || t.SecondSide <= 0) throw new ArgumentOutOfRangeException(); },
        t => t.FirstSide * t.SecondSide, (firstSide, secondSide))
    { }
}
```