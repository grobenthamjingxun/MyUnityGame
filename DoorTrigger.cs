/*
 * Author: GrobenTham
 * Date: 2025-06-15
 * Description: Opens the door when the player enters the trigger zone.
 */

using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public Transform door; // Drag the Door Cube here in Inspector
    public Vector3 openOffset = new Vector3(0, 3f, 0); // Moves upward
    public float openSpeed = 2f;

    private Vector3 closedPosition;
    private Vector3 openPosition;
    private bool isOpening = false;

    void Start()
    {
        closedPosition = door.position;
        openPosition = door.position + openOffset;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isOpening = true;
            Debug.Log("Player triggered door.");
        }
    }

    void Update()
    {
        if (isOpening && door != null)
        {
            door.position = Vector3.MoveTowards(door.position, openPosition, openSpeed * Time.deltaTime);
        }
    }
}
