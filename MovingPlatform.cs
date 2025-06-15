/*
 * Author: GrobenTham
 * Date: 2025-06-15
 * Description: Moves a platform left-right on the X-axis, ignoring object rotation.
 */

using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float moveDistance = 4f;
    public float moveSpeed = 2f;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float offset = Mathf.PingPong(Time.time * moveSpeed, moveDistance) - (moveDistance / 2f);

        // Force movement strictly along world X axis
        transform.position = new Vector3(startPos.x + offset, startPos.y, startPos.z);

        Debug.Log("Platform position: " + transform.position); // ← helps verify direction
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.SetParent(transform);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.SetParent(null);
        }
    }
}
