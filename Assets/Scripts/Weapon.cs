using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float damage = 10f;
    public float attackRange = 1.5f;
    public Transform attackPoint;
    public LayerMask Enemy;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && InventoryHasWeapon())
        {
            Attack();
        }
    }

    void Attack()
    {
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, Enemy);

        foreach (Collider enemy in hitEnemies)
        {
            // Ensure we have an Enemy component attached to the enemy object
            Enemy enemyScript = enemy.GetComponent<Enemy>();
            if (enemyScript != null)
            {
                enemyScript.TakeDamage(damage);  // Call TakeDamage method
            }
        }
    }

    bool InventoryHasWeapon()
    {
        return true;  // For now, always assume the player has a weapon
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        }
    }
}
