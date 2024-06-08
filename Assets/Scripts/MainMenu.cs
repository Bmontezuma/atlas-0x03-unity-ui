using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Material trapMat;
    public Material goalMat;
    public Toggle colorblindMode;

    public void PlayMaze()
    {
        if (colorblindMode != null && colorblindMode.isOn)
        {
            trapMat.color = new Color32(255, 112, 0, 255); // Ensure the correct alpha value
            goalMat.color = Color.blue;
        }

        SceneManager.LoadScene("maze"); // Ensure "maze" matches the exact name of your maze scene
    }

    public void QuitMaze()
    {
        Debug.Log("Quit Game");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
