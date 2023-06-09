using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Building : MonoBehaviour  
{

    string buildingName;
    Sprite icon;
    Cost cost;
    string owner;
    float sightRange;
    IGrid iGrid;
    SpriteRenderer spriteRenderer;
    BoxCollider2D collider2d;



    public void SetValues(string buildingName, Sprite sprite, int[] buildingLocation, IGrid grid, string owner = "Unaligned", float sightRange = 5f)
    {
        this.buildingName = buildingName;
        this.icon = sprite;
        this.owner = owner;
        this.sightRange = sightRange;
        this.iGrid = grid;
        GameObject offset = new GameObject("Building Offset");
        offset.transform.parent = this.transform;
        offset.transform.localPosition = new Vector2(.5f, .5f);
        collider2d = offset.AddComponent<BoxCollider2D>();
        spriteRenderer = offset.AddComponent<SpriteRenderer>();
        offset.AddComponent<BuildingHoveAndSelect>();
        spriteRenderer.sprite = icon;
        transform.position = new Vector3(buildingLocation[0], buildingLocation[1], 1);
        transform.localScale = new Vector3(buildingLocation[2], buildingLocation[3], 1) * 50;
    }
}
