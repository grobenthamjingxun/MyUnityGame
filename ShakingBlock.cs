/*
 * Author: GrobenTham
 * Date: 2025-06-15
 * Description: Gently shakes a block around its starting position.
 */

using UnityEngine;

public class ShakingBlock : MonoBehaviour
{
    public float shakeIntensity = 0.05f;  // How far it shakes (max distance)
    public float shakeSpeed = 5f;         // How fast it shakes

    private Vector3 originalPos;

    void Start()
    {
        originalPos = transform.position;
    }

    void Update()
    {
        float xOffset = (Mathf.PerlinNoise(Time.time * shakeSpeed, 0f) - 0.5f) * 2f * shakeIntensity;
        float yOffset = (Mathf.PerlinNoise(0f, Time.time * shakeSpeed) - 0.5f) * 2f * shakeIntensity;

        transform.position = originalPos + new Vector3(xOffset, yOffset, 0);
    }
}
