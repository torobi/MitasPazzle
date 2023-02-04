using System.Collections;
using System.Collections.Generic;
using Adapter.IView;
using UnityEngine;

public class TrashView : MonoBehaviour, ITrashView
{
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private SpriteRenderer spriteRenderer;
    
    public void UpdateTrashRemain(int remain)
    {
        Debug.Log(remain);
        spriteRenderer.sprite = sprites[remain];
    }
}
