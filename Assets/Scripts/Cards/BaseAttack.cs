using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAttack : Card
{
    [SerializeField]
    GameObject bullet;
    public override void Special()
    {
        GameObject b = Instantiate(bullet);
        b.transform.position = SimpleGM.instance.pManager.transform.position + SimpleGM.instance.pManager.transform.GetChild(0).transform.forward * 2;
        b.transform.forward = SimpleGM.instance.pManager.transform.GetChild(0).transform.forward;
        Debug.Log("ball");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
