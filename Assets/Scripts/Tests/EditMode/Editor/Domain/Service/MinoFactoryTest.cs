using Domain.Model.Mino;
using Domain.Service.Mino;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;



public class MinoFactoryTest 
{
    [Test]
    public void GenerateTest()
    {
        const int appearX = 0;
        const int appearY = 0;
        var factory = new MinoFactory();
        CollectionAssert.AreEquivalent(factory.MakeMino(MinoFactory.ShapeName.I).CalcBlocks(), new I_Mino(appearX, appearY).CalcBlocks());
        CollectionAssert.AreEquivalent(factory.MakeMino(MinoFactory.ShapeName.J).CalcBlocks(), new J_Mino(appearX, appearY).CalcBlocks());
        CollectionAssert.AreEquivalent(factory.MakeMino(MinoFactory.ShapeName.L).CalcBlocks(), new L_Mino(appearX, appearY).CalcBlocks());
        CollectionAssert.AreEquivalent(factory.MakeMino(MinoFactory.ShapeName.O).CalcBlocks(), new O_Mino(appearX, appearY).CalcBlocks());
        CollectionAssert.AreEquivalent(factory.MakeMino(MinoFactory.ShapeName.S).CalcBlocks(), new S_Mino(appearX, appearY).CalcBlocks());
        CollectionAssert.AreEquivalent(factory.MakeMino(MinoFactory.ShapeName.T).CalcBlocks(), new T_Mino(appearX, appearY).CalcBlocks());
        CollectionAssert.AreEquivalent(factory.MakeMino(MinoFactory.ShapeName.V).CalcBlocks(), new V_Mino(appearX, appearY).CalcBlocks());
        CollectionAssert.AreEquivalent(factory.MakeMino(MinoFactory.ShapeName.Z).CalcBlocks(), new Z_Mino(appearX, appearY).CalcBlocks());
    }
}
