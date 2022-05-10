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
        distance = Mathf.Sqrt(Vector3.Dot(player1.transform.position-player2.transform.position, player1.transform.position-player2.transform.position));
        Debug.Log(distance);
        transform.position = (player1.transform.position + player2.transform.position)/2
         + new Vector3(15+distance/10, 25 + distance/2 , -15 - distance/10);
    }
}
/*
        distance = Vector3.Dot(player1.transform.position-player2.transform.position, player1.transform.position-player2.transform.position);
        Debug.Log(distance);
        distance = Mathf.Sqrt(distance);
        newPos = Vector3.Lerp(player1.transform.position, player2.transform.position, 0.5f);
        transform.position = newPos + new Vector3((distance)*5, 20+distance, -(distance)*5);
*/