using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform[] troops;    // Array to store all troop transforms
    public float smoothSpeed = 0.125f;  // Speed at which camera follows the troops
    public Vector3 offset;    // Offset for the camera position relative to the center of troops

    private void FixedUpdate()
    {
        Vector3 centerPosition = GetCenterPoint();
        Vector3 desiredPosition = centerPosition + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Ensure camera is always looking at the center of troops
        transform.LookAt(centerPosition);
    }

    Vector3 GetCenterPoint()
    {
        if (troops.Length == 1)
        {
            return troops[0].position;
        }

        Bounds bounds = new Bounds(troops[0].position, Vector3.zero);
        for (int i = 0; i < troops.Length; i++)
        {
            bounds.Encapsulate(troops[i].position);
        }

        return bounds.center;
    }
}
