using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightsOn : MonoBehaviour
{
    public GameObject lights1, lights2, lights3;

    void Start()
    {
        lights1.SetActive(false);
        lights2.SetActive(false);
        lights3.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SportsGirl") || other.CompareTag("Librarian"))
        {
            StartCoroutine(Timer(lights1, 1));
            StartCoroutine(Timer(lights2, 2));
            StartCoroutine(Timer(lights3, 3));
        }
    }

    IEnumerator Timer(GameObject light, float secs)
    {
        yield return new WaitForSeconds(secs);
        light.SetActive(true);
    }    
}
