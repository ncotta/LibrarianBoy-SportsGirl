using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerClass : MonoBehaviour
{
    public float speed = 5.0f;
    public float rotationSpeed = 0.5f;
    public float jumpThrust = 15f;

    protected bool isTurning = false;
    protected bool isGrounded;
    protected int pickupCount;
    protected Vector3 r = new Vector3(0f,0f,0f);

    protected Rigidbody rb;
    public TextMeshProUGUI gameOverText;

    public bool redKey = false;
    public bool blueKey = false;
    public bool greenKey = false;

    protected bool interacting = false;
    protected GameObject[] interactables;
    protected GameObject closest;
    protected float closestDist = 100f;
    string objectName;
    // Start is called before the first frame update

    public PlayerClass(){

    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

    }

    protected void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            pickupCount++;
        }
    
        if (other.gameObject.CompareTag("Ending"))
        {
            EndLevel();
        }
    }


    protected void EndLevel()
    {
        //gameOverText.enabled = true;
        Application.Quit();
    }

    public IEnumerator InteractDelay(){
        
        yield return new WaitForSeconds(0.5f);;
        interacting = false;
        Debug.Log("set it  to false");

    }

    public void Interact(){
        foreach(GameObject interactable in interactables){
            float dist = Vector3.Distance(interactable.transform.position, gameObject.transform.position);
            if (dist < closestDist){
                closest = interactable;
                closestDist = dist;
            }
        }
        Debug.Log(closest);
        if (closestDist < 8.0f){
            if (closest.name == "Lever"){
                Debug.Log("Interacting with lever");
                closest.GetComponent<LeverScript>().Interact();
            }
        }
    }
}
