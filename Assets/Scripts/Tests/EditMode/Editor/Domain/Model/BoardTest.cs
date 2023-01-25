using Domain.Model;
using Domain.Model.Mino;
using NUnit.Framework;

[TestFixture]
public class BoardTest
{
    [Test]
    public void CanPutTest()
    {
        var board = new Board();
        Assert.IsTrue(board.CanPut(new T_Mino(5, 5)));
        Assert.IsFalse(board.CanPut(new T_Mino(-10,0)));
        
        board.PutMino(new T_Mino(5, 5));
        Assert.IsFalse(board.CanPut(new T_Mino(5,5)));
        Assert.IsFalse(board.CanPut(new T_Mino(4,5)));
        Assert.IsFalse(board.CanPut(new T_Mino(6,5)));
        Assert.IsFalse(board.CanPut(new T_Mino(5,4)));
        
        Assert.IsTrue(board.CanPut(new T_Mino(5,3)));
        Assert.IsTrue(board.CanPut(new T_Mino(2,5)));
        Assert.IsTrue(board.CanPut(new T_Mino(8,5)));
    }

    [Test]
    public void OutPutBoardTest()
    {
        var board = new Board();
        var emptyOutputBoard = board.OutputBoard;
        board.PutMino(new T_Mino(5, 1));
        CollectionAssert.AreEquivalent(emptyOutputBoard, board.OutputBoard);
        
        board.PutMino(new T_Mino(5, 3));
        CollectionAssert.AreNotEquivalent(emptyOutputBoard, board.OutputBoard);
    }
}
