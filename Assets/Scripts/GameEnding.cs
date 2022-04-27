using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameEnding : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    void Start()
    {
        gameOverText.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.CompareTag("Ending"))
       {
            EndLevel();
       }
    }

    private void EndLevel()
    {
        gameOverText.enabled = true;
        // Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
