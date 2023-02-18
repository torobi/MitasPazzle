using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleLightView : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    
    [SerializeField] private Sprite onSprite;
    [SerializeField] private Sprite offSprite;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void On()
    {
        _spriteRenderer.sprite = onSprite;
    }

    public void Off()
    {
        _spriteRenderer.sprite = offSprite;
    }
}
