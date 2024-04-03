using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMover : MonoBehaviour
{
    public Transform frog;  // Reference to the frog's Transform
    public float speed = 10.0f;  // Adjust the speed as needed

    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        // Calculate the new position based on the frog's x-position
        Vector3 newPosition = new Vector3(frog.position.x + initialPosition.x, initialPosition.y, initialPosition.z);

        // Move the background container
        transform.position = Vector3.Lerp(transform.position, newPosition, speed * Time.deltaTime);
    }
}
