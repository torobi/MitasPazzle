using System;
using Domain.IPresenter;
using Domain.Model;
using Domain.Service.Mino;
using UnityEngine;
using Zenject;

public class Main : MonoBehaviour
{
    private CurrentMino _currentMino;
    private NextMinoHandler _nextMinoHandler;
    private Board _board;
    private IBoardRenderer _boardRenderer;
    private INextMinosRenderer _nextMinosRenderer;
    
    [Inject] 
    public void Construct(CurrentMino currentMino, NextMinoHandler nextMinoHandler, Board board, IBoardRenderer boardRenderer, INextMinosRenderer nextMinosRenderer)
    {
        _currentMino = currentMino;
        _nextMinoHandler = nextMinoHandler;
        _board = board;
        _boardRenderer = boardRenderer;
        _nextMinosRenderer = nextMinosRenderer;
    }

    private void Awake()
    {
        _currentMino.Set(_nextMinoHandler.Pop());
    }

    private void Start()
    {
        _board.InitState();
        _boardRenderer.Render(_board, _currentMino.Get());
        _nextMinosRenderer.Render(_nextMinoHandler.GetNextMinos());
    }
}
