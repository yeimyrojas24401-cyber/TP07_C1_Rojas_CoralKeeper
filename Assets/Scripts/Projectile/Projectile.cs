using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private ProjectileDataSo projectileData;
    private Vector2 direction;

    private void Start()
    {
        Destroy(gameObject, projectileData.LifeTime);
    }

    private void FixedUpdate()
    {
        float step = projectileData.Speed * Time.fixedDeltaTime;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, step, projectileData.HitLayers);
        Debug.DrawRay(transform.position, direction * step, Color.red);

        if (hit.collider != null)
        {
            Debug.Log($"Burbuja choco con {hit.collider.name}");
            Destroy(gameObject);
            return;
        }

        transform.position += (Vector3)(direction * step);
    }
    public void Init(Vector2 dir)
    {
        direction = dir;
    }
}
