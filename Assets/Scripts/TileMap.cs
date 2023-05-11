using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[ExecuteInEditMode]

public class TileMap : MonoBehaviour
{
    const float tileSize = 1f;

    [SerializeField] bool generate;

    [SerializeField] int height;
    [SerializeField] int width;


    void Update()
    {
        if (generate)
        {
            Generate();
        }
        generate = false;
    }

    void Generate()
    {
        //dispose of any existing tiles
        //create new array
    }
}
