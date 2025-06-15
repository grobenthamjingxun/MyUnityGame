/*
 * Author: GrobenTham
 * Date: 2025-06-15
 * Description: Rotates the coin continuously on its Y-axis.
 */

using UnityEngine;

public class CoinRotation : MonoBehaviour
{
    public float rotationSpeed = 100f; // Degrees per second

    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);
    }
}
