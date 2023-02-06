using System;
using Adapter.IView;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class ResultView : MonoBehaviour, IResultView
{
    
    [SerializeField] private NumberView numberView;
    [SerializeField] private GameObject gameClearGameObject;
    [SerializeField] private GameObject gameOverGameObject;

    private Rigidbody2D _boardRigidbody2D;

    private void Awake()
    {
        gameObject.SetActive(false);
    }
    
    public void ShowGameOver()
    {
        gameClearGameObject.SetActive(false);
        gameOverGameObject.SetActive(true);
        AppearResult();
    }

    public void ShowGameClear(int score)
    {
        numberView.SetNumber(score);
        gameClearGameObject.SetActive(true);
        gameOverGameObject.SetActive(false);
        AppearResult();
    }

    private void AppearResult()
    {
        gameObject.SetActive(true);
    }
}
