/*
 * Author: GrobenTham
 * Date: 2025-06-15
 * Description: Rotates the coin and handles player collection.
 */

using UnityEngine;

public class Coin : MonoBehaviour
{
    [Tooltip("Rotation speed in degrees per second")]
    public float rotationSpeed = 90f;

    private void Update()
    {
        // Rotate the coin smoothly around Y-axis
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Add point to score manager
            if (ScoreManager.instance != null)
            {
                ScoreManager.instance.AddPoints(1);
            }

            // Destroy the coin after collection
            Destroy(gameObject);
        }
    }
}
