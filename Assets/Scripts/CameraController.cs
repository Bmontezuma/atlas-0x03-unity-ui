using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;  // Public variable to assign the player GameObject in the Inspector
    private Vector3 offset;    // Private variable to store the offset distance between the player and camera

    void Start()
    {
        // Ensure player is assigned
        if (player == null)
        {
            Debug.LogError("Player GameObject not assigned in the CameraController script.");
            return;
        }

        // Calculate and store the offset value by getting the distance between the player's position and the camera's position
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        // Check if player is assigned
        if (player == null)
        {
            return;
        }

        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated distance
        transform.position = player.transform.position + offset;
    }
}

