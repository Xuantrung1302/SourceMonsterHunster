using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    [SerializeField] private GameObject character;
    public float currentHealth { get; private set; }
    private Animator animator;
    private bool dead;
    void Awake() {
        currentHealth = startingHealth;
        animator = character.GetComponent<Animator>();
    }
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        if (currentHealth > 0)
        {
            //player hurt
        }
        else
        {
            //player dead
            if (!dead)
            {
                animator.SetTrigger("Die");
                GetComponent<PlayerMovement>().enabled = false;
                dead = true;
                StartCoroutine(Die());
            }
        }
    }
    private IEnumerator Die()
    {
        yield return new WaitForSeconds(1f);
        Time.timeScale = 0f; 
    }

}
