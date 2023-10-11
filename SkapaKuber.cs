using UnityEngine;
public class SkapaKuber : MonoBehaviour
{
    private float countdownTime = 2.0f; // Set the initial countdown time in seconds
    private float currentTime = 0.0f;

    public GameObject spelObjekt;

    // Update is called once per frame
    void Update()
    {
        // Check if the timer has reached zero
        if (currentTime <= 0)
        {
            // Reset the timer
            currentTime = countdownTime;

            // Instantiate a cube
            Instantiate(spelObjekt, transform.position, Quaternion.identity);
        }
        else
        {
            // Decrease the timer by deltaTime
            currentTime = currentTime - Time.deltaTime;
        }
    }
}