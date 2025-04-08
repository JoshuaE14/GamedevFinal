using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.AI;
using UnityEditor.Search;
using UnityEngine.UIElements;

public class EnemySpawner : MonoBehaviour
{
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject SpawnedEnemy;
    public int Xpos;
    public int Zpos;
    //Counts
    public int EnemyCount;
    public int RequiredEnemies;

    //States
    public float attackrange;
    public bool playerinattackrange;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Xpos = Random.Range(-15, 15); //Change X and Z random range to increase spawn range
        Zpos = Random.Range(-15, 15);
    }

    private void Update()
    {
        playerinattackrange = Physics.CheckSphere(transform.position, attackrange, whatIsPlayer);
        if (playerinattackrange) AttackPlayer();
    }
    private void AttackPlayer()
    {
        if (!alreadyAttacked)
        {
            {
                //Attack Code here
                EnemyCount += 1;
                Instantiate(SpawnedEnemy, new Vector3(Xpos, 1, Zpos), Quaternion.identity);
                Debug.Log("Spawner spawned an enemy");
                alreadyAttacked = true;
                Invoke(nameof(ResetAttack), timeBetweenAttacks);
            }
        }
        if (EnemyCount >= RequiredEnemies)
        {
            Invoke(nameof(DestroyEnemy), 0.5f);
        }


    }
    private void ResetAttack()
    { alreadyAttacked = false; }
    private void DestroyEnemy()
    {
        Destroy(gameObject);
        Debug.Log("Spawner Destoryed");
    }
}