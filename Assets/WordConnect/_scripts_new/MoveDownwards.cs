using System.Collections;
using UnityEngine;

public class MoveDownwards : MonoBehaviour
{
    public float moveSpeed = 5f;  // Speed at which the object moves along the Y axis
    public float moveTime = 1f;   // How long the object moves after the button is pressed

    private bool isMoving = false;  // To track if the object is currently moving

    // This function can be called when a button is pressed
    public void OnButtonPress()
    {
        if (!isMoving)
        {
            StartCoroutine(MoveDown());
        }
    }

    IEnumerator MoveDown()
    {
        isMoving = true;
        float elapsedTime = 0f;

        // Keep moving the object downwards while elapsed time is less than moveTime
        while (elapsedTime < moveTime)
        {
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
            elapsedTime += Time.deltaTime;
            yield return null;  // Wait for the next frame
        }

        isMoving = false;
    }
}
