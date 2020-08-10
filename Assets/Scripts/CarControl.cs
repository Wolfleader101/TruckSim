using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class CarControl : MonoBehaviour
{
    private AudioSource startSound;
    private AudioSource drivingSound;

    public float MotorForce, SteerForce, BrakeForce;

    public WheelCollider FR_L_Wheel, FR_R_Wheel, RE_L_Wheel, RE_R_Wheel;
    public GameObject car;

    private float steeringAngle;
    private float horizontalInput;
    private float verticalInput;
    
    // Start is called before the first frame update
    void Start()
    {

        startSound = gameObject.AddComponent<AudioSource>();
        drivingSound = gameObject.AddComponent<AudioSource>();;
        
        startSound.clip = Resources.Load("Sounds/CarStart") as AudioClip;
        drivingSound.clip = Resources.Load("Sounds/CarDrive") as AudioClip;
        drivingSound.time = 2f;
        
       startSound.Play();
    }
    
    public void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if (verticalInput > 0 && !drivingSound.isPlaying)
        {
            drivingSound.Play();
            StartCoroutine(StopSound(5f));
        }

        if (Input.GetKey(KeyCode.Space))
        {
            RE_L_Wheel.brakeTorque = BrakeForce;
            RE_R_Wheel.brakeTorque = BrakeForce;
        }
        
        if (Input.GetKeyUp(KeyCode.Space))
        {
            RE_L_Wheel.brakeTorque = 0;
            RE_R_Wheel.brakeTorque = 0;
        }
    }

    IEnumerator StopSound(float time)
    {
        yield return new WaitForSeconds(time);
        drivingSound.Stop();
    }
    
    private void Steer()
    {
        steeringAngle = SteerForce * Time.deltaTime * horizontalInput;
        FR_L_Wheel.steerAngle = steeringAngle;
        FR_R_Wheel.steerAngle = steeringAngle;
    }
    
    private void Accelerate()
    {
        
        RE_L_Wheel.motorTorque = verticalInput * MotorForce;
        RE_R_Wheel.motorTorque = verticalInput * MotorForce;
    }

    private void UpdateSubSteps()
    {
        FR_L_Wheel.ConfigureVehicleSubsteps(50,50,50);
        FR_R_Wheel.ConfigureVehicleSubsteps(50,50,50);
        RE_R_Wheel.ConfigureVehicleSubsteps(50,50,50);
        RE_L_Wheel.ConfigureVehicleSubsteps(50,50,50);
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    private void FixedUpdate()
    {
        Steer();
        Accelerate();
    }
}
