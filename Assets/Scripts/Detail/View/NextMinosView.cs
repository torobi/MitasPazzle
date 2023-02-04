using System.Collections;
using System.Collections.Generic;
using Adapter.IView;
using Domain.Model.Minos;
using UnityEngine;

public class NextMinosView : MonoBehaviour, INextMinosView
{
    [SerializeField] 
    private MinoView[] _minoViews;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var minoView in _minoViews)
        {
            minoView.CreateBlocks();
        }
    }

    public void UpdateMinos(Mino[] minos)
    {
        for (int i = 0; i < _minoViews.Length; i++)
        {
            _minoViews[i].UpdateState(minos[i].CalcBlocks());
        }
    }
}
