using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [Header("Health Settings")]
    public int maxHealth = 100;
    public int currentHealth;

    [Header("UI")]
    public Image healthFill; // drag image fill bar health ke sini

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    /// <summary>
    /// Kurangi health sesuai damage yang diterima.
    /// Mengembalikan true jika health habis.
    /// </summary>
    public bool TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;

        UpdateHealthUI();

        return currentHealth <= 0;
    }

    /// <summary>
    /// Tambah health saat di-heal.
    /// </summary>
    public void Heal(int amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
        UpdateHealthUI();
    }

    /// <summary>
    /// Update tampilan bar UI.
    /// </summary>
    private void UpdateHealthUI()
    {
        if (healthFill != null)
            healthFill.fillAmount = (float)currentHealth / maxHealth;
    }

    /// <summary>
    /// Cek apakah health penuh.
    /// </summary>
    public bool IsFull()
    {
        return currentHealth >= maxHealth;
    }

    /// <summary>
    /// Reset health jadi penuh (misalnya setelah pakai 1 health stack).
    /// </summary>
    public void Refill()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }
}
