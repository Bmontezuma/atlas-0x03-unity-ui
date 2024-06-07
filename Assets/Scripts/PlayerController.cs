using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // Include the SceneManager

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;  // Speed of the player
    private int score = 0;      // Score of the player
    public int health = 5;      // Health of the player, initial value 5

    void Start()
    {
        // Any initialization if needed
    }

    void FixedUpdate()
    {
        // Get input from the horizontal and vertical axes (arrow keys or WASD)
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Create a Vector3 movement based on input
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // Apply the movement to the player
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }

    void Update()
    {
        // Check if health is zero
        if (health == 0)
        {
            // Log "Game Over!" message
            Debug.Log("Game Over!");

            // Reload the scene to start again
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

            // Reset health and score
            health = 5;
            score = 0;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the object we collided with is tagged as "Pickup"
        if (other.gameObject.CompareTag("Pickup"))
        {
            // Increment the score
            score++;

            // Log the new score
            Debug.Log("Score: " + score);

            // Disable the Coin object
            other.gameObject.SetActive(false);
        }
        // Check if the object we collided with is tagged as "Trap"
        else if (other.gameObject.CompareTag("Trap"))
        {
            // Decrement the health
            health--;

            // Log the new health
            Debug.Log("Health: " + health);

            // You can add game over logic or other consequences here
        }
        // Check if the object we collided with is tagged as "Goal"
        else if (other.gameObject.CompareTag("Goal"))
        {
            // Log "You win!" message
            Debug.Log("You win!");

            // You can add additional logic for winning the game here
        }
    }
}
