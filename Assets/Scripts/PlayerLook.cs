using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera cam;
    private float xrot = 0f;

    public float xsens = 30f;
    public float ysens = 30f;
    
    public void processLook(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;

        xrot -= mouseY * Time.deltaTime * ysens;
        xrot = Mathf.Clamp(xrot, -80, 80);

        cam.transform.localRotation = Quaternion.Euler(xrot, 0, 0);

        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xsens);
    }
}
