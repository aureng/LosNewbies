using UnityEngine;

public class CarController : MonoBehaviour
{
    public WheelCollider frontLeftWheel;
    public WheelCollider frontRightWheel;
    public WheelCollider rearLeftWheel;
    public WheelCollider rearRightWheel;
    public PlayerProfileSO ppSO;
    public GameEvent UpdateLifeEvent;
    public GameEvent OpenMenuEvent;

    public float motorTorque = 500f; // Torque del motor
    public float maxSteeringAngle = 30f; // Ángulo máximo de giro
    float steeringAngle;
    float maxSpeed=0;
    float torque=0;

    private void Update()
    {
        LimitRotation();
        OpenMenu();
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        if(verticalInput<0 && maxSpeed > 0)
        {
            verticalInput = verticalInput * 2;
        }
        steeringAngle = maxSteeringAngle * horizontalInput;  
        // Control del giro de las ruedas delanteras
        
        frontLeftWheel.steerAngle = steeringAngle;
        frontRightWheel.steerAngle = steeringAngle;

        // Control de la tracción de las ruedas traseras
        if(maxSpeed<=ppSO.speed*10){
            torque = motorTorque * verticalInput; 
            rearLeftWheel.motorTorque = torque;
            rearRightWheel.motorTorque = torque;
        }
        else
        {
            rearLeftWheel.motorTorque = 0;
            rearRightWheel.motorTorque = 0;
        }
        
        // Obtener la velocidad máxima
        maxSpeed = Mathf.Max( rearLeftWheel.rpm, rearRightWheel.rpm) * 2 * Mathf.PI * rearLeftWheel.radius / 60;
       Debug.Log("Velocidad máxima: " + maxSpeed + " m/s");    
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
    private void LimitRotation()
    {
        float currentRotation = transform.eulerAngles.z;

        // Limitar la rotación en el eje Z a un rango de -20 a 20 grados
        if (currentRotation > 180f)
        {
            currentRotation -= 360f;
        }

        float clampedRotation = Mathf.Clamp(currentRotation, -20f, 20f);

        transform.eulerAngles = new Vector3(
            transform.eulerAngles.x,
            transform.eulerAngles.y,
            clampedRotation
        );
    }
    private void OpenMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OpenMenuEvent.Raise();
        }
    }
}
