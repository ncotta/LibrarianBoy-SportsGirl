using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
[Tooltip("If it is false door can't be used")]
    public bool Locked = false;
    [Tooltip("It is true for remote control only")]
    public bool Remote = false;
    [Space]
    [Tooltip("Door can be opened")]
    public bool CanOpen = true;
    [Tooltip("Door can be closed")]
    public bool CanClose = true;
    [Space]
    [Tooltip("Door locked by red key (use key script to declarate any object as key)")]
    public bool RedLocked = false;
    public bool BlueLocked = false;
    [Tooltip("It is used for key script working")]
    AN_HeroInteractive HeroInteractive;
    [Space]
    public bool isOpened = false;
    [Range(0f, 4f)]
    [Tooltip("Speed for door opening, degrees per sec")]
    public float OpenSpeed = 3f;

    // NearView()
    float distance;
    float angleView;
    Vector3 direction;

    // Hinge
    [HideInInspector]
    public Rigidbody rbDoor;
    HingeJoint hinge;
    JointLimits hingeLim;
    float currentLim;
    GameObject librarian;
    GameObject sportsGirl;

    void Start()
    {
        rbDoor = GetComponent<Rigidbody>();
        hinge = GetComponent<HingeJoint>();
        // HeroInteractive = FindObjectOfType<AN_HeroInteractive>();
        librarian = GameObject.FindGameObjectWithTag("Librarian");
        sportsGirl = GameObject.FindGameObjectWithTag("SportsGirl");
    }

    void Update()
    {
        if ( !Remote && Input.GetKeyDown(KeyCode.E) && NearView() ){
            Debug.Log("asd");
            Action();
        }
            
        
    }

    public void Action() // void to open/close door
    {
        if (!Locked)
        {
            // key lock checking
            if (HeroInteractive != null && RedLocked && HeroInteractive.RedKey)
            {
                RedLocked = false;
                HeroInteractive.RedKey = false;
            }
            else if (HeroInteractive != null && BlueLocked && HeroInteractive.BlueKey)
            {
                BlueLocked = false;
                HeroInteractive.BlueKey = false;
            }
            
            // opening/closing
            if (isOpened && CanClose && !RedLocked && !BlueLocked)
            {
                isOpened = false;
            }
            else if (!isOpened && CanOpen && !RedLocked && !BlueLocked)
            {
                isOpened = true;
                rbDoor.AddRelativeTorque(new Vector3(0, 0, 20f)); 
            }
        
        }
    }

    bool NearView() // it is true if you near interactive object
    {
        distance = Vector3.Distance(transform.position, sportsGirl.transform.position);
        direction = transform.position - sportsGirl.transform.position;
        angleView = Vector3.Angle(sportsGirl.transform.forward, direction);
        if (distance < 3f) return true; // angleView < 35f && 
        else return false;
    }

    public void Interact(){

            if (isOpened && CanClose && !RedLocked && !BlueLocked)
            {
                rbDoor.AddRelativeTorque(new Vector3(-2000f, -2000f, -2000f));
                isOpened= false; 
                hingeLim.max = 0f;
                hingeLim.min = 0f;
                hinge.limits = hingeLim;
            }
            else if (!isOpened && CanOpen && !RedLocked && !BlueLocked)
            {
                isOpened = true;
                hingeLim.max = 90f;
                hingeLim.min = -90f;
                hinge.limits = hingeLim;
                Debug.Log("opened");
                rbDoor.AddRelativeTorque(new Vector3(200f, 200f, 200f)); 
            }
    }

    // private void FixedUpdate() // door is physical object
    // {
    //     if (!isOpened)

    //     {
    //         // currentLim = hinge.angle; // door will closed from current opened angle
    //         if (currentLim > 1f)
    //             currentLim -= .5f * OpenSpeed;
    //     }

    //     // using values to door object
    //     hingeLim.max = currentLim;
    //     hingeLim.min = -currentLim;
    //     hinge.limits = hingeLim;
    // }
}
