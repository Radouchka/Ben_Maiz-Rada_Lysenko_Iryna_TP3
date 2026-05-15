using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class DragonHealth : MonoBehaviour
{
    [Header("Health Settings")]
    public int maxHealth = 5;
    private int currentHealth;

    [Header("Death Settings")]
    public float despawnDelay = 5f;

    [Header("UI")]
    public TextMeshProUGUI healthText;

    private NavMeshAgent agent;
    private Dragon dragonAI;
    private bool isDead = false;

    private void Start()
    {
        currentHealth = maxHealth;
        agent = GetComponent<NavMeshAgent>();
        dragonAI = GetComponent<Dragon>();

        UpdateHealthUI();
    }

    public void TakeDamage(int damage)
    {
        if (isDead)
            return;

        currentHealth -= damage;
        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = $"Dragon HP: {currentHealth}/{maxHealth}";
        }
    }

    private void Die()
    {
        if (isDead)
            return;

        isDead = true;

        if (healthText != null)
        {
            healthText.text = "Vous avez battu le dragon!";
        }

        if (dragonAI != null)
            dragonAI.enabled = false;

        if (agent != null)
        {
            agent.isStopped = true;
            agent.enabled = false;
        }

        Destroy(gameObject, despawnDelay);
    }
}