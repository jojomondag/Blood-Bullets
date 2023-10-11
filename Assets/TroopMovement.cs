using UnityEngine;

public class TroopMovement : MonoBehaviour
{
    private Camera mainCamera;
    private Vector3 targetPosition;
    private float speed = 5.0f;
    public float separationDistance = 1.5f; // Distance to keep from other troops

    private void Start()
    {
        mainCamera = Camera.main; // Assuming you only have one main camera in the scene
    }

    private void Update()
    {
        FollowMouse();
    }

    void FollowMouse()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {
            targetPosition = hit.point;
            targetPosition.y = transform.position.y; // Keep the y position constant

            Vector3 directionToMove = (targetPosition - transform.position).normalized;
            directionToMove += CalculateSeparation(); // Add separation behavior

            transform.position += directionToMove.normalized * speed * Time.deltaTime;
        }
    }

    Vector3 CalculateSeparation()
    {
        Vector3 separation = Vector3.zero;
        int neighborsCount = 0;

        foreach (var troop in GameObject.FindGameObjectsWithTag("Troop")) // Make sure each sphere has the tag "Troop"
        {
            if (troop != this.gameObject)
            {
                if ((troop.transform.position - this.transform.position).sqrMagnitude < separationDistance * separationDistance)
                {
                    separation -= (troop.transform.position - this.transform.position);
                    neighborsCount++;
                }
            }
        }

        if (neighborsCount > 0)
        {
            separation /= neighborsCount;
        }

        return separation;
    }
}
