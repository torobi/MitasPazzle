using System;
using System.Collections.Generic;
using Adapter.IView;
using Domain.Model;
using UnityEngine;

public class BoardView : MonoBehaviour, IBoardView
{
    [SerializeField] private BlockViewFactory blockViewFactory;
    [SerializeField] private float x;
    [SerializeField] private float y;
    [SerializeField] private float gap;
    private readonly BlockView[,] _blocks = new BlockView[Board.ROOM_HEIGHT, Board.WIDTH];
    private readonly Dictionary<Board.State, BlockView.BlockState> _stateTable = new();

    public BoardView()
    {
        DefStateTable();
    }

    private void Start()
    {
        CreateBlocks();
    }

    private void CreateBlocks()
    {
        for (int i = 0; i < Board.ROOM_HEIGHT; i++)
        {
            for (int j = 0; j < Board.WIDTH; j++)
            {
                var pos = new Vector3(x+j*(0.8f+gap), y-i*(0.8f+gap));
                var scale = new Vector3(0.33f, 0.33f);
                _blocks[i, j] = blockViewFactory.GetBlockGameObject(pos, scale).GetComponent<BlockView>();
            }
        }
    }

    private void DefStateTable()
    {
        _stateTable[Board.State.Blank]       = BlockView.BlockState.Black;
        _stateTable[Board.State.Block]       = BlockView.BlockState.White;
        _stateTable[Board.State.Trap]        = BlockView.BlockState.Red;
        _stateTable[Board.State.BlockOnTrap] = BlockView.BlockState.Yellow;
    }
    
    public void SetStateAt(int x, int y, Board.State state)
    {
        _blocks[y, x].UpdateState(_stateTable[state]);
    }

    public void SetBlockOnTrapAt(int x, int y)
    {
        
    }
}
