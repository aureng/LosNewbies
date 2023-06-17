using UnityEngine;

public class CarController : MonoBehaviour
{
    public WheelCollider frontLeftWheel;
    public WheelCollider frontRightWheel;
    public WheelCollider rearLeftWheel;
    public WheelCollider rearRightWheel;

    public float motorTorque = 500f; // Torque del motor
    public float maxSteeringAngle = 30f; // Ángulo máximo de giro

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Control del giro de las ruedas delanteras
        float steeringAngle = maxSteeringAngle * horizontalInput;
        frontLeftWheel.steerAngle = steeringAngle;
        frontRightWheel.steerAngle = steeringAngle;

        // Control de la tracción de las ruedas traseras
        float torque = motorTorque * verticalInput;
        rearLeftWheel.motorTorque = torque;
        rearRightWheel.motorTorque = torque;
    }
}
