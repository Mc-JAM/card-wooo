using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

public class enemy_mov : MonoBehaviour
{

    [SerializeField] private Transform movePositionTransform;

    public NavMeshAgent agent;
    public Transform player;

    //states 
    public float attackRange;
    public float sightRange;
    public bool playerInSightRange;
    
    private void Awake()
    {
        
        //player = GameObject.Find("PlayerObj").transform;
        player = SimpleGM.instance.pManager.transform;

        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    public void Update()
    {
        //Debug.Log(gameObject);
        float dist = Vector3.Distance(transform.position, player.position);
        //Vector3.DistanceSquared(transform.position, player.posiiton); sightRange * sightRange
        if (dist <= sightRange) {
            ChasePlayer();
        }
    }

    private void ChasePlayer()
    {
        if (Vector3.Distance(transform.position, player.position) < attackRange) {
            return;
        }
        agent.SetDestination(player.position);
        //Debug.Log("player in radius");
    }
}
