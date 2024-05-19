using System;
using System.Collections.Generic;
using Helpers;
using UnityEngine;

namespace BuilderSystem
{
   public class Grid
   {
      public event Action GridChanged = delegate { };
      private int _height, _width;

      private Dictionary<Vector2Int, Cell> _cells = new();

      public Grid(int height, int width)
      {
         _height = height;
         _width = width;
         
         InitCells();
      }
      
      private void InitCells()
      {
         for (int i = 0; i < _height; i++) {
            for (int j = 0; j < _width; j++)
            {
               Vector2Int cellVector = new Vector2Int(i, j);
               Cell cell = new Cell();
               
               _cells.Add(cellVector, cell);
               
            }
         }
      }

      private void Invoke()
      {
         GridChanged.Invoke();
      }

      public void UpdateCell(Vector2Int cellVector, Cell newCell)
      {
         _cells[cellVector] = newCell;
         Invoke();
      }

      public Cell GetCellAtVector(Vector2Int cellVector)
      {
         return _cells[cellVector];
      }

   }
}
