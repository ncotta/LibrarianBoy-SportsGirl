using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayInfo : MonoBehaviour
{
    public RectTransform instructions;

    void Start()
    {
        instructions.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("SportsGirl") || collision.gameObject.CompareTag("Librarian"))
        {
            instructions.gameObject.SetActive(true);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("SportsGirl") || collision.gameObject.CompareTag("Librarian"))
        {
            instructions.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
