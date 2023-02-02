using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Adapter.Controller;
using UnityEngine;
using Zenject;
using Cysharp.Threading.Tasks;

public class GamePlayView : MonoBehaviour
{
    private GamePlayController _gamePlayController;
    private CancellationTokenSource cts = new();
    
    [Inject] 
    public void Construct(GamePlayController gamePlayController){ 
        _gamePlayController = gamePlayController;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        StartDropLoop(cts.Token).Forget();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private async UniTaskVoid StartDropLoop(CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            _gamePlayController.Drop();
            await UniTask.Delay(500, cancellationToken: token);
        }
    }
}
