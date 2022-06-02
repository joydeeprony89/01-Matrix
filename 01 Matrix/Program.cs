using System;
using System.Collections.Generic;

namespace _01_Matrix
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Hello World!");
//    Input: mat = [[0, 0, 0],[0,1,0],[1,1,1]]
//Output:[[0,0,0],[0,1,0],[1,2,1]]
    }
  }

  public class Solution
  {
    public int[][] UpdateMatrix(int[][] mat)
    {
      // will be performming BFS , here instead of finding the nearest 0 will find the 1 from a 0 value
      // when we found a 0 we will see all the 4 directions, if we found any 1 then we will add 1 as the level.
      // now for the newly found 1 cells will add them to Queue and look for 4 directions , this time the level will be set as next level i.e 2 and so on

      if (mat == null || mat.Length == 0) return mat;
      List<(int, int)> directions = new List<(int, int)>();
      directions.Add((0, 1));
      directions.Add((0, -1));
      directions.Add((1, 0));
      directions.Add((-1, 0));

      Queue<(int, int)> q = new Queue<(int, int)>();
      // first add all the 0 value cells in the Q for BFS and also marked them as visited
      HashSet<(int, int)> visited = new HashSet<(int, int)>();
      for (int i = 0; i < mat.Length; i++)
      {
        for (int j = 0; j < mat[0].Length; j++)
        {
          if (mat[i][j] == 0)
          {
            q.Enqueue((i, j));
            visited.Add((i, j));
          }
        }
      }

      int level = 0;
      while (q.Count > 0)
      {
        int size = q.Count;
        level++;
        while (size-- > 0)
        {
          var (i, j) = q.Dequeue();
          foreach (var (r, c) in directions)
          {
            var newi = i + r;
            var newj = j + c;
            // check the boundary and not visited
            if (newi < 0 || newj < 0 || newi >= mat.Length || newj >= mat[0].Length || visited.Contains((newi, newj))) continue;
            q.Enqueue((newi, newj));
            visited.Add((newi, newj));
            mat[newi][newj] = level;
          }
        }
      }

      return mat;
    }
  }
}
