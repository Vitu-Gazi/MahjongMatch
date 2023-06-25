using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    public static Action<Cell> TryRemoveCell;

    public Sprite CurrentSprite => spriteRenderer.sprite;
    public int Level { get; set; }

    public void SetSprite (Sprite sprite)
    {
        spriteRenderer.sprite = sprite;
    }

    private void OnMouseDown()
    {
        TryRemoveCell.Invoke(this);
    }
}
