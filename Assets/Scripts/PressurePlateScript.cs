using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateScript : MonoBehaviour
{
    // Start is called before the first frame update
    private bool stepped = false;
    private bool wait = false;

    public string connectedElementName;
    GameObject connectedElement;

    void Start()
    {
        connectedElement = GameObject.Find(connectedElementName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("SportsGirl") || other.gameObject.CompareTag("Librarian"))
        {
            Debug.Log("Stepped");
            // stepped = true;
            // StartCoroutine(DelayDown());
            transform.position = new Vector3(transform.position.x, transform.position.y-0.4f, transform.position.z);
            other.gameObject.transform.position = new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y-0.4f, other.gameObject.transform.position.z);

            if (connectedElement.tag == "Door"){
                connectedElement.GetComponent<DoorScript>().Interact();
            }

        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("SportsGirl") || other.gameObject.CompareTag("Librarian"))
        {

            // stepped = false;
            // StartCoroutine(DelayUp());
            transform.position = new Vector3(transform.position.x, transform.position.y+0.4f, transform.position.z);
            other.gameObject.transform.position = new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y+0.4f, other.gameObject.transform.position.z);
            Debug.Log("Left");

            if (connectedElement.tag == "Door"){
                connectedElement.GetComponent<DoorScript>().Interact();
            }

        }
    }

    public IEnumerator DelayUp(){
        
        yield return new WaitForSeconds(1);
        if (!stepped){
            transform.position = new Vector3(transform.position.x, transform.position.y+0.4f, transform.position.z);
        }
        Debug.Log("set it  to false");

    }

    public IEnumerator DelayDown(){
        
        yield return new WaitForSeconds(1);
        if (stepped){
            transform.position = new Vector3(transform.position.x, transform.position.y-0.4f, transform.position.z);
        }
        Debug.Log("set it  to false");
    }
}
