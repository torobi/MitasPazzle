using System.Collections;
using System.Collections.Generic;
using Adapter.Controller;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class RuleButtonView : MonoBehaviour, IPointerClickHandler
{
    private TitleButtonController _titleButtonController;

    [Inject]
    public void Construct(TitleButtonController titleButtonController)
    {
        _titleButtonController = titleButtonController;
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        _titleButtonController.ClickRuleButton();
    }
}
