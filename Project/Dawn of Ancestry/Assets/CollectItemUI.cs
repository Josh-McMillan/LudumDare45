using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItemUI : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sprite;

    public void SetSprite(Sprite sprite_in)
    {
        sprite.sprite = sprite_in;
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
