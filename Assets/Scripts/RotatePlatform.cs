using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlatform : MonoBehaviour
{
    public float rotateSpeed = 0f;
    public int offset = 1;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, offset * 60, 0) * Time.deltaTime * rotateSpeed);
    }
}
