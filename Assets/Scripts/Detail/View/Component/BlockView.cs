using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockView : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    // 確認用
    [SerializeField] private BlockState _state;
    
    [SerializeField] private Sprite black;
    [SerializeField] private Sprite red;
    [SerializeField] private Sprite white;
    [SerializeField] private Sprite yellow;

    private readonly Dictionary<BlockState, Sprite> _sprites = new();
    
    public enum BlockState
    {
        Black,
        Red,
        White,
        Yellow
    }

    private void Awake()
    {
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        DefSprites();
        UpdateState(BlockState.Black);
    }

    private void DefSprites()
    {
        _sprites[BlockState.Black] = black;
        _sprites[BlockState.Red] = red;
        _sprites[BlockState.White] = white;
        _sprites[BlockState.Yellow] = yellow;
    }

    public void UpdateState(BlockState state)
    {
        if (_spriteRenderer == null) return;
        _spriteRenderer.sprite = _sprites[state];
    }

    public void SetAlpha(float alpha)
    {
        if (_spriteRenderer == null) return;
        var color = _spriteRenderer.color;
        color.a = alpha;
        _spriteRenderer.color = color;
    }
}
