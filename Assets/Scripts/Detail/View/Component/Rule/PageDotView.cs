using System;
using System.Collections;
using System.Collections.Generic;
using Adapter.IView;
using UnityEngine;

public class PageDotView : MonoBehaviour, IPageDotView
{
    [SerializeField] private GameObject[] dotObjects;
    private ToggleLightView[] _dots;
    
    private void Start()
    {
        _dots = new ToggleLightView[dotObjects.Length];
        for (int i = 0; i < dotObjects.Length; i++)
        {
            _dots[i] = dotObjects[i].GetComponent<ToggleLightView>();
            dotObjects[i].GetComponent<PageDotButtonView>().SetPageNum(i);
        }
    }

    public void UpdateLight(int pageNum)
    {
        for (var i = 0; i < _dots.Length; i++)
        {
            if (i == pageNum)
            {
                _dots[i].On();
            }
            else
            {
                _dots[i].Off();
            }
        }
    }
}
