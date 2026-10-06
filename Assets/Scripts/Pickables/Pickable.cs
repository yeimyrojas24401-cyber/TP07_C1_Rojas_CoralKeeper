using UnityEngine;

public abstract class Pickable : MonoBehaviour
{
    private bool picked;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (picked) return;
        if (!other.TryGetComponent<PlayerMarker>(out _)) return;
        picked =true;
        ApplyEffect(other.gameObject);
        Destroy(gameObject);
    }
    protected abstract void ApplyEffect(GameObject player);
}
