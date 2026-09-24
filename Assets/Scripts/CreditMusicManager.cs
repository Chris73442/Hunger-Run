using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditMusicManager : MonoBehaviour
{
    public void BackToMenu()
    {
        if (BGMManager.Instance != null)
        {
            BGMManager.Instance.RestartMusic();
        }

        SceneManager.LoadScene("MainMenuScene");
    }
}
