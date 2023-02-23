
using Adapter.Controller;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class MainBackTitleButtonView : MonoBehaviour, IPointerClickHandler
{
    private MainButtonController _mainButtonController;

    [Inject]
    public void Construct(MainButtonController mainButtonController)
    {
        _mainButtonController = mainButtonController;
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        _mainButtonController.ClickBackTitleButton();
    }
}
