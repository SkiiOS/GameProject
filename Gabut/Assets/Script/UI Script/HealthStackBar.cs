using UnityEngine;
using UnityEngine.UI;

public class HealthStackBar : MonoBehaviour
{
    [Header("Stack Settings")]
    public int maxStacks = 5;      // jumlah maksimum stack
    public int currentStacks = 0;  // jumlah stack aktif sekarang

    [Header("Health Reference")]
    public HealthBar healthBar;    // drag HealthBar ke sini

    [Header("UI Bar")]
    public Slider stackSlider;     // slider bar putih (HealthStack)
    public Image fillImage;        // isi fill-nya (untuk ganti warna)

    [Header("Gradient Warna")]
    public Gradient stackGradient; // gradient warna dari kosong ke penuh

    void Start()
    {
        if (stackSlider == null)
            stackSlider = GetComponent<Slider>();

        stackSlider.minValue = 0;
        stackSlider.maxValue = maxStacks;
        stackSlider.value = currentStacks;

        UpdateBar();
    }

    public void Heal(int healAmount)
    {
        if (healthBar == null) return;

        // Kalau HP belum penuh → heal biasa
        if (!healthBar.IsFull())
        {
            healthBar.Heal(healAmount);
        }
        else
        {
            // Kalau HP penuh → tambah stack
            if (currentStacks < maxStacks)
            {
                currentStacks++;
                UpdateBar();
            }
        }
    }

    public void TakeDamage(int damage)
    {
        if (healthBar == null) return;

        bool healthDepleted = healthBar.TakeDamage(damage);

        // Kalau HP habis dan masih punya stack → pakai 1 stack
        if (healthDepleted && currentStacks > 0)
        {
            currentStacks--;
            healthBar.Refill();
            UpdateBar();
        }
    }

    private void UpdateBar()
    {
        if (stackSlider != null)
            stackSlider.value = currentStacks;

        if (fillImage != null && stackGradient != null)
        {
            float t = (float)currentStacks / maxStacks;
            fillImage.color = stackGradient.Evaluate(t);
        }
    }
}
