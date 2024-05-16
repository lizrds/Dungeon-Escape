using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int health;
    public bool isPlayer;
    public RectTransform healthBar;
    float originalHealthBarSize;
    private void Start()
    {
        originalHealthBarSize = healthBar.sizeDelta.x;
    }
    private void Update()
    {
        if(health <= 0)
        {
            print("Death");
            SceneManager.LoadScene("Denis");
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if(isPlayer)
        {
            healthBar.sizeDelta = new Vector2(originalHealthBarSize * health / 100f, healthBar.sizeDelta.y);
        }
        Debug.Log(health.ToString());
    }
}
