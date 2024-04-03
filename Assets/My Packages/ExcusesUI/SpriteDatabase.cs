using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteDatabase : MonoBehaviour
{
    public static SpriteDatabase instance;

    public Sprite BackgroundSprite;
    public Sprite ReverseBackgroundSprite;
    public Sprite HoverSprite;
    public Sprite icon;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
