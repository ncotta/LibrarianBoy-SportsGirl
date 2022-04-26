using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform player1;
    public Transform player2;
    void Update()
    {
        transform.position = (player1.transform.position + player2.transform.position)/2 + new Vector3(0, 25, -15);
    }
}
