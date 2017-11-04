using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseRoomContentItem : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer _imageRef;

    public void SetSprite ( Sprite sprite)
    {
        _imageRef.sprite = sprite;
    }


    public void SetSize ( Vector2 size )
    {
        _imageRef.size = (size);
    }
}
