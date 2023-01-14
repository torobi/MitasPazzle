using System;
using System.Collections;
using System.Collections.Generic;
using Domain.Model;
using Domain.Model.Mino;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class MinoTest
{
    [Test]
    public void RotateTest()
    {
        var tMino = new T_Mino(0, 0, 0);
        Block[] clockwise0 = new[] { new Block(0, -1), new Block(-1, 0), new Block(0, 0), new Block(1, 0) };
        Block[] clockwise90 = new[] { new Block(0, -1), new Block(-1, 0), new Block(0, 0), new Block(0, 1) };
        Block[] clockwise180 = new[] { new Block(-1, 0), new Block(0, 0), new Block(1, 0), new Block(0, 1) };
        Block[] clockwise270 = new[] { new Block(0, -1), new Block(0, 0), new Block(1, 0), new Block(0, 1) };
        
        CollectionAssert.AreEquivalent(tMino.CalcBlocks(), clockwise0);
        
        // 左回転
        tMino.TurnLeft();
        CollectionAssert.AreEquivalent(tMino.CalcBlocks(), clockwise90 );
        tMino.TurnLeft();
        CollectionAssert.AreEquivalent(tMino.CalcBlocks(), clockwise180 );
        tMino.TurnLeft();
        CollectionAssert.AreEquivalent(tMino.CalcBlocks(), clockwise270 );
        tMino.TurnLeft();
        CollectionAssert.AreEquivalent(tMino.CalcBlocks(), clockwise0 );
        
        // 右回転
        tMino.TurnRight();
        CollectionAssert.AreEquivalent(tMino.CalcBlocks(), clockwise270 );
        tMino.TurnRight();
        CollectionAssert.AreEquivalent(tMino.CalcBlocks(), clockwise180 );
        tMino.TurnRight();
        CollectionAssert.AreEquivalent(tMino.CalcBlocks(), clockwise90 );
        tMino.TurnRight();
        CollectionAssert.AreEquivalent(tMino.CalcBlocks(), clockwise0 );
    }
}
