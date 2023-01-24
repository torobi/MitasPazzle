using Domain.Model;
using Domain.Model.Mino;
using Domain.Service.Mino;
using NUnit.Framework;

public class CurrentMinoTest
{
    [Test]
    public void MoveLeftTest()
    {
        var board = new Board();
        var currentMino = new CurrentMino();
        currentMino.Set(new T_Mino(4, 1));
        Assert.IsTrue(new T_Mino(4,1) == currentMino.Get());

        currentMino.TryMoveLeft(board);
        Assert.IsTrue(new T_Mino(3,1) == currentMino.Get());

        currentMino.TryMoveLeft(board);
        Assert.IsTrue(new T_Mino(2,1) == currentMino.Get());
        
        currentMino.TryMoveLeft(board);
        Assert.IsTrue(new T_Mino(1,1) == currentMino.Get());
        
        // 左端でこれ以上左にいけない
        currentMino.TryMoveLeft(board);
        Assert.IsTrue(new T_Mino(1,1) == currentMino.Get());
    }

    [Test]
    public void MoveRightTest()
    {
        var board = new Board();
        var currentMino = new CurrentMino();
        var startX = Board.WIDTH - 5;
        currentMino.Set(new T_Mino(startX, 1));
        Assert.IsTrue(new T_Mino(startX,1) == currentMino.Get());

        currentMino.TryMoveRight(board);
        Assert.IsTrue(new T_Mino(startX+1,1) == currentMino.Get());

        currentMino.TryMoveRight(board);
        Assert.IsTrue(new T_Mino(startX+2,1) == currentMino.Get());
        
        currentMino.TryMoveRight(board);
        Assert.IsTrue(new T_Mino(startX+3,1) == currentMino.Get());
        
        // 右端でこれ以上右に行けない
        currentMino.TryMoveRight(board);
        Assert.IsTrue(new T_Mino(startX+3,1) == currentMino.Get());
    }

    [Test]
    public void TurnLeftTest()
    {
        var board = new Board();
        var currentMino = new CurrentMino();
        
        currentMino.Set(new T_Mino(2, 1, 0));
        currentMino.TryTurnLeft(board);
        Assert.IsTrue(new T_Mino(2, 1, 3) == currentMino.Get());
        
        // 壁際で回転しようとしてもできない
        currentMino.Set(new T_Mino(0, 1, 1));
        Assert.IsTrue(new T_Mino(0, 1, 1) == currentMino.Get());
        currentMino.TryTurnLeft(board);
        Assert.IsTrue(new T_Mino(0, 1, 1) == currentMino.Get());
    }
    
    [Test]
    public void TurnRightTest()
    {
        var board = new Board();
        var currentMino = new CurrentMino();
        
        currentMino.Set(new T_Mino(2, 1, 0));
        currentMino.TryTurnRight(board);
        Assert.IsTrue(new T_Mino(2, 1, 1) == currentMino.Get());
        
        // 壁際で回転しようとしてもできない
        var x = Board.WIDTH - 1;
        currentMino.Set(new T_Mino(x, 1, 1));
        Assert.IsTrue(new T_Mino(x, 1, 1) == currentMino.Get());
        currentMino.TryTurnRight(board);
        Assert.IsTrue(new T_Mino(x, 1, 1) == currentMino.Get());
    }

    [Test]
    public void DropTest()
    {
        var board = new Board();
        var currentMino = new CurrentMino();

        var startY = Board.HEIGHT - 3;
        currentMino.Set(new T_Mino(2, startY));
        Assert.IsTrue(new T_Mino(2, startY) == currentMino.Get());
        currentMino.TryDrop(board);
        Assert.IsTrue(new T_Mino(2, startY+1) == currentMino.Get());
        currentMino.TryDrop(board);
        Assert.IsTrue(new T_Mino(2, startY+2) == currentMino.Get());
        
        // 既に一番下でこれ以上は下がれない
        currentMino.TryDrop(board);
        Assert.IsTrue(new T_Mino(2, startY+2) == currentMino.Get());
    }

    [Test]
    public void HardDropTest()
    {
        var board = new Board();
        var currentMino = new CurrentMino();
        currentMino.Set(new T_Mino(2, 0));
        currentMino.TryHardDrop(board);
        Assert.IsTrue(new T_Mino(2, Board.HEIGHT-1) == currentMino.Get());
        
        currentMino.TryHardDrop(board);
        Assert.IsTrue(new T_Mino(2, Board.HEIGHT-1) == currentMino.Get());
    }
    
}
