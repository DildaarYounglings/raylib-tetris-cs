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
    public Grid grid;
    List<Block> blocks;
    Block currentBlock, nextBlock;
    public TetrisGame()
    {
        grid = new Grid();
        blocks = GetAllBlocks();
        currentBlock= GetRamdomBlock();
        nextBlock = GetRamdomBlock();
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
    public void MoveBlockLeft()
    {
        currentBlock.Move(0, -1);
        if (IsBlockOutside())
        {
            currentBlock.Move(0, 1);
        }
    }
    public void MoveBlockRight()
    {
        currentBlock.Move(0, 1);
        if (IsBlockOutside())
        {
            currentBlock.Move(0, -1);
        }
    }
    public void MoveBlockDown()
    {
        currentBlock.Move(1,0);
        if (IsBlockOutside())
        {
            currentBlock.Move(-1, 0);
            LockBlock();
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
        nextBlock = GetRamdomBlock();
    }
    public bool BlockFits()
    {

        return false;
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
