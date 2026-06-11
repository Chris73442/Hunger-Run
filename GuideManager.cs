using UnityEngine;
using UnityEngine.SceneManagement;

public class GuideManager : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("GameplayScene");
        }
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