using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] float maxHealth = 100;
    [SerializeField] float currentHealth = 100;
    SkinnedMeshRenderer skinnedMeshRenderer;
    Slider healthBar;

    [SerializeField] float blinkIntensity = 10;

    private void Start()
    {
        currentHealth = maxHealth;
    }
    private void Update()
    {
        
    }
    private void TakeDamage()
    {
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void IsDead()
    {

    }
}
