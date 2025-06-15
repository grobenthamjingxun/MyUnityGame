/*
 * Author: GrobenTham
 * Date: 2025-06-15
 * Description: Moves a hazard block up/down and respawns the player on contact.
 */

using UnityEngine;

/// <summary>
/// Moves a hazard block vertically and respawns the player when touched.
/// </summary>
public class MovingRespawnHazard : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveDistance = 2f;     // Total vertical movement range
    public float moveSpeed = 2f;        // Movement speed

    [Header("Respawn Settings")]
    public Transform respawnPoint;      // Where the player respawns

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // Move the hazard block up and down smoothly
        float offset = Mathf.PingPong(Time.time * moveSpeed, moveDistance);
        transform.position = new Vector3(startPos.x, startPos.y + offset, startPos.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered by: " + other.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered hazard. Respawning...");

            // Disable CharacterController if present (for safe teleport)
            CharacterController cc = other.GetComponent<CharacterController>();
            if (cc != null)
            {
                cc.enabled = false;
                Debug.Log("CharacterController disabled.");
            }

            // Reset Rigidbody velocity if present
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero; // Use velocity, not linearVelocity
                rb.angularVelocity = Vector3.zero;
                Debug.Log("Rigidbody velocity reset.");
            }

            // Move player to respawn point
            other.transform.position = respawnPoint.position;
            other.transform.rotation = respawnPoint.rotation;
            Debug.Log("Player respawned at: " + respawnPoint.position);

            // Re-enable CharacterController
            if (cc != null)
            {
                cc.enabled = true;
                Debug.Log("CharacterController re-enabled.");
            }
        }
    }
}
