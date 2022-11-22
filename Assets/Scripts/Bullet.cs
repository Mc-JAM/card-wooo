using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.AddForce(transform.forward * 10, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.gameObject.GetComponent<IDamageable>() != null)
        {
            collision.transform.gameObject.GetComponent<IDamageable>().Damage(20);
            
        }
        Destroy(gameObject);
    }
}
