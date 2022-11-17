using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check : MonoBehaviour
{
    [SerializeField]
    private LayerMask layerToCheckFor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsTouchingLayer()
    {
        Collider[] cum = Physics.OverlapSphere(transform.position, .5f, layerToCheckFor);
        if (cum.Length > 0) return true;
        return false;
    }

    public float GetHeight()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity))
            return hit.distance;
        return 0;
    }
}
