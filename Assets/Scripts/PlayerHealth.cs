using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public healthBar healthBar;
    
    public float healthDecreaseRate = 2f;
    public float maxHealth=10f;
    public float oxygen = 1;

    public float waterSurfaceY = 6f;
    [SerializeField] private float amount;
    private float currentHealth;
    void Start()
    {
        currentHealth = maxHealth;
    }
    void Update()
    {
        if (transform.position.y < waterSurfaceY)
        {
            amount = healthDecreaseRate * Time.deltaTime;
            DecreaseHealth(amount);
        }
        else
        {
            recoverHealth(oxygen);
        }
    }

    void DecreaseHealth(float amount)
    {
        currentHealth = Mathf.Clamp(currentHealth - amount, 0f, maxHealth);
        UpdateHealthUI();
    }
    void recoverHealth(float oxygen)
    {
        currentHealth = Mathf.Clamp(currentHealth + oxygen, 0f, maxHealth);
        UpdateHealthUI();
    }
    void UpdateHealthUI()
    {
        healthBar.setHealthBar(currentHealth / maxHealth); //����ǰѪ��ӳ�䵽max��
    }
}
