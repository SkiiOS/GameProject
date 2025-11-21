using UnityEngine;
using UnityEngine.UI;

public class ShieldBar : MonoBehaviour
{
    [Header("Shield Settings")]
    public int maxShield = 100;
    public int currentShield;

    [Header("UI")]
    public Image shieldFill;  // drag Image fill shield bar ke sini

    void Start()
    {
        currentShield = maxShield;
        UpdateShieldUI();
    }

    /// <summary>
    /// Kurangi shield sesuai jumlah damage.
    /// Mengembalikan sisa damage jika shield habis.
    /// </summary>
    public int TakeDamage(int damage)
    {
        if (currentShield <= 0)
            return damage; // shield kosong, damage diteruskan ke HP

        currentShield -= damage;

        if (currentShield < 0)
        {
            int leftover = Mathf.Abs(currentShield); // damage sisa
            currentShield = 0;
            UpdateShieldUI();
            return leftover;
        }

        UpdateShieldUI();
        return 0; // semua damage diserap shield
    }

    /// <summary>
    /// Isi ulang shield.
    /// </summary>
    public void Recharge(int amount)
    {
        currentShield = Mathf.Min(currentShield + amount, maxShield);
        UpdateShieldUI();
    }

    /// <summary>
    /// Perbarui tampilan UI shield bar.
    /// </summary>
    private void UpdateShieldUI()
    {
        if (shieldFill != null)
            shieldFill.fillAmount = (float)currentShield / maxShield;
    }
}
