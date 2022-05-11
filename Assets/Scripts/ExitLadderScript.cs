using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLadderScript : MonoBehaviour
{
    public bool player1Fin = false;
    public bool player2Fin = false;
    public bool finished = false;
    public GameObject wintext;

    protected void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player 1" && !player1Fin)
        {
            player1Fin = true;
            // Debug.Log("player1 in");
        }
        if (other.gameObject.name == "Player 2" && !player2Fin)
        {
            player2Fin = true;
            // Debug.Log("player2 in");
        }
    }

    protected void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("SportsGirl"))
        {
            player1Fin = false;
        }
        if (other.gameObject.CompareTag("Librarian"))
        {
            player2Fin = false;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        wintext.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {   
        if (player1Fin && player2Fin && !finished){
            finished=true;
            wintext.SetActive(true);
            StartCoroutine(Timer());
            Debug.Log("Finished!");
        }
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("Scenes/MainMenu");
    }
}
