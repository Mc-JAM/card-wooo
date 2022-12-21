using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    [SerializeField]
    Slider _health;
    [SerializeField]
    TMP_Text _hText;

    [SerializeField]
    GameObject invHolder;
    [SerializeField]
    GameObject invItem;
    [SerializeField]
    Inventory inv;
    RawImage[] _cards = new RawImage[7];
    LinkedList<GameObject> _invItems = new LinkedList<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 7; i++)
        {
            _cards[i] = invHolder.transform.GetChild(i).GetComponent<RawImage>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        GetHealthFromPlayer();
    }

    public void UpdateCards()
    {
        int c = 0;
        foreach (GameObject i in _invItems)
        {
            i.transform.localPosition = _cards[c].transform.localPosition;
            c++;
        }
    }

    public void ScrollLeftUpdate()
    {
        GameObject c = _invItems.First.Value;
        _invItems.Remove(_invItems.First);
        _invItems.AddLast(c);
        UpdateCards();
    }

    public void ScrollRightUpdate()
    {
        GameObject c = _invItems.Last.Value;
        _invItems.Remove(_invItems.Last);
        _invItems.AddFirst(c);
        UpdateCards();
    }

    public void OnCardPickUp(Texture t)
    {
        GameObject g = Instantiate(invItem);
        g.transform.SetParent(transform, false);
        g.GetComponent<RawImage>().texture = t;
        g.transform.localPosition = _cards[0].transform.localPosition;
        _invItems.AddFirst(g);
        UpdateCards();
    }

    private void GetHealthFromPlayer()
    {
        _health.value = SimpleGM.instance.pManager.GetHealth();
        _hText.text = ((int)SimpleGM.instance.pManager.GetHealth()).ToString();
    }
}
