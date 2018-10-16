using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifferentialWheeledRobot : MonoBehaviour
{
    [Header("Meshes")]
    public GameObject m_LeftWheelMesh;
    public GameObject m_RightWheelMesh;

    [Header("Offset Meshes")]
    public Vector3 m_LeftWheelOffset;
    public Vector3 m_RightWheelOffset;

    [Header("Colliders")]
    public WheelCollider m_LeftWheelCollider;
    public WheelCollider m_RightWheelCollider;

    [Header("Motor Properties")]
    public float m_MaxMotorTorque;
    public float m_BrakeTorque;
    public float m_DecelerationForce;

    [SerializeField]
    private float m_LeftMotorTorque;

    [SerializeField]
    private float m_RightMotorTorque;

    [SerializeField]
    private bool m_Braking;

    private void FixedUpdate()
    {
        Brake(m_Braking);
        Acceleration();
        ApplyLocalPositionToVisuals();
    }

    public void Acceleration()
    {
        Acceleration(m_LeftWheelCollider, m_LeftMotorTorque);
        Acceleration(m_RightWheelCollider, m_RightMotorTorque);
    }

    private void Acceleration(WheelCollider wheelCollider, float motorTorque)
    {
        if (motorTorque != 0f)
            wheelCollider.motorTorque = motorTorque * m_MaxMotorTorque;
        else       
            Deceleration(wheelCollider);
    }

    private void Deceleration(WheelCollider wheelCollider)
    {
        wheelCollider.brakeTorque = m_DecelerationForce;
    }

    private void Brake(bool braking)
    {
        if (braking)
        {
            m_LeftWheelCollider.brakeTorque = m_BrakeTorque;
            m_RightWheelCollider.brakeTorque = m_BrakeTorque;
        }
        else
        {
            m_LeftWheelCollider.brakeTorque = 0;
            m_RightWheelCollider.brakeTorque = 0;
        }
    }

    public void ApplyLocalPositionToVisuals()
    {
        Vector3 position;
        Quaternion rotation;

        m_LeftWheelCollider.GetWorldPose(out position, out rotation);
        if (m_LeftWheelMesh)
        {
            

            m_LeftWheelMesh.transform.position = position;
            m_LeftWheelMesh.transform.rotation = rotation * Quaternion.Euler(m_LeftWheelOffset);
        }

        m_RightWheelCollider.GetWorldPose(out position, out rotation);
        if (m_RightWheelMesh)
        {
            m_RightWheelMesh.transform.position = position;
            m_RightWheelMesh.transform.rotation = rotation * Quaternion.Euler(m_RightWheelOffset);
        }
    }

    /*


    void FixedUpdate()
    {
        float motor = m_MaxMotorTorque * Input.GetAxis("Vertical");
        float steering = m_MaxSteeringAngle * Input.GetAxis("Horizontal");
        bool braking = Input.GetButton("Jump");

        Brake(axleInfo, braking);

            if (axleInfo.steering)
                Steering(axleInfo, steering);   

            if (axleInfo.motor)
                Acceleration(axleInfo, motor);

            ApplyLocalPositionToVisuals(axleInfo);
        } 
    }

    private void Acceleration(AxleInfo axleInfo, float motor)
    {
        if (motor != 0f)
        {
            axleInfo.m_LeftWheelCollider.motorTorque = motor;
            axleInfo.rightWheelCollider.motorTorque = motor;
        }
        else
        {
            Deceleration(axleInfo);
        }
    }

    private void Deceleration(AxleInfo axleInfo)
    {
        axleInfo.m_LeftWheelCollider.brakeTorque = m_DecelerationForce;
        axleInfo.rightWheelCollider.brakeTorque = m_DecelerationForce;
    }

    private void Steering(AxleInfo axleInfo, float steering)
    {
        axleInfo.m_LeftWheelCollider.steerAngle = steering;
        axleInfo.rightWheelCollider.steerAngle = steering;
    }

    private void Brake(AxleInfo axleInfo, bool braking)
    {
        if (braking)
        {
            axleInfo.m_LeftWheelCollider.brakeTorque = m_BrakeTorque;
            axleInfo.rightWheelCollider.brakeTorque = m_BrakeTorque;
        }
        else
        {
            axleInfo.m_LeftWheelCollider.brakeTorque = 0;
            axleInfo.rightWheelCollider.brakeTorque = 0;
        }
    }
    */
}