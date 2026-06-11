using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float forwardSpeed = 5f;
    public float sideSpeed = 5f;

    [Header("Speed Increase")]
    public float speedIncreaseRate = 1f;
    public float maxSpeed = 30f;

    [Header("Lane Boundary")]
    public float minX = -4f;
    public float maxX = 4f;

    [Header("Hunger")]
    public float maxHunger = 100f;
    public float currentHunger = 100f;
    public float hungerDecreaseRate = 10f;

    [Header("Food & Poop")]
    public float foodRestore = 10f;
    public float poopDamage = 20f;

    [Header("UI")]
    public TMP_Text scoreText;
    public Image hungerImage;

    [Header("Hunger Sprites")]
    public Sprite[] hungerSprites;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip foodSfx;
    public AudioClip poopSfx;

    private int score = 0;

    void Start()
    {
        currentHunger = maxHunger;
        score = 0;

        scoreText.text = "Score : 0";
        UpdateHungerBar();
    }

    void Update()
    {
        MovePlayer();
        IncreaseSpeed();
        HungerSystem();
        UpdateUI();
        CheckGameOver();
    }

    void MovePlayer()
    {
        // Auto Run
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);

        // Tombol A
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * sideSpeed * Time.deltaTime);
        }

        // Tombol D
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * sideSpeed * Time.deltaTime);
        }

        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        transform.position = pos;
    }

    void IncreaseSpeed()
    {
        forwardSpeed += speedIncreaseRate * Time.deltaTime;
        forwardSpeed = Mathf.Clamp(forwardSpeed, 0, maxSpeed);
    }

    void HungerSystem()
    {
        currentHunger -= hungerDecreaseRate * Time.deltaTime;
        currentHunger = Mathf.Clamp(currentHunger, 0, maxHunger);

        UpdateHungerBar();
    }

    void UpdateUI()
    {
        scoreText.text = "Score : " + score;
    }

    void UpdateHungerBar()
    {
        if (hungerSprites == null || hungerSprites.Length == 0)
            return;

        float percent = currentHunger / maxHunger;

        int index = Mathf.RoundToInt(percent * 10);
        index = Mathf.Clamp(index, 0, hungerSprites.Length - 1);

        hungerImage.sprite = hungerSprites[index];
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Food"))
        {
            currentHunger += foodRestore;
            currentHunger = Mathf.Clamp(currentHunger, 0, maxHunger);

            score += 10;

            if (audioSource && foodSfx)
                audioSource.PlayOneShot(foodSfx);

            UpdateHungerBar();
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Poop"))
        {
            currentHunger -= poopDamage;
            currentHunger = Mathf.Clamp(currentHunger, 0, maxHunger);

            if (audioSource && poopSfx)
                audioSource.PlayOneShot(poopSfx);

            UpdateHungerBar();
            Destroy(other.gameObject);
        }
    }

    void CheckGameOver()
    {
        if (currentHunger <= 0)
        {
            PlayerPrefs.SetInt("FinalScore", score);
            PlayerPrefs.Save();

            SceneManager.LoadScene("FailedScene");
        }
    }
}