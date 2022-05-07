using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform player1;
    public Transform player2;
    private float distance;
    
void Update()
    {
        distance = Vector3.Dot(player1.transform.position-player2.transform.position, player1.transform.position-player2.transform.position);
        Debug.Log(distance);
        transform.position = (player1.transform.position + player2.transform.position)/2
         + new Vector3(0, 25 + distance/100 , -15 - distance/100);
    }
}
