/*
 * Author: GrobenTham
 * Date: 2025-06-15
 * Description: Rotates the hazard and respawns the player on collision.
 */

using UnityEngine;

/// <summary>
/// Rotates the hazard object and respawns the player on collision.
/// </summary>
public class RotatingHazard : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(0, 100, 0);
    public Transform respawnPoint;

    private void Update()
    {
        // 🔁 Auto-rotate every frame
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hazard hit: " + other.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player hit hazard — respawning...");

            CharacterController cc = other.GetComponent<CharacterController>();
            if (cc != null) cc.enabled = false;

            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }

            other.transform.position = respawnPoint.position;
            other.transform.rotation = respawnPoint.rotation;

            if (cc != null) cc.enabled = true;
        }
    }
}
