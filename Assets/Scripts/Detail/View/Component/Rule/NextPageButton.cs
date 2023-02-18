using System.Collections;
using System.Collections.Generic;
using Adapter.Controller;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class NextPageButton : MonoBehaviour, IPointerClickHandler
{
    private RuleButtonController _ruleButtonController;
    
    [Inject] 
    public void Construct(RuleButtonController ruleButtonController)
    {
        _ruleButtonController = ruleButtonController;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _ruleButtonController.ClickRightArrowButton();
    }
}
