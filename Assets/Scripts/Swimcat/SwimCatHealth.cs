using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwimCatHealth : MonoBehaviour
{
    public healthBar healthBar;
    
    public float healthDecreaseRate = 2f;
    public float maxHealth=10f;
    public float oxygen = 0.01f;

    public float waterSurfaceY = 6f;
    [SerializeField] private float amount;
    
    private float currentHealth;
    private Animator anim;
    void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponent <Animator>();
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
    public void hitHealth(float amount)
    {
        currentHealth = Mathf.Clamp(currentHealth - amount, 0f, maxHealth);
        UpdateHealthUI();
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
        healthBar.setHealthBar(currentHealth / maxHealth); //将当前血量映射到max里
    }

}
