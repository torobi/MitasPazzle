using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Adapter.Controller;
using Adapter.IView;
using UnityEngine;
using Zenject;
using Cysharp.Threading.Tasks;

public class MainLoopView : MonoBehaviour, IMainLoopView
{
    private List<IDropController> _dropControllers;
    private CancellationTokenSource cts = new();
    private int DROP_INTERVAL_MS = 500;
    
    [Inject] 
    public void Construct(List<IDropController> dropControllers){ 
        _dropControllers = dropControllers;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        StartDropLoop(cts.Token).Forget();
    }
    
    private async UniTaskVoid StartDropLoop(CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            foreach (var dropController in _dropControllers)
            {
                dropController.Drop();
            }
            await UniTask.Delay(DROP_INTERVAL_MS, cancellationToken: token);
        }
    }

    public void Pause()
    {
        this.cts.Cancel();
        cts = new();
    }

    public void Resume()
    {
        StartDropLoop(cts.Token).Forget();
    }

    public void ResetTiming()
    {
        Pause();
        StartDropLoopWithDelay(cts.Token).Forget();
    }

    private async UniTaskVoid StartDropLoopWithDelay(CancellationToken token)
    {
        await UniTask.Delay(DROP_INTERVAL_MS, cancellationToken: token);
        StartDropLoop(token).Forget();
    }
}
