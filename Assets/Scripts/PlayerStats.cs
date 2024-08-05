using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float maxStamina = 100f;

    public float currentHealth;
    public float currentStamina;

    private void Start()
    {
        // Inicjalizacja statystyk na pocz¹tku gry
        currentHealth = maxHealth;
        currentStamina = maxStamina;
    }

    // Metoda do otrzymywania obra¿eñ
    public void TakeDamage(float damageAmount)
    {
        if (damageAmount <= 0) return;

        currentHealth -= damageAmount;
        if (currentHealth < 0) currentHealth = 0;

        Debug.Log($"Damage taken: {damageAmount}. Current health: {currentHealth}");

        // Mo¿na dodaæ tutaj inne efekty, takie jak wywo³anie zdarzeñ œmierci postaci itp.
    }

    // Metoda do regeneracji zdrowia
    public void Heal(float healAmount)
    {
        if (healAmount <= 0) return;

        currentHealth += healAmount;
        if (currentHealth > maxHealth) currentHealth = maxHealth;

        Debug.Log($"Healed: {healAmount}. Current health: {currentHealth}");
    }

    // Metoda do wydawania stamin
    public void UseStamina(float amount)
    {
        if (amount <= 0) return;

        currentStamina -= amount;
        if (currentStamina < 0) currentStamina = 0;

        Debug.Log($"Stamina used: {amount}. Current stamina: {currentStamina}");
    }

    // Metoda do regeneracji stamin
    public void RegenerateStamina(float amount)
    {
        if (amount <= 0) return;

        currentStamina += amount;
        if (currentStamina > maxStamina) currentStamina = maxStamina;

        Debug.Log($"Stamina regenerated: {amount}. Current stamina: {currentStamina}");
    }

    // Metody pomocnicze do pobierania statystyk
    public float GetCurrentHealth() => currentHealth;
    public float GetMaxHealth() => maxHealth;
    public float GetCurrentStamina() => currentStamina;
    public float GetMaxStamina() => maxStamina;
}
