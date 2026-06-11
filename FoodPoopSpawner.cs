using UnityEngine;

public class FoodPoopSpawner : MonoBehaviour
{
    public Transform player;

    public GameObject[] foods;

    public GameObject poopPrefab;

    public float spawnDistance = 50f;
    public float spawnInterval = 1.5f;
    public float laneWidth = 4f;

    [Header("Difficulty")]
    public float foodChance = 0.9f;      // Awal 90% food
    public float minFoodChance = 0.5f;   // Minimal 50% food
    public float decreaseRate = 0.01f;   // Turun per detik

    void Start()
    {
        InvokeRepeating(nameof(SpawnObject), 1f, spawnInterval);
    }

    void Update()
    {
        // Semakin lama, peluang food semakin kecil
        foodChance -= decreaseRate * Time.deltaTime;

        // Tapi tidak pernah kurang dari minFoodChance
        foodChance = Mathf.Clamp(foodChance,minFoodChance,1f);
    }

    void SpawnObject()
    {
        float randomX =
            Random.Range(-laneWidth, laneWidth);

        Vector3 spawnPos =new Vector3(randomX,1f,player.position.z + spawnDistance);

        bool spawnFood =Random.value < foodChance;

        if (spawnFood)
        {
            int index =Random.Range(0, foods.Length);

            Instantiate(foods[index],spawnPos,Quaternion.identity);
        }
        else
        {
            Instantiate(poopPrefab,spawnPos,Quaternion.identity);
        }
    }
}