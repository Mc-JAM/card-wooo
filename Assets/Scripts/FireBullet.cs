using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.AddForce(transform.forward * 4, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.gameObject.GetComponent<IDamageable>() != null)
        {
            collision.transform.gameObject.GetComponent<IDamageable>().Damage(50);
        }
        Collider[] c = Physics.OverlapSphere(transform.position, 10);
        foreach (Collider cc in c)
        {
            if (cc.transform.GetComponent<Rigidbody>())
            {
                cc.transform.GetComponent<Rigidbody>().AddExplosionForce(300, transform.position, 20);
            }
            if (cc.transform.GetComponent<IDamageable>() != null)
            {
                if (cc.transform.gameObject != SimpleGM.instance.pManager.gameObject) 
                    cc.transform.GetComponent<IDamageable>().Damage(40);
            }
        }
        Destroy(gameObject);
    }
}
