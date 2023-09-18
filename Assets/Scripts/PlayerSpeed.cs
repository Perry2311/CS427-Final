using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class RollingBallPivot : MonoBehaviour
{
    public float defaultSpeed = 5.0f;       // The default speed of the ball
    public float maxSpeed = 30.0f;          // The maximum speed the ball can reach
    public float speedIncreaseRate = 1f;  // Speed increase rate per 30 seconds

    private Rigidbody ballRigidbody;        // Reference to the ball's Rigidbody
    private float currentTime = 0.0f;       // Current time elapsed
    private float currentSpeed;             // Current speed of the ball

    private void Start()
    {
        ballRigidbody = transform.GetChild(0).GetComponent<Rigidbody>(); // Assuming the ball is the first child
        currentSpeed = defaultSpeed;
    }

    private void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= 5.0f) // Check if 30 seconds have passed
        {
            currentTime = 0.0f; // Reset time

            // Increase the speed by the specified rate, but not beyond the maximum speed
            currentSpeed = Mathf.Min(currentSpeed + speedIncreaseRate, maxSpeed);
            Debug.Log("Current Speed: " + currentSpeed);
            // Apply the new speed to the ball's Rigidbody velocity
            ballRigidbody.velocity = transform.forward * currentSpeed;
        }
    }
}