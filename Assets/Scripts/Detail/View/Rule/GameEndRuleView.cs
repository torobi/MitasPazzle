using System.Collections;
using System.Collections.Generic;
using Adapter.IView;
using UnityEngine;

public class GameEndRuleView : MonoBehaviour, IGameEndRuleView
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Appear()
    {
        this.gameObject.SetActive(true);
        StartGameClearAnim();
        StartGameOverAnim();
    }

    public void Disappear()
    {
        this.gameObject.SetActive(false);
    }

    private void StartGameClearAnim()
    {
        
    }

    private void StartGameOverAnim()
    {
        
    }
}
