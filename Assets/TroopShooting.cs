using UnityEngine;

public class TroopShooting : MonoBehaviour
{
    public GameObject projectilePrefab;  // Drag and drop your projectile prefab here
    public float shootingRate = 1.0f;  // How often the troops shoot (e.g., 1 shot per second)
    public float projectileSpeed = 10f;  // Speed of the projectile
    private Camera mainCamera;

    private float timeSinceLastShot = 0f;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        timeSinceLastShot += Time.deltaTime;
        if (timeSinceLastShot >= 1f / shootingRate)
        {
            ShootAtMousePosition();
            timeSinceLastShot = 0f;
        }
    }

    void ShootAtMousePosition()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {
            Vector3 shootingDirection = (hit.point - transform.position).normalized;
            GameObject projectile = Instantiate(projectilePrefab, transform.position + shootingDirection, Quaternion.identity);
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = shootingDirection * projectileSpeed;
            }
        }
    }
}
