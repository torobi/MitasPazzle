using System;
using System.Collections;
using System.Collections.Generic;
using Domain.IPresenter;
using Domain.Model;
using Domain.Service.Mino;
using UnityEngine;
using Zenject;

public class Rule : MonoBehaviour
{
    private IRulePageRenderer _rulePageRenderer;
    private RuleBook _ruleBook;
    private NextMinoHandler _nextMinoHandler;
    private CurrentMino _gameClearCurrentMino;
    private CurrentMino _gameOverCurrentMino;

    [Inject]
    public void Construct(
        IRulePageRenderer rulePageRenderer, 
        RuleBook ruleBook,
        NextMinoHandler nextMinoHandler,
        [Inject(Id = "gameClear")]CurrentMino gameClearCurrentMino,
        [Inject(Id = "gameOver")]CurrentMino gameOverCurrentMino
        )
    {
        _rulePageRenderer = rulePageRenderer;
        _ruleBook = ruleBook;
        _nextMinoHandler = nextMinoHandler;
        _gameClearCurrentMino = gameClearCurrentMino;
        _gameOverCurrentMino = gameOverCurrentMino;
    }

    private void Awake()
    {
        _gameClearCurrentMino.Set(_nextMinoHandler.Pop());
        _gameOverCurrentMino.Set(_nextMinoHandler.Pop());
    }

    void Start()
    {
        _rulePageRenderer.UpdatePage(_ruleBook);
    }
}
