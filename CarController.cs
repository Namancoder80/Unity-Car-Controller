using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
[RequireComponent(typeof(Rigidbody))]
public class CarController : MonoBehaviour {
    [SerializeField] private Vehicle vehicle;

    private float verticalInput;
    private float horizontalInput;

    private Rigidbody rigidbody;
    private void OnEnable() {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.centerOfMass = vehicle.COM.transform.localPosition;
    }
    
    private void FixedUpdate() {
        MoterForce();
        UpdateWheel();
        GetAxis();
        streeing();
        ApplyBreak();   
    }

    private void streeing() {
        vehicle.frontRightWheelCollider.steerAngle = 30 * horizontalInput;
        vehicle.frontLeftWheelCollider.steerAngle= 30 * horizontalInput;
    }

    private void MoterForce() {
        vehicle.frontRightWheelCollider.motorTorque = 100*verticalInput;
        vehicle.frontLeftWheelCollider.motorTorque = 100*verticalInput;
    }

    private void GetAxis() {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
    }
    private void UpdateWheel() {
        rotateWheel(vehicle.frontRightWheelCollider, vehicle.frontRightWheel);
        rotateWheel(vehicle.frontLeftWheelCollider, vehicle.frontLeftWheel);
        rotateWheel(vehicle.rearLeftWheelCollider, vehicle.rearLeftWheel);
        rotateWheel(vehicle.rearRightWheelCollider, vehicle.rearRightWheel);
    }
    private void rotateWheel(WheelCollider wheel, Transform wheelTransform) {
        wheel.GetWorldPose(out Vector3 pos, out Quaternion rot);
        wheelTransform.position = pos;
        wheelTransform.rotation = rot;
    }

    private void ApplyBreak() {
        if (Input.GetKey(KeyCode.Space)) {
            vehicle.frontLeftWheelCollider.brakeTorque = 1000f;
            vehicle.frontRightWheelCollider.brakeTorque = 1000f;
            vehicle.rearRightWheelCollider.brakeTorque = 1000f;
            vehicle.rearLeftWheelCollider.brakeTorque = 1000f;
        } else {
            vehicle.frontLeftWheelCollider.brakeTorque = 0f;
            vehicle.frontRightWheelCollider.brakeTorque = 0f;
            vehicle.rearRightWheelCollider.brakeTorque = 0f;
            vehicle.rearLeftWheelCollider.brakeTorque = 0f;
        }
    }

   
}

[System.Serializable]
public class Vehicle {

    [Header("Wheel Collider")]
    public WheelCollider frontRightWheelCollider;
    public WheelCollider frontLeftWheelCollider;
    public WheelCollider rearRightWheelCollider;
    public WheelCollider rearLeftWheelCollider;

    [Header("Wheel Transform")]
    public Transform frontRightWheel;
    public Transform frontLeftWheel;
    public Transform rearRightWheel;
    public Transform rearLeftWheel;

    [Header("Center Of Mass")]
    public Transform COM;

}