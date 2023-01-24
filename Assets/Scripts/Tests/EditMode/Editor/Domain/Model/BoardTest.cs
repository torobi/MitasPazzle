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
        
        board.PetMino(new T_Mino(5, 5));
        Assert.IsFalse(board.CanPut(new T_Mino(5,5)));
        Assert.IsFalse(board.CanPut(new T_Mino(4,5)));
        Assert.IsFalse(board.CanPut(new T_Mino(6,5)));
        Assert.IsFalse(board.CanPut(new T_Mino(5,4)));
        
        Assert.IsTrue(board.CanPut(new T_Mino(5,3)));
        Assert.IsTrue(board.CanPut(new T_Mino(2,5)));
        Assert.IsTrue(board.CanPut(new T_Mino(8,5)));
    }
}
