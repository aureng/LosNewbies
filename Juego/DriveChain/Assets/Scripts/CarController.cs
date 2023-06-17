using UnityEngine;

public class CarController : MonoBehaviour
{
    public WheelCollider frontLeftWheel;
    public WheelCollider frontRightWheel;
    public WheelCollider rearLeftWheel;
    public WheelCollider rearRightWheel;
    public PlayerProfileSO ppSO;
    public GameEvent UpdateLifeEvent;

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
        // Obtener la velocidad máxima
        float maxSpeed = Mathf.Max(frontLeftWheel.rpm, frontRightWheel.rpm, rearLeftWheel.rpm, rearRightWheel.rpm) * 2 * Mathf.PI * rearLeftWheel.radius / 60;
       // Debug.Log("Velocidad máxima: " + maxSpeed + " m/s");    
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Concret"))
        {
            Concret concret = collision.gameObject.GetComponent<Concret>();
            if (concret != null)
            {
                ppSO.life -= concret.value;
                UpdateLifeEvent.Raise();
            }
        }
        else if (collision.gameObject.CompareTag("Cone"))
        {
            Cone cone = collision.gameObject.GetComponent<Cone>();
            if (cone != null)
            {
                if (ppSO.def >= cone.value)
                {
                    Debug.Log("OK");
                }
                else
                {
                    ppSO.life -= cone.value;
                    UpdateLifeEvent.Raise();
                }
            }
        }
    }
    
}
