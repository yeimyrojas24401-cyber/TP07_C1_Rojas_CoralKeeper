using Unity.Android.Gradle.Manifest;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private ProjectileDataSo projectileData;
    private Vector2 direction;
    public void Init(Vector2 dir);

    private void Start()
    {
       Destroy(gameObject, projectileData.LifeTime);
    }

    private void FixedUpdate()
    {
        float step = projectileData.Speed * Time.fixedDeltaTime;
        RaycastHit2D hit = Physhics2D.Raycast(transform.position, direction, step, projectileData.HitLayers);
        Debug.DrawRay(transform.position, direction * step, Color.red);

        if (hit.collider != null)
        {
            Debug.Log($"Burbuja choco con {hit.collider.name}");
            Destroy(gameObject);
            return;
        }
        else
        {
            transform.position += (Vector3)(direction * step);
        }
    }
}
