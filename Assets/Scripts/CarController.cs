using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// Basic controls for the car
/// </summary>
public class CarController : MonoBehaviour {

    Rigidbody rb;

    bool accelerate;
    bool turnLeft;
    bool turnRight;

    //variables for movement & controls calibration
    float drag = 0.5f;
    float throttlePower = 50;
    float steeringPower = 2;     

	// Use this for initialization
	void Start () {
        rb = this.GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {

        //player is holding accBtn --> speed up
        if(accelerate)
        {
            rb.AddForce(transform.forward * throttlePower);
            rb.drag = drag; 
        }

        //player is not holding accBtn -> slow down
        else
        {
            rb.drag = drag * 2;
        }

        //player is holding rotation btn -> steer
        if (turnLeft)
        {
            transform.Rotate(0, -steeringPower, 0);
        }
        else if (turnRight)
        {
            transform.Rotate(0, steeringPower, 0);
        }		
	}

    //Btn Handlers (onPressed & onReleased)
    public void AccBtnPressed()
    {
        accelerate = true;
    }

    public void AccBtnReleased()
    {
        accelerate = false;
    }

    public void LeftBtnPressed()
    {
        turnLeft = true;
    }

    public void LeftBtnReleased()
    {
        turnLeft = false;
    }

    public void RBtnPressed()
    {
        turnRight = true;
    }

    public void RBtnReleased()
    {
        turnRight = false;
    }
}
