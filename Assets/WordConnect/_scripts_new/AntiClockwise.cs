using System.Collections;
using UnityEngine;

public class DanceSprite1 : MonoBehaviour
{
    public float rotateSpeed = 500f;  // Speed of rotation
    public float rotateDuration = 1f; // Time to rotate in one direction
    private bool rotatingClockwise = false;  // Start with anticlockwise rotation

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RotateDance());
    }

    // Coroutine to handle the back-and-forth rotation
    IEnumerator RotateDance()
    {
        while (true)
        {
            if (rotatingClockwise)
            {
                // Rotate clockwise
                transform.Rotate(Vector3.forward, rotateSpeed * Time.deltaTime);
            }
            else
            {
                // Rotate anticlockwise
                transform.Rotate(Vector3.forward, -rotateSpeed * Time.deltaTime);
            }

            // Wait for the duration, then switch rotation direction
            yield return new WaitForSeconds(rotateDuration);
            rotatingClockwise = !rotatingClockwise; // Switch direction
        }
    }
}