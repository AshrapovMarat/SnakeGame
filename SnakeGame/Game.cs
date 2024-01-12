using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
  public class Game
  {
    /// <summary>
    /// Объект змеи.
    /// </summary>
    private Snake snake;

    /// <summary>
    /// Объект контроллера змеи.
    /// </summary>
    private SnakeController snakeController;

    /// <summary>
    /// Объект игрового поля.
    /// </summary>
    private PlayingField playingField;

    /// <summary>
    /// Список координат.
    /// </summary>
    private List<Coordinate> snakeBodyCoordinates;

    /// <summary>
    /// Координаты пустого поля для еды.
    /// </summary>
    private Coordinate freeCellForfood;

    /// <summary>
    /// Счетчик очков.
    /// </summary>
    private ScoreCounter scoreCounter;

    /// <summary>
    /// Массив игрового поля.
    /// </summary>
    private string[,] field;

    /// <summary>
    /// Конструктор.
    /// </summary>
    public Game()
    {
      snake = new Snake();
      snakeController = new SnakeController(snake);
      playingField = new PlayingField(8, 18);
      scoreCounter = new ScoreCounter();
    }

    /// <summary>
    /// Начало игры.
    /// </summary>
    public void StartGame()
    {
      Food food = null;
      Console.CursorVisible = false;
      ConsoleKey key = new ConsoleKey();

      while (!snake.isSelfCollision)
      {
        Console.Clear();
        snakeBodyCoordinates = snake.GetSnakeBody();
        field = playingField.GetPlayingField();

        field[snakeBodyCoordinates[0].Y, snakeBodyCoordinates[0].X] = "+";
        for (int i = 1; i < snakeBodyCoordinates.Count; i++)
        {
          field[snakeBodyCoordinates[i].Y, snakeBodyCoordinates[i].X] = "0";
        }

        if (food == null)
        {
          food = new Food(field, scoreCounter);
          freeCellForfood = food.GetFreeCell();
        }

        field[freeCellForfood.X, freeCellForfood.Y] = "@";

        OutputPlayingField(field);
        Console.SetCursorPosition(25, 0);
        Console.WriteLine("Счет: " + scoreCounter.Score);

        Thread.Sleep(800);
        while (Console.KeyAvailable)
        {
          key = Console.ReadKey(true).Key;
        }

        switch (key)
        {
          case ConsoleKey.W:
          case ConsoleKey.UpArrow:
            snakeController.StepUp(field, ref food);
            break;
          case ConsoleKey.S:
          case ConsoleKey.DownArrow:
            snakeController.StepDown(field, ref food);
            break;
          case ConsoleKey.A:
          case ConsoleKey.LeftArrow:
            snakeController.StepLeft(field, ref food);
            break;
          case ConsoleKey.D:
          case ConsoleKey.RightArrow:
            snakeController.StepRigth(field, ref food);
            break;
          default:
            snakeController.RepeatPreviousMovement(field, ref food); 
            break;
        }
        key = 0;
      }

      field = playingField.GetPlayingField();
      GameOver(scoreCounter, field);
    }

    /// <summary>
    /// Вывод игрового поля.
    /// </summary>
    /// <param name="field">Игровое поле.</param>
    private void OutputPlayingField(string[,] field)
    {
      for (int i = 0; i < field.GetLength(0); i++)
      {
        for (int j = 0; j < field.GetLength(1); j++)
        {
          Console.Write(field[i, j]);
        }
        Console.WriteLine();
      }
    }

    /// <summary>
    /// Завершение игры.
    /// </summary>
    /// <param name="score">Счетчик.</param>
    /// <param name="field">Игровое поле.</param>
    private void GameOver(ScoreCounter score, string[,] field)
    {
      bool isWin = true;

      Console.Clear();

      foreach(var i in field)
      {
        if (i == " ")
        {
          isWin = false;
        }
      }

      if (isWin)
      {
        Console.WriteLine("Вы выиграли!!!");
      }
      else
      {
      Console.WriteLine($"Вы проиграли со счетом {score.Score}!");
      }
    }
  }
}
