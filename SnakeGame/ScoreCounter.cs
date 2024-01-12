using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
  /// <summary>
  /// Счетчик очков.
  /// </summary>
  public class ScoreCounter
  {
    /// <summary>
    /// Текущее количество очков.
    /// </summary>
    public int Score {  get; private set; }

    /// <summary>
    /// Увеличить количество очков на 1.
    /// </summary>
    public void AddPoint()
    {
      Score++;
    }
  }
}
