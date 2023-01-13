using System;
using UnityEngine;

public class MinoFactory
{
    public enum ShapeName {
        T,
        V, 
        I, 
        L, 
        J, 
        O, 
        S, 
        Z
    }
    static readonly int START_X = 0;
    static readonly int START_Y = 0;

    Mino MakeMino(ShapeName shapeName)
    {
        Block[] shape = GetShape(shapeName);
        return new Mino(shape, START_X, START_Y);
    }

    private Block[] GetShape(ShapeName shapeName)
    {
        Block[] shape;
        switch (shapeName)
        {
            case ShapeName.T:
                shape = new[] { new Block(1, 0), new Block(0, 1), new Block(1, 1), new Block(2, 1) };
                break;
            case ShapeName.V:
                shape = new[] { new Block(1, 0), new Block(0, 1), new Block(1, 1) };
                break;
            case ShapeName.I:
                shape = new[] { new Block(0, 1), new Block(1, 1), new Block(2, 1) };
                break;
            case ShapeName.L:
                shape = new[] { new Block(2, 0), new Block(0, 1), new Block(1, 1), new Block(2, 1) };
                break;
            case ShapeName.J:
                shape = new [] { new Block(0, 0), new Block(0, 1), new Block(1, 1), new Block(2, 1) };
                break;
            case ShapeName.O:
                shape = new[] { new Block(0,0), new Block(1, 0), new Block(1, 0), new Block(1, 1) };
                break;
            case ShapeName.S:
                shape = new[] { new Block(1, 0), new Block(2, 0), new Block(0, 1), new Block(1, 1) };
                break;                
            case ShapeName.Z:
                shape = new[] { new Block(0, 0), new Block(1, 0), new Block(1, 1), new Block(2, 1) };
                break;
            default:
                shape = new[] { new Block(1, 1) };
                Debug.LogError("予期しないShapeName");
                break;
        }

        return shape;
    }
}
