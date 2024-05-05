using BlockClass;
using GridClass;
using Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using PositionClass;

namespace Tetris_Game_Class;

public class TetrisGame
{
    public bool gameOver;
    public Grid grid;
    List<Block> blocks;
    Block currentBlock, nextBlock;
    public TetrisGame()
    {
        grid = new Grid();
        blocks = GetAllBlocks();
        currentBlock= GetRamdomBlock();
        nextBlock = GetRamdomBlock();
        gameOver = false;
    }
    public Block GetRamdomBlock()
    {
        if(blocks.Count <= 0)
        {
            blocks = GetAllBlocks();
        }
        int randomIndex = new Random().Next(0,blocks.Count);
        Block block = blocks[randomIndex];
        blocks.RemoveRange(0 + randomIndex,1);
        return block;

    }
    public bool IsBlockOutside()
    {
        List<Position> tiles = currentBlock.GetCellPositions();
        foreach (Position item in tiles)
        {
            if (grid.IsCellOutside(item.row, item.column))
            {
                return true;
            }
        }
        return false;
    }
    public void HandleInput()
    {
        int keyPressed = Raylib.GetKeyPressed();
        if(gameOver && keyPressed != 0){
            gameOver = false;
            Reset();
        }
        switch (keyPressed)
        {
            case (int)KeyboardKey.Left:
                MoveBlockLeft();
                break;
            case (int)KeyboardKey.Right:
                MoveBlockRight();
                break;
            case (int)KeyboardKey.Down:
                MoveBlockDown();
                break;
            case (int)KeyboardKey.Up:
                RotateBlock();
                break;
            default:
                break;

        }
    }

    private void Reset()
    {
        grid.Initialize();
        blocks = GetAllBlocks();
        nextBlock = GetRamdomBlock();
    }

    public void MoveBlockLeft()
    {
        if(!gameOver)
        {
            currentBlock.Move(0, -1);
            if (IsBlockOutside() || BlockFits() == false)
            {
                currentBlock.Move(0, 1);
            }

        }
    }
    public void MoveBlockRight()
    {
        if(!gameOver){
            currentBlock.Move(0, 1);
            if (IsBlockOutside() || BlockFits() == false)
            {
                currentBlock.Move(0, -1);
            }
        }
    }
    public void MoveBlockDown()
    {
        if(!gameOver){
            currentBlock.Move(1,0);
            if (IsBlockOutside() || BlockFits() == false)
            {
                currentBlock.Move(-1, 0);
                LockBlock();
            }
        }
    }
    public void LockBlock()
    {
        List<Position> tiles = currentBlock.GetCellPositions();
        foreach (var item in tiles)
        {
            grid.grid[item.row, item.column] = currentBlock.id;
        }
        currentBlock = nextBlock;
        if(BlockFits() == false)
        {
            gameOver = true;
        }
        nextBlock = GetRamdomBlock();
        grid.ClearFullRows();
    }
    public bool BlockFits()
    {
        List<Position> tiles = currentBlock.GetCellPositions();
        foreach (Position item in tiles)
        {
            if(grid.IsCellEmpty(item.row,item.column) == false)
            {
                return false;
            }
        }
        return true;
    }
    public void RotateBlock()
    {
        currentBlock.Rotate();
        if (IsBlockOutside())
        {
            currentBlock.UndoRotation();
        }
    }
    public void Draw()
    {
        grid.Draw();
        currentBlock.Draw();
    }
    static List<Block> GetAllBlocks()
    {
        return new List<Block>() { new IBlock(), new JBlock(), new OBlock(), new SBlock(), new TBlock(), new ZBlock() };
    }
}
