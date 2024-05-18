using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public Transform healthBar;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= 10;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("Health depleted!");
            Destroy(gameObject);
        }

        
        float healthPercentage = (float)currentHealth / maxHealth;

        
        Vector3 newScale = new Vector3(healthPercentage, healthBar.localScale.y, healthBar.localScale.z);
        healthBar.localScale = newScale;
    }
}
