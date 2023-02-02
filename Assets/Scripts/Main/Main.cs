using Domain.Service.Mino;
using UnityEngine;
using Zenject;

public class Main : MonoBehaviour
{
    private CurrentMino _currentMino;
    private NextMinoHandler _nextMinoHandler;
    
    [Inject] 
    public void Construct(CurrentMino currentMino, NextMinoHandler nextMinoHandler)
    {
        _currentMino = currentMino;
        _nextMinoHandler = nextMinoHandler;
    }

    private void Awake()
    {
        _currentMino.Set(_nextMinoHandler.Pop());
    }
}
