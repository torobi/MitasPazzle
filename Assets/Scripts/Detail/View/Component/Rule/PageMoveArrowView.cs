using System;
using System.Collections;
using System.Collections.Generic;
using Adapter.IView;
using Domain.Model;
using UnityEngine;

public class PageMoveArrowView : MonoBehaviour, IPageMoveArrowView
{
    [SerializeField] private ToggleLightView leftArrow;
    [SerializeField] private ToggleLightView rightArrow;

    public void UpdateLight(RuleBook ruleBook)
    {
        if (ruleBook.CanOpenNextPage())
        {
            rightArrow.On();
        }
        else
        {
            rightArrow.Off();
        }

        if (ruleBook.CanOpenPrevPage())
        {
            leftArrow.On();
        }
        else
        {
            leftArrow.Off();
        }
    }
}
