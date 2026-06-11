using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditRoll : MonoBehaviour
{
    public float speed = 100f;
    public float endY = 2900f;

    private RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        rectTransform.anchoredPosition += Vector2.up * speed * Time.deltaTime;

        if (rectTransform.anchoredPosition.y > endY)
        {
            SceneManager.LoadScene("MainMenuScene");
        }
    }
}