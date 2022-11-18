using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    SimpleInput input;
    public Inventory inventory;
    private bool building;
    private float damage = 5;

    private int cardPointer = 0;
    private Card[] usingCards = new Card[3];

    [SerializeField]
    private Card[] hotbar = new Card[3];

    private GameObject holding;
    // Start is called before the first frame update
    void Start()
    {
        input = SimpleGM.instance.input;
        hotbar = inventory.GetHotBar();
    }

    // Update is called once per frame
    void Update()
    {
        Inputs();
        checkDrop();
        RaycastHit hit;
        if (Physics.SphereCast(Camera.main.ScreenToWorldPoint(Input.mousePosition), .5f, transform.forward, out hit, 3))
        {
            GameObject obj = hit.transform.gameObject;
            if (building)
            {
                //Building commands
            }
            else
            {
                if (obj.GetComponent<IItem>() != null)
                {
                    if (input.GetButtonDown("use"))
                    {
                        inventory.AddCard(obj.GetComponent<Card>());
                        holding = obj.GetComponent<IItem>().GetHoldingPoint();
                        obj.GetComponent<BoxCollider>().enabled = false;
                        hotbar = inventory.GetHotBar();
                    }
                }
                if (obj.GetComponent<IInteract>() != null)
                {
                    if (input.GetButtonDown("use"))
                    {
                        obj.GetComponent<IInteract>().PrimaryUse();
                    }
                    else if (input.GetButtonDown("sFire"))
                    {
                        obj.GetComponent<IInteract>().SecondaryUse();
                    }
                }
                if (obj.GetComponent<IDamageable>() != null)
                {
                    if (input.GetButtonDown("pFire"))
                    {
                        obj.GetComponent<IDamageable>().Damage(5);
                    }
                }
            }
        }
    }

    private void Inputs()
    {
        if (Input.mouseScrollDelta.y < 0)
        {
            Debug.Log("Cream");
            inventory.ScrollLeft();
        }

    }

    private void checkDrop()
    {
        if (input.GetButtonDown("drop") && holding != null)
        {
            holding.GetComponent<IItem>().Drop();
            inventory.Drop();
            holding = null;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.forward * 3);
    }
}
