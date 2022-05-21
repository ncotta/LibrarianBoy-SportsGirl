using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObserver : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;
    public PlayerClass player1;
    public PlayerClass player2;
    private int activeCam = 1;
    private bool coolDown =false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R) && !coolDown)
        {
            // Debug.Log("Pressed");
            coolDown = true;

            if (activeCam == 1){
                cam1.SetActive(false);
                cam2.SetActive(true);
                activeCam = 2;
            }
            else{
                cam2.SetActive(false);
                cam1.SetActive(true);
                activeCam = 1;
            }
            player1.GetComponent<Player1Controller>().SwitchActive();
            player2.GetComponent<Player2Controller>().SwitchActive();
            StartCoroutine(SwitchDelay());    
        }
    }

        public IEnumerator SwitchDelay(){
        
        yield return new WaitForSeconds(0.5f);;
        coolDown = false;
        // Debug.Log("set it  to false");

    }
}
