using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
  public class Coordinate
  {
    /// <summary>
    /// Коорданата X.
    /// </summary>
    public int X { get; set; }
    /// <summary>
    /// Коорданата Y.
    /// </summary>
    public int Y { get; set; }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="x">Значение по X координате.</param>
    /// <param name="y">Значение по Y координате.</param>
    public Coordinate(int x, int y)
    {
      X = x;
      Y = y; 
    }
  }
}
