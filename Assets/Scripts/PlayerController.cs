using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    private int score = 0;
    public int health = 5;
    public Text scoreText;
    public Text healthText;
    public Text winLoseText;
    public GameObject winLoseBG;

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }

    void Update()
    {
        if (health == 0)
        {
            if (winLoseText != null)
            {
                winLoseText.text = "Game Over!";
                winLoseText.color = Color.white;
            }

            if (winLoseBG != null)
            {
                winLoseBG.GetComponent<Image>().color = Color.red;
                winLoseBG.SetActive(true);
            }

            StartCoroutine(LoadScene(3));
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("menu");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            score++;
            SetScoreText();
            other.gameObject.SetActive(false);
        }
        else if (other.gameObject.CompareTag("Trap"))
        {
            health--;
            SetHealthText();
        }
        else if (other.gameObject.CompareTag("Goal"))
        {
            if (winLoseText != null)
            {
                winLoseText.text = "You Win!";
                winLoseText.color = Color.black;
            }

            if (winLoseBG != null)
            {
                winLoseBG.GetComponent<Image>().color = Color.green;
                winLoseBG.SetActive(true);
            }

            StartCoroutine(LoadScene(3));
        }
    }

    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    void SetHealthText()
    {
        healthText.text = "Health: " + health.ToString();
    }

    IEnumerator LoadScene(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        health = 5;
        score = 0;

        SetScoreText();
        SetHealthText();
    }
}
