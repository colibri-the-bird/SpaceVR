using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public float Speed;
    public float rotationSpeed;
    void FixedUpdate()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveHorizontal = moveHorizontal * 5;
            moveVertical = moveVertical * 5;
        }
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.Translate(movement * Speed * Time.fixedDeltaTime);
        if (Input.GetMouseButton(1))
        {

            //Camera Rotation
            this.transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * rotationSpeed * Time.deltaTime, Space.World);
            this.transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y"), 0, 0) * rotationSpeed * Time.deltaTime, Space.Self);
        }
    }
}