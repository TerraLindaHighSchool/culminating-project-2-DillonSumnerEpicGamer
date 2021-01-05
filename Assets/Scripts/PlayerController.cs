using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    //private variables
    [SerializeField] private float speed;
    [SerializeField] private float horsePower = 100000.0f;
    [SerializeField] private float RPM;
    private float turnSpeed = 15.0f;
    private float horizontalInput;
    private float verticalInput;
    private Rigidbody rb;
    [SerializeField] private GameObject centerOfMass;
    [SerializeField] private TextMeshProUGUI speedometerText;
    [SerializeField] private TextMeshProUGUI RPMText;
    [SerializeField] private List<WheelCollider> allWheels;
    [SerializeField] int wheelsOnGround;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = centerOfMass.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //getting input
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        if (IsOnGround())
        {
            rb.AddRelativeForce(Vector3.forward * horsePower * verticalInput);

            //move foreward
            //transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);

            speed = Mathf.RoundToInt(rb.velocity.magnitude * 2.237f);
            speedometerText.SetText("Speed: " + speed + "mph");

            RPM = (speed % 30) * 40;
            RPMText.SetText("RPM: " + RPM);
        }
    }

    bool IsOnGround()
    {
        wheelsOnGround = 0;
        foreach (WheelCollider wheel in allWheels)
        {
            if (wheel.isGrounded)
            {
                wheelsOnGround++;
            }
        }
        if (wheelsOnGround == allWheels.Count)
        {
            return true;   
        }
        else
        {
            return false;
        }
    }
}
