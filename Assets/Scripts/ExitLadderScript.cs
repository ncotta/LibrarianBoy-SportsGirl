using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitLadderScript : MonoBehaviour
{
    private bool player1Fin = false;
    private bool player2Fin = false;
    private bool finished = false;

    protected void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player 1" && !player1Fin){
            player1Fin = true;
            // Debug.Log("player1 in");
        }
        if (collision.gameObject.name == "Player 2" && !player2Fin){
            player2Fin = true;
            // Debug.Log("player2 in");
        }


    }

    protected void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("SportsGirl")){
            player1Fin = false;
        }
        if (collision.gameObject.CompareTag("Librarian")){
            player2Fin = false;
        }


    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        if (player1Fin && player2Fin && !finished){
            finished=true;
            Debug.Log("Finished!");
        }
    }
}
