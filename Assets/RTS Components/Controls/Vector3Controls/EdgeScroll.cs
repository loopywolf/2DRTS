using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeScroll : MonoBehaviour
{
    [SerializeField] int pixelEdgeLimit = 25;

    void Update()
    {
        float moveX = 0f;
        float moveY = 0f;

        if (Input.mousePosition.y > Screen.height - pixelEdgeLimit) moveY = +1f;
        if (Input.mousePosition.y < pixelEdgeLimit) moveY = -1f;
        if (Input.mousePosition.x < pixelEdgeLimit) moveX = -1f;
        if (Input.mousePosition.x > Screen.width - pixelEdgeLimit) moveX = +1f;

        Vector3 moveVector = new Vector3(moveX, moveY).normalized;
        GetComponent<IMoveVelocity>().SetVelocity(moveVector);
    }
}
