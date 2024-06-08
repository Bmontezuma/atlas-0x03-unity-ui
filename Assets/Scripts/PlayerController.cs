using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // Include the SceneManager
using UnityEngine.UI;  // Include the UI namespace

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;  // Speed of the player
    private int score = 0;      // Score of the player
    public int health = 5;      // Health of the player, initial value 5
    public Text scoreText;      // Reference to the UI text element for displaying score
    public Text healthText;     // Reference to the UI text element for displaying health
    public Text winLoseText;    // Reference to the UI text element for displaying win/lose message
    public GameObject winLoseBG; // Reference to the UI Image element for the background

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
            // Display "Game Over!" message if winLoseText is assigned
            if (winLoseText != null)
            {
                winLoseText.text = "Game Over!";
                winLoseText.color = Color.white;
            }

            // Change WinLoseBG's color to red and activate it if winLoseBG is assigned
            if (winLoseBG != null)
            {
                winLoseBG.GetComponent<Image>().color = Color.red;
                winLoseBG.SetActive(true);
            }

            // Start coroutine to reload scene after 3 seconds
            StartCoroutine(LoadScene(3));

            // Comment out the Debug.Log line
            // Debug.Log("Game Over!");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the object we collided with is tagged as "Pickup"
        if (other.gameObject.CompareTag("Pickup"))
        {
            // Increment the score
            score++;

            // Update the score text UI
            SetScoreText();

            // Disable the Coin object
            other.gameObject.SetActive(false);
        }
        // Check if the object we collided with is tagged as "Trap"
        else if (other.gameObject.CompareTag("Trap"))
        {
            // Decrement the health
            health--;

            // Update the health text UI
            SetHealthText();

            // You can add game over logic or other consequences here
        }
        // Check if the object we collided with is tagged as "Goal"
        else if (other.gameObject.CompareTag("Goal"))
        {
            // Display "You Win!" message if winLoseText is assigned
            if (winLoseText != null)
            {
                winLoseText.text = "You Win!";
                winLoseText.color = Color.black;
            }

            // Change WinLoseBG's color to green and activate it if winLoseBG is assigned
            if (winLoseBG != null)
            {
                winLoseBG.GetComponent<Image>().color = Color.green;
                winLoseBG.SetActive(true);
            }

            // Start coroutine to reload scene after 3 seconds
            StartCoroutine(LoadScene(3));

            // Comment out the Debug.Log line
            // Debug.Log("You win!");

            // You can add additional logic for winning the game here
        }
    }

    void SetScoreText()
    {
        // Update the score text UI
        scoreText.text = "Score: " + score.ToString();
    }

    void SetHealthText()
    {
        // Update the health text UI
        healthText.text = "Health: " + health.ToString();
    }

    IEnumerator LoadScene(float seconds)
    {
        // Wait for the specified number of seconds
        yield return new WaitForSeconds(seconds);

        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        // Reset health and score
        health = 5;
        score = 0;

        // Update UI elements
        SetScoreText();
        SetHealthText();
    }
}
