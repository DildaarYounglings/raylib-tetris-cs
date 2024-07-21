using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UtilsClass.Utils;

namespace Tetris_Grid_Class;
public class Grid
{
    List<Color> colors = new();
    public int[,] grid = new int[20, 10];

    private int numRows, numCols, cellSize;
    public Grid()
    {
        numRows = 20; numCols = 10; cellSize = 30;
        Initialize();
        colors = GetCellColors();
    }
    public void Initialize()
    {
        for (int row = 0; row < numRows; row++)
        {
            for (int column = 0; column < numCols; column++)
            {
                grid[row, column] = 0;
            }
        }
    }
    public void Print()
    {
        for (int row = 0; row < numRows; row++)
        {
            for (int column = 0; column < numCols; column++)
            {
                Console.Write("" + grid[row, column]);
            }
        }
    }
    public bool IsRowFull(int row)
    {
        for(int column = 0; column < numCols; column++)
        {
            if(grid[row,column] == 0){
                return false;
            }
        }
        return true;
    }
    public void MoveRowDown(int row,int numRows)
    {
        for(int column = 0; column < numCols; column++)
        {
            grid[row + numRows,column] = grid[row,column];
            grid[row,column] = 0;
        }
    }
    public int ClearFullRows()
    {
        int completed = 0;
        for(int row = numRows-1; row>=0; row--)
        {
            if(IsRowFull(row))
            {
                ClearRow(row);
                completed++;
            }else if(completed > 0){
                MoveRowDown(row,completed);
            }
        }
        return completed;
    }
    public void ClearRow(int row)
    {
        for(int column = 0; column < numCols; column++)
        {
            grid[row,column] = 0;
        }
    }
    public bool IsCellOutside(int row, int column)
    {
        if(row >=0 && row<numRows && column>=0 && column < numCols)
        {
            return false;
        }
        return true;
    }
    public bool IsCellEmpty(int row, int column)
    {
        if (grid[row,column] == 0)
        {
            return true;
        }
        return false;
    }
    public void Draw()
    {
        for (int row = 0; row < numRows; row++)
        {
            for (int column = 0; column < numCols; column++)
            {
                int cellValue = grid[row, column];
                Raylib.DrawRectangle(column * cellSize + 1, row * cellSize + 1, cellSize - 1, cellSize - 1, colors[cellValue]);
            }
        }
    }
}
