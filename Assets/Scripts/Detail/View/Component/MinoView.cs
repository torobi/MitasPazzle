using System;
using System.Collections;
using System.Collections.Generic;
using Domain.Model;
using Domain.Model.Minos;
using UnityEngine;

public class MinoView : MonoBehaviour
{
    [SerializeField] private BlockViewFactory blockViewFactory;
    private static readonly int BLOCKS_WIDTH = 3;
    private static readonly int BLOCKS_HEIGHT = 2;
    private BlockView[,] _blocks = new BlockView[BLOCKS_HEIGHT, BLOCKS_WIDTH]; 
    
    public void CreateBlocks()
    {
        for (int i = 0; i < BLOCKS_HEIGHT; i++)
        {
            for (int j = 0; j < BLOCKS_WIDTH; j++)
            {
                _blocks[i, j] = transform.Find($"block({j},{i})").GetComponent<BlockView>();
            }
        }
    }

    public void UpdateState(Block[] blocks)
    {
        Reset();
        foreach (var b in AdjustBlocks(blocks))
        {
            _blocks[b.y, b.x].UpdateState(BlockView.BlockState.White); 
        }
    }

    private void Reset()
    {
        for (int i = 0; i < BLOCKS_HEIGHT; i++)
        {
            for (int j = 0; j < BLOCKS_WIDTH; j++)
            {
                _blocks[i, j].UpdateState(BlockView.BlockState.Black);
            }
        }
    }

    private Block[] AdjustBlocks(Block[] blocks)
    {
        var minX = int.MaxValue;
        var minY = int.MaxValue;

        foreach (var b in blocks)
        {
            minX = Math.Min(minX, b.x);
            minY = Math.Min(minY, b.y);
        }
        
        var adjustedBlocks = new Block[blocks.Length];
        for (int i = 0; i < blocks.Length; i++)
        {
            adjustedBlocks[i] = new Block(blocks[i].x - minX, blocks[i].y - minY);
        }

        return adjustedBlocks;
    }
}
