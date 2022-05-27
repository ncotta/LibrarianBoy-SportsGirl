using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class PlayerClass : MonoBehaviour
{
    public float speed = 5.0f;
    public float rotationSpeed = 0.5f;
    public float jumpThrust = 15f;
    protected bool stopMovementFriction = true;

    protected bool isTurning = false;
    protected bool isGrounded;
    protected int pickupCount;
    protected Vector3 r = new Vector3(0f,0f,0f);

    public GameObject gameOverScreen;
    public GameObject gameDeathScreen;
    public Camera ownCam;
    public Camera otherCam;

    protected Rigidbody rb;

    public bool redKey = false;
    public bool blueKey = false;
    public bool greenKey = false;
    public bool dead = false;

    protected bool interacting = false;
    protected bool isActive;
    protected GameObject[] interactables;
    protected GameObject closest;
    protected float closestDist = 100f;
    string objectName;
    // Start is called before the first frame update

    public PlayerClass(){

    }


    void Start()
    {
        gameOverScreen.SetActive(false);
        gameDeathScreen.SetActive(false);
    }
    protected void EndLevel()
    {
        gameOverScreen.SetActive(true);
        StartCoroutine(QuitGame());
    }

    protected void EndLevel2()
    {
        gameDeathScreen.SetActive(true);
        StartCoroutine(QuitGame2());
    }

    IEnumerator QuitGame()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("Scenes/MainMenu");
    }

    IEnumerator QuitGame2()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") 
        || collision.gameObject.CompareTag("Obstacle") 
        || collision.gameObject.CompareTag("PressurePlate")
        || collision.gameObject.CompareTag("Box"))
        {
            isGrounded = true;
        }

    }

    protected void OnCollisionExit(Collision other)
    {
        // if (other.gameObject.CompareTag("Ground"))
        // {
        //     isGrounded = false;
        // }


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
        // Debug.Log(closest);
        if (closestDist < 8.0f){
            if (closest.name == "Lever"){
                Debug.Log("Interacting with lever");
                closest.GetComponent<LeverScript>().Interact();
            }
        }
    }

    public void SwitchActive(){
        if (isActive){
            isActive = false;
        }else{
            isActive = true;
        }
    }
}
