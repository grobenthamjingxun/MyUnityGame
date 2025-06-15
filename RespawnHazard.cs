/*
 * Author: GrobenTham
 * Date: 2025-06-15
 * Description: Respawns the player at the respawn point when touching a hazard.
 */

using UnityEngine;

/// <summary>
/// This script handles player respawn when they collide with a hazard trigger.
/// </summary>
public class RespawnHazard : MonoBehaviour
{
    /// <summary>
    /// The location where the player will respawn.
    /// </summary>
    public Transform respawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered by: " + other.name); // ✅ Log when trigger is hit

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

            // Zero out rigidbody velocities (if present)
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                Debug.Log("Rigidbody velocity reset.");
            }

            // Teleport to respawn point
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
