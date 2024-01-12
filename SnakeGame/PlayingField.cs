using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
  /// <summary>
  /// Игровое поле.
  /// </summary>
  public class PlayingField
  {
    /// <summary>
    /// Игровое поле.
    /// </summary>
    private string[,] field;

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="xFieldSize">Значение по X координате.</param>
    /// <param name="yFieldSize">Значение по Y координате.</param>
    public PlayingField(int xFieldSize, int yFieldSize)
    {
      field = new string[xFieldSize + 1, yFieldSize + 1];
      for (int i = 0; i < field.GetLength(0); i++)
      {
        for (int j = 0; j < field.GetLength(1); j++)
        {
          if (i == 0 || j == 0 || i == field.GetLength(0) - 1 || j == field.GetLength(1) - 1)
          {
            field[i, j] = "#";
          }
          else if (i != 0 || j != 0 || i != field.GetLength(0) || j != field.GetLength(1))
          {
            field[i, j] = " ";
          }
        }
      }
    }

    /// <summary>
    /// Получить игровое поле.
    /// </summary>
    /// <returns></returns>
    public string[,] GetPlayingField()
    {
      return (string[,])field.Clone();
    }
  }
}
