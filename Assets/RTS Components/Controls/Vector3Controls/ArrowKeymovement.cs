using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowKeymovement : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        float moveX = 0f;
        float moveY = 0f;

        if (Input.GetKey(KeyCode.UpArrow)) moveY = +1f;
        if (Input.GetKey(KeyCode.DownArrow)) moveY = -1f;
        if (Input.GetKey(KeyCode.LeftArrow)) moveX = -1f;
        if (Input.GetKey(KeyCode.RightArrow)) moveX = +1f;

        Vector3 moveVector = new Vector3(moveX, moveY).normalized;
        GetComponent<IMoveVelocity>().SetVelocity(moveVector);
    }
}
