using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;


public class goblin : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private Transform movePositionTransform;

    public NavMeshAgent agent;
    public Transform player;

    //attacking 
    public float attackCooldown;
    private float lastAttacked = 0;
    public bool playerInAttackRange;
    public float attackRange;

    void Awake()
    {
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(transform.position, player.position);
        if (dist <= attackRange) {
            attackPlayer();
        }

        
    }

    void attackPlayer(){

        if (Time.time > lastAttacked + attackCooldown) {
            
            //attack
            Debug.Log("bonk");

            lastAttacked = Time.time;
            

            agent.SetDestination(transform.position + player.position);
        }

    }
}
