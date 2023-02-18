using System;
using System.Collections;
using System.Collections.Generic;
using Adapter.IView;
using UnityEngine;

public class PageContainerView : MonoBehaviour, IPageContainerView
{
    [SerializeField] private GameObject[] contentObjects;
    private IPageContentView[] _pageContents;

    private void Awake()
    {
        _pageContents = new IPageContentView[contentObjects.Length];
        for (var i = 0; i < contentObjects.Length; i++)
        {
            _pageContents[i] = contentObjects[i].GetComponent<IPageContentView>();
        }
    }

    public void PageSwitch(int pageNum)
    {
        for (int i = 0; i < _pageContents.Length; i++)
        {
            if (i == pageNum)
            {
                _pageContents[i].Appear();                
            }
            else
            {
                _pageContents[i].Disappear();
            }
            
        }
    }
}
