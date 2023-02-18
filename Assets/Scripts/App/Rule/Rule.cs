using System.Collections;
using System.Collections.Generic;
using Domain.IPresenter;
using Domain.Model;
using UnityEngine;
using Zenject;

public class Rule : MonoBehaviour
{
    private IRulePageRenderer _rulePageRenderer;
    private RuleBook _ruleBook;

    [Inject]
    public void Construct(IRulePageRenderer rulePageRenderer, RuleBook ruleBook)
    {
        _rulePageRenderer = rulePageRenderer;
        _ruleBook = ruleBook;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        _rulePageRenderer.UpdatePage(_ruleBook);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
