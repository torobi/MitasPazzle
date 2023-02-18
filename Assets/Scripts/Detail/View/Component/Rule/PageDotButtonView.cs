using System.Collections;
using System.Collections.Generic;
using Adapter.Controller;
using Adapter.IView;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class PageDotButtonView : MonoBehaviour, IPointerClickHandler
{
    private RuleButtonController _ruleButtonController;
    private int _pageNum = 0;
    
    [Inject]
    public void Construct(RuleButtonController ruleButtonController)
    {
        _ruleButtonController = ruleButtonController;
    }

    public void SetPageNum(int num)
    {
        _pageNum = num;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _ruleButtonController.ClickPageDotButton(_pageNum);
    }
}
