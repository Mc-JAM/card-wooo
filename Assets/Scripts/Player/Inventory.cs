using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private PlayerUI _pUI;

    private int invSlots = 7, invPointer = 0;
    private GameObject[] inventory;
    private LinkedList<Card> _cards = new LinkedList<Card>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public GameObject[] GetInv
    {
        get { return inventory; }
    }

    public bool AddCard(Card newCard)
    {
        if (_cards.Count >= invSlots)
        {
            return false;
        }
        _=_cards.AddFirst(newCard);
        _pUI.OnCardPickUp(newCard.GetImage());
        return true;
    }

    public Card GetCardAt(int cardNum)
    {
        return _cards.ElementAt(cardNum);
    }

    public Card[] GetHotBar()
    {
        Card[] temp = new Card[3];
        if (_cards.Count <= 0)
            return temp;
        if (_cards.Count >= 1)
        temp[0] = _cards.First.Value;
        if (_cards.Count >= 2)
        temp[1] = _cards.ElementAt(1);
        if (_cards.Count >= 3)
        temp[2] = _cards.ElementAt(2);
        return temp;
    }

    public void UseCardAt(Card cardInstance)
    {
        _cards.Remove(cardInstance);
    }

    //Unimportant below
    public bool AddToInventory(GameObject newItem)
    {
        for (int i = 0; i < invSlots;i++)
        {
            if (inventory[i] == null)
            {
                invPointer = i;
                inventory[i] = newItem;
                return true;
            }
        }
        return false;
    }

    public void ScrollLeft()
    {
        Card c = _cards.First.Value;
        _cards.Remove(_cards.First);
        _cards.AddLast(c);
        _pUI.ScrollLeftUpdate();
    }

    public void ScrollRight()
    {
        Card c = _cards.Last.Value;
        _cards.Remove(_cards.Last);
        _cards.AddFirst(c);
        _pUI.ScrollRightUpdate();
    }

    public GameObject GetHolding()
    {
        return inventory[invPointer];
    }

    public void Drop()
    {
        Debug.Log(invPointer);
        inventory[invPointer] = null;
    }
}
