using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;


public class ghost : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private Transform movePositionTransform;

    public NavMeshAgent agent;
    public Transform player;

    //attacking 
    public float attackCooldown;

    public float movmentcooldown;
    private float lastAttacked = 0;

    private float lastmovment = 0;
    public bool playerInAttackRange;
    public float attackRange;
    public float speed;

    public float sightRange;
    void Awake()
    {
        player = GameObject.Find("Player").transform;
    }

    void Update()
    {

        float dist = Vector3.Distance(transform.position, player.position);
        if (dist <= attackRange) {
            weird_attacking_strat();
        }

        if (dist <= sightRange) {
            movment();
        } else {
            chase();
        }
    }

    void chase() {
        agent.SetDestination(player.position);
    }
    void movment() {

        if (Time.time > lastmovment + movmentcooldown) {

            float dist = Vector3.Distance(transform.position, player.position);

            dist = dist * 2;

            float randAngle = Random.Range(0,360);
            Vector3 randDirection = new Vector3(Mathf.Cos(randAngle),0f,Mathf.Sin(randAngle));
            randDirection *= dist;
            agent.SetDestination(transform.position + randDirection);

            lastmovment = Time.time;
        }
    
    }
    void weird_attacking_strat(){

        if (Time.time > lastAttacked + attackCooldown) {
            //attack
            Debug.Log("bonk");

            movment();

            lastAttacked = Time.time;
        }
    }

    // Update is called once per frame
}
