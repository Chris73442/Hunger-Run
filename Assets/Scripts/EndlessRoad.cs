using UnityEngine;

public class EndlessRoad : MonoBehaviour
{
    public Transform player;

    public float roadLength = 50f;

    void Update()
    {
        if (player.position.z >transform.position.z + roadLength)
        {
            transform.position +=
                Vector3.forward *
                roadLength * 3f;
        }
    }
}