using System;
using ChuongCustom;
using DG.Tweening;
using UnityEngine;

public class Player : Singleton<Player>
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    private bool isRevive;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (isRevive) return;
        if (col.collider.CompareTag("lose"))
        {
            InGameManager.Instance.BeforeLose();
        }
    }

    public void Revive()
    {
        var newPos = transform.position;
        newPos.x = 0;
        transform.position = newPos;
        isRevive = true;
        var color = spriteRenderer.color;
        var newColor = color;
        newColor.a = 0.65f;
        spriteRenderer.color = newColor;
        DOVirtual.DelayedCall(1.5f, (() =>
        {
            isRevive = false;
            spriteRenderer.color = color;
        })).SetTarget(transform);
    }

    private void OnDestroy()
    {
        transform.DOKill();
    }
}
