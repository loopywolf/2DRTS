using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingHoveAndSelect : MonoBehaviour, IHoverOverObject, ISelectableGameObject
{
    bool isHover = false;
    bool isSelected = false;
    [SerializeField] SpriteRenderer spriteRend;
    [SerializeField] Sprite sprite;


    void Awake()
    {
        if (GetComponent<SpriteRenderer>() != null)
        {
            spriteRend = GetComponent<SpriteRenderer>();
            sprite = spriteRend.sprite;
        }
        else
        {
            Debug.LogWarning("Sprite Renderer is not set on " + gameObject.name);
            spriteRend = gameObject.AddComponent<SpriteRenderer>();
            if (spriteRend != null)
            {
                spriteRend.sprite = sprite;
            }
        }

        if (GetComponent<BoxCollider2D>() == null)
        {
            Debug.LogWarning("Collider is not set on " + gameObject.name);
            gameObject.AddComponent<BoxCollider2D>();
        }
    }



    public void SelectGameObject()
    {
        isSelected = true;
        UpdateSelected();
    }

    public void DeselectGameObject()
    {
        isSelected = false;
        UpdateSelected();
    }

    public void HoverOver()
    {
        isHover = true;
        UpdateSelected();
    }

    public void HoverExit()
    {
        isHover = false;
        UpdateSelected();
    }

    void UpdateSelected()
    {
        if (isSelected)
        {
            spriteRend.color = Color.gray;
        }
        else if (isHover)
        {
            spriteRend.color = Color.blue;
        }
        else
        {
            spriteRend.color = Color.white;
        }
    }
}
