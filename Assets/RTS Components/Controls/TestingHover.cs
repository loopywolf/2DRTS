using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingHover : MonoBehaviour, IHoverOverObject, ISelectableGameObject
{

    [SerializeField] SpriteRenderer spriteRend;

    void Start()
    {
        spriteRend = GetComponent<SpriteRenderer>();
        spriteRend.color = Color.blue;
    }

    public void HoverOver()
    {
        spriteRend.color = Color.red;
    }

    public void HoverExit()
    {
        spriteRend.color = Color.white;
    }

    public void SelectGameObject()
    {
        spriteRend.color = Color.green;
    }

    public void DeselectGameObject()
    {
        spriteRend.color = Color.white;
    }
}