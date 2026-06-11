using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FailedScene : MonoBehaviour
{
    public TMP_Text scoreText;

    void Start()
    {
        int score =
            PlayerPrefs.GetInt("FinalScore", 0);

        scoreText.text ="Score : " + score;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("GameplayScene");
        }
    }

    public void RetryGame()
    {
        SceneManager.LoadScene("GameplayScene");
    }

    public void BackToMenu()
    {
        if (BGMManager.Instance != null)
        {
            BGMManager.Instance.RestartMusic();
        }

        SceneManager.LoadScene("MainMenuScene");
    }
}