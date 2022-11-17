using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour, IItem
{
    [SerializeField]
    RenderTexture img;

    private float _damage;
    private float _protection;

    public void Drop()
    {
        throw new System.NotImplementedException();
    }

    public GameObject GetHoldingPoint()
    {
        GetComponent<MeshRenderer>().enabled = false;
        return gameObject;
    }

    public void PrimaryUse()
    {
        throw new System.NotImplementedException();
    }

    public void SecondaryUse()
    {
        throw new System.NotImplementedException();
    }

    public RenderTexture GetUIComponent()
    {
        return img;
    }

    public virtual void Special()
    {

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
