using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControl : MonoBehaviour
{

    public float MotorForce, SteerForce, BrakeForce, friction;

    public WheelCollider FR_L_Wheel, FR_R_Wheel, RE_L_Wheel, RE_R_Wheel;
    public GameObject car;

    private float steeringAngle;
    private float horizontalInput;
    private float verticalInput;
    
    public void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        
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
    
    private void Steer()
    {
        steeringAngle = SteerForce * horizontalInput;
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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        Steer();
        Accelerate();
        //UpdateSubSteps();

    }
}
