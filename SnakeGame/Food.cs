using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
  internal class Food
  {
    /// <summary>
    /// Координаты еды.
    /// </summary>
    private Coordinate foodCoordinate;

    /// <summary>
    /// Список свободных ячеек на игровом поле.
    /// </summary>
    private List<Coordinate> freeCells;

    /// <summary>
    /// Игровое поле.
    /// </summary>
    private string[,] field;

    /// <summary>
    /// Счетчик очков.
    /// </summary>
    private ScoreCounter scoreCounter;

    /// <summary>
    /// Флаг, указывающий была ли съедена еда.
    /// </summary>
    public bool isFoodEaten { get; private set; } = false;

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="field">Игровое поле.</param>
    /// <param name="scoreCounter">Счетчик очков.</param>
    public Food(string[,] field, ScoreCounter scoreCounter)
    {
      this.field = field;
      freeCells = new List<Coordinate>();
      this.scoreCounter = scoreCounter;
    }

    /// <summary>
    /// Получить координаты свободной ячейки.
    /// </summary>
    /// <returns>Координаты свободной ячейки.</returns>
    public Coordinate GetFreeCell()
    {
      for (int i = 0; i < field.GetLength(0); i++)
      {
        for(int j = 0; j < field.GetLength(1); j++)
        {
          if (field[i, j] == " ")
          {
            freeCells.Add(new Coordinate(i, j));
          }
        }
      }

      Random random = new Random();
      foodCoordinate = freeCells[random.Next(0, freeCells.Count)];
      return foodCoordinate;
    }

    /// <summary>
    /// Удалить еду.
    /// </summary>
    /// <returns>Null</returns>
    public Food DeleteFood()
    {
      field[foodCoordinate.X, foodCoordinate.Y] = " ";
      scoreCounter.AddPoint();
      isFoodEaten = true;
      return null;
    }
  }
}
