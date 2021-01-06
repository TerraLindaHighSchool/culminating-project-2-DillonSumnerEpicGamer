using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //private variables
    [SerializeField] private float speed = 10.0f;
    private float speedLeft;
    [SerializeField] private float turnSpeed = 15.0f;
    private float nonDriftSpeed;
    private float driftSpeed = 250.0f;
    [SerializeField] private float horizontalInput;
    private float verticalInput;

    private int playerHealth = 100;

    private void Start()
    {
        nonDriftSpeed = turnSpeed;
        speedLeft = speed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //getting input
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        //move foreward
        
        if (Input.GetKey(KeyCode.Space) && speedLeft > 0)
        {
            turnSpeed = driftSpeed;
            speedLeft--;
        }
        else
        {
            speedLeft = speed;
            turnSpeed = nonDriftSpeed;
        }
        transform.Translate(Vector3.forward * Time.deltaTime * speedLeft * verticalInput);
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
    }
}
