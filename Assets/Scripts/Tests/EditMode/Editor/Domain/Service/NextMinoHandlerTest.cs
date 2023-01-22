using Domain.Model.Minos;
using Domain.Service.Mino;
using NUnit.Framework;


public class NextMinoHandlerTest
{
    [Test]
    public void GetNextMinoTest() 
    {
        var factory = new MinoFactory(); 
        var nextMinoHandler = new NextMinoHandler(factory);
        
        CheckNextMino(factory, nextMinoHandler);
        CheckNextMino(factory, nextMinoHandler);
        CheckNextMino(factory, nextMinoHandler);
    }

    private void CheckNextMino(MinoFactory factory, NextMinoHandler nextMinoHandler)
    {
        var nextMinos = nextMinoHandler.GetNextMinos(factory.MinoNum());
        CollectionAssert.AreNotEqual(nextMinos, factory.GetAllMinos());
        CollectionAssert.AreEquivalent(nextMinos, factory.GetAllMinos());
    }

    [Test]
    public void PopTest()
    {
        var factory = new MinoFactory(); 
        var nextMinoHandler = new NextMinoHandler(factory);
        
        CheckPop(factory, nextMinoHandler);
        CheckPop(factory, nextMinoHandler);
        CheckPop(factory, nextMinoHandler);
    }

    private void CheckPop(MinoFactory factory, NextMinoHandler nextMinoHandler)
    {
        var nextMinos = new Mino[factory.MinoNum()];
        for (int i = 0; i < factory.MinoNum(); i++)
        {
            nextMinos[i] = nextMinoHandler.Pop();
        }
        CollectionAssert.AreNotEqual(nextMinos, factory.GetAllMinos());
        CollectionAssert.AreEquivalent(nextMinos, factory.GetAllMinos());
    }
}
