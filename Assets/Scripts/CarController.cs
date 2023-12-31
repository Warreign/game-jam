using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// inspiration: https://www.youtube.com/watch?v=jr4eb4F9PSQ

public class CarController : MonoBehaviour
{
    public enum Axel
    {
        Front,
        Rear
    }

    [Serializable]
    public struct Wheel
    {
        public GameObject wheelModel;
        public WheelCollider wheelCollider;
        //public GameObject wheelEffectObj;
        //public ParticleSystem smokeParticle;
        public Axel axel;
        public Quaternion initRot;
    }

    public float maxAcceleration = 30.0f;
    public float brakeAcceleration = 1.5f;
    public float brakeAccelerationButton = 5.0f;
    public float maxSpeed = 80.0f;

    public float turnSensitivity = 0.3f;
    public float maxSteerAngle = 30.0f;

    public Vector3 _centerOfMass;

    public List<Wheel> wheels;

    float moveInput;
    float steerInput;

    public Rigidbody carRb;

    void Update()
    {
        GetInputs();
        AnimateWheels();
        if (wheels[0].wheelModel.transform.position.y < -5)
            Debug.Log("GameOver");
        //WheelEffects();
    }

    void LateUpdate()
    {
        Move();
        Steer();
        Brake();
    }

    public void MoveInput(float input)
    {
        moveInput = input;
    }

    public void SteerInput(float input)
    {
        steerInput = input;
    }

    void GetInputs()
    {
        moveInput = Input.GetAxis("Vertical");
        steerInput = Input.GetAxis("Horizontal");
        //if (moveInput != 0)
            //Debug.Log("Vertical: " + moveInput + "Horizontal " + steerInput);
    }

    void Move()
    {
        foreach(var wheel in wheels)
        {
            wheel.wheelCollider.motorTorque = moveInput * 200f * maxAcceleration /** Time.deltaTime*/;
            if (wheel.wheelCollider.motorTorque < 0)
                wheel.wheelCollider.motorTorque = Math.Max(-maxSpeed, wheel.wheelCollider.motorTorque);
            else
                wheel.wheelCollider.motorTorque = Math.Min(maxSpeed, wheel.wheelCollider.motorTorque);

            Debug.Log(wheel.wheelCollider.motorTorque);
        }
    }

    void Steer()
    {
        foreach(var wheel in wheels)
        {
            if (wheel.axel == Axel.Front)
            {
                var _steerAngle = steerInput * turnSensitivity * maxSteerAngle;
                wheel.wheelCollider.steerAngle = Mathf.Lerp(wheel.wheelCollider.steerAngle, _steerAngle, 0.6f);
                //Debug.Log(_steerAngle + " " + wheel.wheelCollider.steerAngle);
            }
        }
    }

    void Brake()
    {
        if (Input.GetKey(KeyCode.Space) || moveInput == 0)
        {
            foreach (var wheel in wheels)
            {
                if(moveInput == 0)
                    wheel.wheelCollider.brakeTorque = 200 * brakeAcceleration /* * Time.deltaTime*/;
                else
                    wheel.wheelCollider.brakeTorque = 200 * brakeAccelerationButton /* * Time.deltaTime*/;

            }
        }
        else
        {
            foreach (var wheel in wheels)
            {
                wheel.wheelCollider.brakeTorque = 0;
            }
        }
    }

    void AnimateWheels()
    {
        foreach(var wheel in wheels)
        {
            Quaternion rot;
            Vector3 pos;
            wheel.wheelCollider.GetWorldPose(out pos, out rot);
            wheel.wheelModel.transform.position = pos;
            wheel.wheelModel.transform.rotation = rot * wheel.initRot;
        }
    }

    void WheelEffects()
    {
        foreach (var wheel in wheels)
        {
            //var dirtParticleMainSettings = wheel.smokeParticle.main;

            if (Input.GetKey(KeyCode.Space) && wheel.axel == Axel.Rear && wheel.wheelCollider.isGrounded == true && carRb.velocity.magnitude >= 10.0f)
            {
                //wheel.wheelEffectObj.GetComponentInChildren<TrailRenderer>().emitting = true;
                //wheel.smokeParticle.Emit(1);
            }
            else
            {
                //wheel.wheelEffectObj.GetComponentInChildren<TrailRenderer>().emitting = false;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        carRb.centerOfMass = _centerOfMass;
        for(int i = 0; i < wheels.Count; i++)
        {
            Wheel wheelLocal = wheels[i];
            wheelLocal.initRot = wheelLocal.wheelModel.transform.rotation;
            wheels[i] = wheelLocal;
        }

        gameObject.SetActive(false);
    }
}
