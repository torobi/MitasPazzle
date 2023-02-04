using System.Collections;
using System.Collections.Generic;
using Adapter.IView;
using Domain.Model.Minos;
using UnityEngine;

public class KeepView : MonoBehaviour, IKeepView
{
    [SerializeField] private MinoView minoView;
    
    // Start is called before the first frame update
    void Start()
    {
        minoView.CreateBlocks();
    }

    public void SetMino(Mino mino)
    {
        minoView.UpdateState(mino.CalcBlocks());
    }

    public void SetBlank()
    {
        minoView.Reset();
    }
}
