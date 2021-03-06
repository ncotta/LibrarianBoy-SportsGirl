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
    
    public AudioSource FailureAudio;
    public bool m_HasAudioPlayed;
    public AudioSource BoxPush;

    protected Rigidbody rb;

    public bool dead = false;

    protected bool interacting = false;
    protected bool isActive;
    protected GameObject[] interactables;
    protected GameObject closest;
    protected float closestDist = 100f;


    public PlayerClass(){

    }


    void Start()
    {
        gameOverScreen.SetActive(false);
        gameDeathScreen.SetActive(false);
        m_HasAudioPlayed = false;
    }
    protected void EndLevel()
    {
        if(!m_HasAudioPlayed)
        {
            FailureAudio.Play();
            m_HasAudioPlayed = true;
        }
        
        gameOverScreen.SetActive(true);
        StartCoroutine(QuitGame());
    }

    protected void EndLevel2()
    {
        if(!m_HasAudioPlayed)
        {
            FailureAudio.Play();
            m_HasAudioPlayed = true;
        }
        
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
        
        if(collision.gameObject.CompareTag("Box"))
        {
            if(!BoxPush.isPlaying)
            {
                BoxPush.Play();
            }
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
