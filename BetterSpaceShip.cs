using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterSpaceShip : MonoBehaviour
{
    public Rigidbody rb;
    public float verticle;
    public float horizontal;
    public float mouseX;
    public float mouseY;
    public float roll;
    public float joyX;
    public float joyY;
    public float thrust;
    public float turn;
    public float JJMult;
    public InputTest IT;
    public joyjoy JJ;
    public float ITMult = 5;
    public float speedMult = 1;
    [SerializeField]
    public float speedMultAngle = 0.5f;
    [SerializeField]
    public float speedRollMultAngle = 0.05f;
    public bool isAccelerating;
    // Start is called before the first frame update
    void Start()
    {
        isAccelerating = true;
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        verticle = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        roll = Input.GetAxis("Roll");
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        thrust = IT.definitiveSpeed*ITMult;
        turn = JJ.definitiveTurn*JJMult;

        if (turn < 0.18&&turn>-0.1)
        {
            turn = 0;
        }
        else
        {
            turn = JJ.definitiveTurn * JJMult;
        }
    }
    private void FixedUpdate()
    {
        rb.AddTorque(rb.transform.forward * speedRollMultAngle * horizontal*-10, ForceMode.VelocityChange);
        rb.AddTorque(rb.transform.up *speedMultAngle* turn, ForceMode.VelocityChange);
        rb.AddTorque(rb.transform.right * speedMultAngle*verticle, ForceMode.VelocityChange);
        rb.AddForce(rb.transform.TransformDirection(Vector3.right)* speedMult, ForceMode.VelocityChange);
        rb.AddForce(rb.transform.TransformDirection(Vector3.forward) * speedMult*thrust, ForceMode.VelocityChange);
    }
}
