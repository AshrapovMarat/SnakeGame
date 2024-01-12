using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
  /// <summary>
  /// Змея.
  /// </summary>
  class Snake
  {
    /// <summary>
    /// Rоординаты тела змеи.
    /// </summary>
    private List<Coordinate> snakeBodyCoordinates = new List<Coordinate>();
    public bool isSelfCollision { get; private set; }

    /// <summary>
    /// Конструктор.
    /// </summary>
    public Snake()
    {
      snakeBodyCoordinates.Add(new Coordinate(4, 5));
      snakeBodyCoordinates.Add(new Coordinate(3, 5));
    }

    /// <summary>
    /// Переместиться на один шаг.
    /// </summary>
    /// <param name="coordinate">На какую координату переместиться.</param>
    /// <param name="food">Объект еды.</param>
    public void MoveOneStep(Coordinate coordinate, Food food)
    {
      snakeBodyCoordinates.Insert(0, coordinate);
      if (food != null)
      {
        snakeBodyCoordinates.RemoveAt(snakeBodyCoordinates.Count - 1);
      }
    }

    /// <summary>
    /// Получение координат первых двух точек.
    /// </summary>
    /// <returns>Координаты первых двух точек.</returns>
    public (Coordinate, Coordinate) GetDrivingDirection()
    {
      return (snakeBodyCoordinates[0], snakeBodyCoordinates[1]);
    }

    /// <summary>
    /// Получить список координат тела змеи.
    /// </summary>
    /// <returns>Список координат тела змеи.</returns>
    public List<Coordinate> GetSnakeBody()
    {
      return snakeBodyCoordinates;
    }

    /// <summary>
    /// Обработка самостолкновений.
    /// </summary>
    public void SelfCollisionProcessing()
    {
      isSelfCollision = true;
    }
  }
}
