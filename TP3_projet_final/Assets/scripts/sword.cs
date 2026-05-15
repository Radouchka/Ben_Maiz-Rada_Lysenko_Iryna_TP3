using UnityEngine;

public class Sword : MonoBehaviour
{
    [Header("Damage Settings")]
    public int damagePerHit = 1;

    [Header("Hit Cooldown")]
    public float hitCooldown = 0.3f;
    private float lastHitTime = 0f;

    [Header("Sound")]
    public AudioClip hitSound;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (Time.time - lastHitTime < hitCooldown)
            return;

        DragonHealth dragonHealth = collision.gameObject.GetComponent<DragonHealth>();

        if (dragonHealth != null)
        {
            dragonHealth.TakeDamage(damagePerHit);
            lastHitTime = Time.time;

            if (hitSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(hitSound);
            }
        }
    }
}