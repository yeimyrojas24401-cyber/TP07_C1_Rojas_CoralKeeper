using UnityEngine;

public abstract class Pickable : MonoBehaviour
{
    [SerializeField] private AudioClip pickupClip;
    [SerializeField] private ParticleSystem pickupSfx;

    private bool picked;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (picked) return;
        if (!other.TryGetComponent<PlayerMarker>(out _)) return;
        picked =true;
        Instantiate(pickupSfx, transform.position, Quaternion.identity);
        if (other.TryGetComponent(out PlayerAudio playerAudio))
        {
            playerAudio.PlaySfx(pickupClip);
        }
        ApplyEffect(other.gameObject);
        Destroy(gameObject);
    }
    protected abstract void ApplyEffect(GameObject player);
}
