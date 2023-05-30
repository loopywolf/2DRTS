using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitHoverOver : MonoBehaviour, IHoverOverObject
{

    SpriteRenderer spriteRend;
    [SerializeField] Sprite sprite;
    
    // Start is called before the first frame update
    void Start()
    {
        if(GetComponent<SpriteRenderer>() != null)
        {
            spriteRend = GetComponent<SpriteRenderer>();
        } else
        {
            Debug.LogWarning("Sprite Renderer is not set on " + gameObject.name);
            spriteRend = gameObject.AddComponent<SpriteRenderer>();
            if (spriteRend != null)
            {
                spriteRend.sprite = sprite;
            }
        }

        if(GetComponent<BoxCollider2D>() == null)
        {
            Debug.LogWarning("Collider is not set on " + gameObject.name);
            gameObject.AddComponent<BoxCollider2D>();
        }
    }

    public void HoverOver()
    {
        if(spriteRend != null)
        {
            spriteRend.color = Color.red;
        }
    }

    public void HoverExit()
    {
        if(spriteRend != null)
        {
            spriteRend.color = Color.white;
        }
    }
}
