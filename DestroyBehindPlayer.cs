using UnityEngine;

public class DestroyBehindPlayer : MonoBehaviour
{
    Transform player;

    void Start()
    {
        player =
            GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if(transform.position.z <player.position.z - 20f)
        {
            Destroy(gameObject);
        }
    }
}