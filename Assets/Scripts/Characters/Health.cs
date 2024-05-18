using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth = 100f;
    public Transform healthBar;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0f)
        {
            currentHealth = 0f;
            print(currentHealth);
            Debug.Log("Health depleted!");
            Destroy(gameObject);
        }

        
        float healthPercentage = (float)currentHealth / maxHealth;

        
        Vector3 newScale = new Vector3(healthPercentage, healthBar.localScale.y, healthBar.localScale.z);
        healthBar.localScale = newScale;
    }
}
