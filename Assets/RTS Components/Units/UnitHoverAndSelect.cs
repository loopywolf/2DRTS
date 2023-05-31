using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UnitHoverAndSelect : MonoBehaviour , IHoverOverObject, ISelectableGameObject
{
    bool isHover = false;
    bool isSelected = false;
    SpriteRenderer spriteRend;
    [SerializeField] Sprite sprite;


    // Start is called before the first frame update
    void Start()
    {
        if (GetComponent<SpriteRenderer>() != null)
        {
            spriteRend = GetComponent<SpriteRenderer>();
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
            spriteRend.color = Color.green;
        }
        else if (isHover)
        {
            spriteRend.color = Color.red;
        }
        else
        {
            spriteRend.color = Color.white;
        }
    }
}
