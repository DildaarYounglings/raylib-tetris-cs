using BlockClass;
using PositionClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blocks;

public class LBlock : Block
{
    public LBlock()
    {
        id = 1;
        cells[0] = new List<Position>(){new Position(0,2),new Position(1,0),new Position(1,1),new Position(1,2),};
        cells[1] = new List<Position>() {new Position(0,1), new Position(1, 1), new Position(2, 1), new Position(2, 2),};
        cells[2] = new List<Position>() { new Position(1,0), new Position(1, 1),new Position(1,2),new Position(2,0),};
        cells[3] = new List<Position>() { new Position(0, 0), new Position(0, 1), new Position(1, 1), new Position(2,1)};
        Move(0,3);
    }
}
public class JBlock : Block
{
    public JBlock()
    {
        id = 2;
        cells[0] = new List<Position>() { new Position(0, 0), new Position(1, 0), new Position(1, 1), new Position(1, 2)};
        cells[1] = new List<Position>() { new Position(0, 1), new Position(0,2), new Position(1, 1), new Position(2, 1)};
        cells[2] = new List<Position>() { new Position(1, 0), new Position(1, 1), new Position(1, 2), new Position(2,2)};
        cells[3] = new List<Position>() { new Position(0,1), new Position(1,1), new Position(2,0), new Position(2, 1)};
        Move(0,3);
    }

}
public class IBlock : Block
{
    public IBlock()
    {
        id = 3;
        cells[0] = new List<Position>() { new Position(1, 0), new Position(1, 1), new Position(1, 2), new Position(1, 3) };
        cells[1] = new List<Position>() { new Position(0,2), new Position(1, 2),new Position(2,2),new Position(3,2)};
        cells[2] = new List<Position>() { new Position(2, 0), new Position(2,1), new Position(2,2),new Position(2,3)};
        cells[3] = new List<Position>() { new Position(0,1), new Position(1,1), new Position(2,1), new Position(3,1) };
        Move(-1,3);
    }
}
public class OBlock : Block
{
    public OBlock()
    {
        id = 4;
        cells[0] = new List<Position>() {new Position(0,0),new Position(0,1),new Position(1,0),new Position(1,1)};
        cells[1] = new List<Position>() {new Position(0, 0), new Position(0, 1), new Position(1, 0), new Position(1, 1)};
        cells[2] = new List<Position>() {new Position(0, 0), new Position(0, 1), new Position(1, 0), new Position(1, 1)};
        cells[3] = new List<Position>() {new Position(0, 0), new Position(0, 1), new Position(1, 0), new Position(1, 1)};
        Move(0,4);
    }
}
public class SBlock : Block 
{ 
    public SBlock()
    {
        id = 5;
        cells[0] = new List<Position>() { new Position(0,1), new Position(0,2), new Position(1,0),new Position(1,1)};
        cells[1] = new List<Position>() { new Position(0,1), new Position(1,1), new Position(1,2), new Position(2,2)};
        cells[2] = new List<Position>() { new Position(1,1),new Position(1,2),new Position(2,0),new Position(2,1)};
        cells[3] = new List<Position>() { new Position(0,0), new Position(1,0),new Position(1,1),new Position(2,1)};
        Move(0,3);

    }

}
public class TBlock : Block
{
    public TBlock()
    {
        id = 6;
        cells[0] = new List<Position>() {new(0, 1),new(1,0),new(1,1),new(1,2)};
        cells[1] = new List<Position>() {new(0, 1),new(1,1),new(1,2),new(2,1)};
        cells[2] = new List<Position>() {new(1,0),new(1,1),new(1,2),new(2,1)};
        cells[3] = new List<Position>() {new(0, 1),new(1,0),new(1,1),new(2, 1)};
        Move(0, 3);
    }
}
public class ZBlock : Block
{
    public ZBlock()
    {
        id = 7;
        cells[0] = new List<Position>(){new(0,0),new(0,1),new(1,1),new(1,2)};
        cells[1] = new List<Position>(){new(0,2),new(1,1),new(1,2),new(2,1)};
        cells[2] = new List<Position>(){new(1,0),new(1,1),new(2,1),new(2,2)};
        cells[3] = new List<Position>(){new(0,1),new(1,0),new(1,1),new(2,0)};
        Move(0, 3);
    }

}
