using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.AI;
using UnityEditor.Search;

public class Enemy : MonoBehaviour
{
    public float health = 50f;

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die() //enemy death, destroy for now, room for death animation later
    {
        Destroy(gameObject);  
    }
}

