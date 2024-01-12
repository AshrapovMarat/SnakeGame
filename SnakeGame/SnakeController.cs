using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
  /// <summary>
  /// Класс для управлением змеей.
  /// </summary>
  class SnakeController
  {
    /// <summary>
    /// Экземпляр змеи.
    /// </summary>
    private Snake snake;

    /// <summary>
    /// Координаты следующего шага.
    /// </summary>
    private Coordinate snakeNextStep;

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="snake">Объект змеи.</param>
    public SnakeController(Snake snake)
    {
      this.snake = snake;
    }

    /// <summary>
    /// Перемещение змеи вверх на одну клетку в игровом поле.
    /// </summary>
    /// <param name="field">Игровое поле.</param>
    /// <param name="food">Объект еды.</param>
    public void StepUp(string[,] field, ref Food food)
    {
      //(Coordinate firstCoordinateSnake, Coordinate secondCoordinateSnake) = snake.GetDrivingDirection();
      //if (firstCoordinateSnake.Y - 1 != secondCoordinateSnake.Y)
      //{
      //  snakeNextStep = new Coordinate(firstCoordinateSnake.X, firstCoordinateSnake.Y - 1);
      //  snakeNextStep = HandleObstacleCollision(field, snakeNextStep, ref food);
      //  snake.MoveOneStep(snakeNextStep, food);
      //}
      //else
      //{
      //  RepeatPreviousMovement(field, ref food);
      //}
      MoveSnake(Direction.Up, field, ref food);
    }

    /// <summary>
    /// Перемещение змеи вниз на одну клетку в игровом поле.
    /// </summary>
    /// <param name="field">Игровое поле.</param>
    /// <param name="food">Объект еды.</param>
    public void StepDown(string[,] field, ref Food food)
    {
      //(Coordinate firstCoordinateSnake, Coordinate secondCoordinateSnake) = snake.GetDrivingDirection();
      //if (firstCoordinateSnake.Y + 1 != secondCoordinateSnake.Y)
      //{
      //  snakeNextStep = new Coordinate(firstCoordinateSnake.X, firstCoordinateSnake.Y + 1);
      //  snakeNextStep = HandleObstacleCollision(field, snakeNextStep, ref food);
      //  snake.MoveOneStep(snakeNextStep, food);
      //}
      //else
      //{
      //  RepeatPreviousMovement(field, ref food);
      //}
      MoveSnake(Direction.Down, field, ref food);
    }

    /// <summary>
    /// Перемещение змеи вправо на одну клетку в игровом поле.
    /// </summary>
    /// <param name="field">Игровое поле.</param>
    /// <param name="food">Объект еды.</param>
    public void StepRigth(string[,] field, ref Food food)
    {
      //(Coordinate firstCoordinateSnake, Coordinate secondCoordinateSnake) = snake.GetDrivingDirection();
      //if (firstCoordinateSnake.X + 1 != secondCoordinateSnake.X)
      //{
      //  snakeNextStep = new Coordinate(firstCoordinateSnake.X + 1, firstCoordinateSnake.Y);
      //  snakeNextStep = HandleObstacleCollision(field, snakeNextStep, ref food);
      //  snake.MoveOneStep(snakeNextStep, food);
      //}
      //else
      //{
      //  RepeatPreviousMovement(field, ref food);
      //}
      MoveSnake(Direction.Right, field, ref food);
    }

    /// <summary>
    /// Перемещение змеи влево на одну клетку в игровом поле.
    /// </summary>
    /// <param name="field">Игровое поле.</param>
    /// <param name="food">Объект еды.</param>
    public void StepLeft(string[,] field, ref Food food)
    {
      //(Coordinate firstCoordinateSnake, Coordinate secondCoordinateSnake) = snake.GetDrivingDirection();
      //if (firstCoordinateSnake.X - 1 != secondCoordinateSnake.X)
      //{
      //  snakeNextStep = new Coordinate(firstCoordinateSnake.X - 1, firstCoordinateSnake.Y);
      //  snakeNextStep = HandleObstacleCollision(field, snakeNextStep, ref food);
      //  snake.MoveOneStep(snakeNextStep, food);
      //}
      //else
      //{
      //  RepeatPreviousMovement(field, ref food);
      //}
      MoveSnake(Direction.Left, field, ref food);
    }

    /// <summary>
    /// Повторить предыдущие движение.
    /// </summary>
    /// <param name="field">Игровое поле.</param>
    /// <param name="food">Объект еды.</param>
    public void RepeatPreviousMovement(string[,] field, ref Food food)
    {
      (Coordinate firstCoordinateSnake, Coordinate secondCoordinateSnake) = snake.GetDrivingDirection();
      int newXCoordinate = (firstCoordinateSnake.X - secondCoordinateSnake.X);
      int newYCoordinate = (firstCoordinateSnake.Y - secondCoordinateSnake.Y);
      newXCoordinate = AdjustingCoordinateValue(newXCoordinate);
      newYCoordinate = AdjustingCoordinateValue(newYCoordinate);
      snakeNextStep = new Coordinate(newXCoordinate + firstCoordinateSnake.X, newYCoordinate + firstCoordinateSnake.Y);

      snakeNextStep = HandleObstacleCollision(field, snakeNextStep, ref food);
      snake.MoveOneStep(snakeNextStep, food);
    }

    /// <summary>
    /// Обработка столкновения с препятствием.
    /// </summary>
    /// <param name="field">Игровое поле.</param>
    /// <param name="snakeCoordinate">Координата змеи.</param>
    /// <param name="food"></param>
    /// <returns></returns>
    public Coordinate HandleObstacleCollision(string[,] field, Coordinate snakeCoordinate, ref Food food)
    {
      if (field[snakeCoordinate.Y, snakeCoordinate.X] == "#")
      {
        if (snakeCoordinate.Y == 0)
        {
          var nextStep = new Coordinate(snakeCoordinate.X, field.GetLength(0) - 2);
          //if (field[nextStep.Y, nextStep.X] == "@")
          //{
          //  food = food.DeleteFood();
          //}

          nextStep = CheckForFood(nextStep, field, ref food);
          return nextStep;
        }
        else if (snakeCoordinate.Y == field.GetLength(0) - 1)
        {
          var nextStep = new Coordinate(snakeCoordinate.X, 1);
          //if (field[nextStep.Y, nextStep.X] == "@")
          //{
          //  food = food.DeleteFood();
          //}

          nextStep = CheckForFood(nextStep, field, ref food);
          return nextStep;
        }
        else if (snakeCoordinate.X == 0)
        {
          var nextStep = new Coordinate(field.GetLength(1) - 2, snakeCoordinate.Y);
          //if (field[nextStep.Y, nextStep.X] == "@")
          //{
          //  food = food.DeleteFood();
          //}

          nextStep = CheckForFood(nextStep, field, ref food);
          return nextStep;
        }
        else if (snakeCoordinate.X == field.GetLength(1) - 1)
        {
          var nextStep = new Coordinate(1, snakeCoordinate.Y);
          //if (field[nextStep.Y, nextStep.X] == "@")
          //{
          //  food = food.DeleteFood();
          //}

          nextStep = CheckForFood(nextStep, field, ref food);
          return nextStep;
        }
        else
        {
          return snakeCoordinate;
        }
      }
      else if (field[snakeCoordinate.Y, snakeCoordinate.X] == "@")
      {
        food = food.DeleteFood();
        return snakeCoordinate;
      }
      else if (field[snakeCoordinate.Y, snakeCoordinate.X] == "0")
      {
        snake.SelfCollisionProcessing();
        return snakeCoordinate;
      }
      else
      {
        return snakeCoordinate;
      }
    }

    /// <summary>
    /// Корректировка значений координат.
    /// </summary>
    /// <param name="value">Значение координаты змеи.</param>
    /// <returns>Корректное значение координаты.</returns>
    private int AdjustingCoordinateValue(int value)
    {
      if (value < -1)
      {
        return 1;
      }
      else if (value > 1)
      {
        return -1;
      }
      else if (value == 0)
      {
        return 0;
      }
      else
      {
        return value;
      }
    }

    /// <summary>
    /// перемещение змеи.
    /// </summary>
    /// <param name="direction"></param>
    /// <param name="field"></param>
    /// <param name="food"></param>
    public void MoveSnake(Direction direction, string[,] field, ref Food food)
    {
      (Coordinate firstCoordinateSnake, Coordinate secondCoordinateSnake) = snake.GetDrivingDirection();
      var newCoordinateSnake = new Coordinate(firstCoordinateSnake.X, firstCoordinateSnake.Y); 
      if (direction == Direction.Up || direction == Direction.Down)
      {
        if (direction == Direction.Up)
        {
          newCoordinateSnake.Y--;
          SnakeMovementProcessing(newCoordinateSnake, secondCoordinateSnake, field, ref food);
        }
        else if (direction == Direction.Down)
        {
          newCoordinateSnake.Y++;
          SnakeMovementProcessing(newCoordinateSnake, secondCoordinateSnake, field, ref food);
        }
      }
      else if (direction == Direction.Right || direction == Direction.Left)
      {
        if (direction == Direction.Right)
        {
          newCoordinateSnake.X++;
          SnakeMovementProcessing(newCoordinateSnake, secondCoordinateSnake, field, ref food);
        }
        else if (direction == Direction.Left)
        {
          newCoordinateSnake.X--;
          SnakeMovementProcessing(newCoordinateSnake, secondCoordinateSnake, field, ref food);
        }
      }
    }

    /// <summary>
    /// Обработка перемещения змеи.
    /// </summary>
    /// <param name="firstCoordinateSnake"></param>
    /// <param name="secondCoordinateSnake"></param>
    /// <param name="field"></param>
    /// <param name="food"></param>
    private void SnakeMovementProcessing(Coordinate firstCoordinateSnake, Coordinate secondCoordinateSnake, string[,] field, ref Food food)
    {
      if (firstCoordinateSnake.Y != secondCoordinateSnake.Y && firstCoordinateSnake.X != secondCoordinateSnake.X)
      {
        snakeNextStep = new Coordinate(firstCoordinateSnake.X, firstCoordinateSnake.Y);
        snakeNextStep = HandleObstacleCollision(field, snakeNextStep, ref food);
        snake.MoveOneStep(snakeNextStep, food);
      }
      else
      {
        RepeatPreviousMovement(field, ref food);
      }
    }

    private Coordinate CheckForFood(Coordinate nextStep, string[,] field, ref Food food)
    {
      //var nextStep = new Coordinate(1, snakeCoordinate.Y);
      if (field[nextStep.Y, nextStep.X] == "@")
      {
        food = food.DeleteFood();
      }
      return nextStep;
    }
  }
}
