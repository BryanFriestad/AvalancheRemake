using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Rigidbody rigidbody;
    public float JumpSpeed;

    public float minSlideSpeed;
    public float maxSlideSpeed;
    private float slideDirection;
    private float slideSpeed;

    private float slideStartTime;
    public float timeToSlideSpeedInc;
    public float timeToMaxSlide;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.AddForce(new Vector3(0, JumpSpeed, 0), ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            slideDirection = -1f;
            slideSpeed = minSlideSpeed;
            slideStartTime = Time.time;
        }
        else if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){
            float holdTime = Time.time - slideStartTime;
            if(holdTime >= timeToMaxSlide)
            {
                slideSpeed = maxSlideSpeed;
            }
            else if(holdTime <= timeToSlideSpeedInc)
            {
                slideSpeed = minSlideSpeed;
            }
            else
            {
                slideSpeed = ((holdTime - timeToSlideSpeedInc) / (timeToMaxSlide - timeToSlideSpeedInc) * (maxSlideSpeed - minSlideSpeed)) + minSlideSpeed;
            }
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            slideDirection = 1f;
            slideSpeed = minSlideSpeed;
            slideStartTime = Time.time;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            float holdTime = Time.time - slideStartTime;
            if (holdTime >= timeToMaxSlide)
            {
                slideSpeed = maxSlideSpeed;
            }
            else if (holdTime <= timeToSlideSpeedInc)
            {
                slideSpeed = minSlideSpeed;
            }
            else
            {
                slideSpeed = ((holdTime - timeToSlideSpeedInc) / (timeToMaxSlide - timeToSlideSpeedInc) * (maxSlideSpeed - minSlideSpeed)) + minSlideSpeed;
            }
        }

        if(!(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && !(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)))
        {
            slideSpeed = 0;
            slideDirection = 0;
        }

        rigidbody.velocity = new Vector3(slideDirection * slideSpeed, rigidbody.velocity.y, 0);
    }
}
