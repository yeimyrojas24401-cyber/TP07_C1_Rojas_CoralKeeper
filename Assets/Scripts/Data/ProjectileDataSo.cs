using UnityEngine;
[CreateAssetMenu( fileName = "ProjectileDataSo", menuName = "Data/Game/ProjectileData")]
public class ProjectileDataSo : ScriptableObject
{
    [SerializeField] private float speed = 8f;
    public float Speed => speed;
    [SerializeField] private float lifeTime = 2f;
    public float LifeTime => lifeTime;

    [SerializeField] private LayerMask hitLayers;
    public LayerMask HitLayers => hitLayers;
    [SerializeField] private int damage;

}
