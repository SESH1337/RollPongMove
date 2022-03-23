using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpForawrd : MonoBehaviour
{
    public bool isFlat = true;
    public float moveSpeedObj;
    private Rigidbody rb;
    public float jumpHigh;
    public float forwardSpeed;

    public AudioSource hitPingPongSound;

    private float zeroForSmooth = 0;
    private Touch touch;
    public float speedModifier;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speedModifier = 1.15f;    
    }

    // Update is called once per frame
    void Update()
    {
     
        
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
           
        
            if (touch.phase == TouchPhase.Moved)
            {
               Vector3 newPlayerMove = new Vector3(
                    transform.position.x + zeroForSmooth + touch.deltaPosition.x * speedModifier * Time.deltaTime,
                    transform.position.y,
                    transform.position.z);


              transform.position = Vector3.Lerp(transform.position, newPlayerMove, moveSpeedObj);
            }
        }

        
    }

    private void OnCollisionEnter(Collision other)
    {
        // if (other.gameObject.tag == "targetJump")
        // {
        //     Debug.Log("adD");
        //     rb.AddForce(0,500,0);
        //     rb.velocity = new Vector3(0, 0, 35 * Time.deltaTime);
        // }
        if(other.gameObject.tag == "targetJump"){
            var g = Physics.gravity.magnitude; // get the gravity value
            var vSpeed = Mathf.Sqrt(0.2f * g * jumpHigh); // calculate the vertical speed
            rb.velocity = new Vector3(0, vSpeed, forwardSpeed);
            hitPingPongSound.Play();
        }
        
    }
    
    
    
    
}
