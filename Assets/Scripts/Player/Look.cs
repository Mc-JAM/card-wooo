using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour
{
    public float Sens = 100f;

    public Transform playerBody;

    float xRotation = 0f;

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * Sens * Time.deltaTime * 2;
        float mouseY = Input.GetAxis("Mouse Y") * Sens * Time.deltaTime * 2;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
