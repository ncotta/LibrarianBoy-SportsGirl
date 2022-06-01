using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;

public class BoxScript : MonoBehaviour
{
    AudioSource BoxPush;
    public Rigidbody rbBox;
    
    //Vector3 curPos;
    Vector3 lastPos;
    
    // Start is called before the first frame update
    private void Start()
    {
        rbBox = GetComponent<Rigidbody>();
        BoxPush = GetComponent<AudioSource>();
        //curPos = transform.position;
        lastPos = transform.position;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //curPos = transform.position;
        if(rbBox.transform.position != lastPos)
        {
            if(!BoxPush.isPlaying)
            {
                BoxPush.Play();
            }
        } else
        {
            BoxPush.Stop();
        }
    }
}
