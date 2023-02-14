using System.Collections;
using System.Collections.Generic;
using Adapter.Controller;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class RetryButtonView : MonoBehaviour, IPointerClickHandler
{
    private ResultButtonController _resultButtonController;
    
    [Inject] 
    public void Construct(ResultButtonController resultButtonController)
    {
        _resultButtonController = resultButtonController;
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        _resultButtonController.ClickRetryButton();
    }
}
