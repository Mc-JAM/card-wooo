using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleInput : MonoBehaviour
{
    [SerializeField]
    private KeyCode forward, backward, right, left; //Movement
    [SerializeField]
    private KeyCode jump, crouch, sprint; //Extended movement
    [SerializeField]
    private KeyCode pFire, sFire, mFire; //Shooting
    [SerializeField]
    private KeyCode escape, inventory, map; //Helpful buttons
    [SerializeField]
    private KeyCode use, drop;
    [SerializeField]
    private KeyCode b1, b2, b3, b4; //Alt buttons

    // Start is called before the first frame update
    void Start()
    {
        SetMovement(forward, backward, right, left);
        SetExtMovement(jump, crouch, sprint);
        SetFiring(pFire, sFire, mFire);
        SetHelpfulButtons(escape, inventory, map);
        SetOtherStuff(use, drop);
    }

    public int GetVertical()
    {
        if (Input.GetKey(forward)) return 1;
        if (Input.GetKey(backward)) return -1;
        return 0;
    }

    public int GetHorizontal()
    {
        if (Input.GetKey(right)) return 1;
        if (Input.GetKey(left)) return -1;
        return 0;
    }

    public bool GetButtonDown(string key)
    {
        return Input.GetKeyDown((KeyCode)PlayerPrefs.GetInt(key));
    }

    public bool GetButton(string key)
    {
        return Input.GetKey((KeyCode)PlayerPrefs.GetInt(key));
    }

    public void SetMovement(KeyCode f, KeyCode b, KeyCode r, KeyCode l)
    {
        PlayerPrefs.SetInt("forward", (int) f);
        PlayerPrefs.SetInt("backward", (int) b);
        PlayerPrefs.SetInt("right", (int) r);
        PlayerPrefs.SetInt("left", (int) l);
        forward = f;
        backward = b;
        right = r;
        left = l;
    }

    public void SetExtMovement(KeyCode j, KeyCode c, KeyCode s)
    {
        PlayerPrefs.SetInt("jump", (int)j);
        PlayerPrefs.SetInt("crouch", (int)c);
        PlayerPrefs.SetInt("sprint", (int)s);
        jump = j;
        crouch = c;
        sprint = s;
    }

    public void SetOtherStuff(KeyCode u, KeyCode d)
    {
        PlayerPrefs.SetInt("use", (int)u);
        PlayerPrefs.SetInt("drop", (int)d);
        use = u;
        drop = d;
    }

    public void SetFiring(KeyCode p, KeyCode s, KeyCode m)
    {
        PlayerPrefs.SetInt("pFire", (int)p);
        PlayerPrefs.SetInt("mFire", (int)m);
        PlayerPrefs.SetInt("sFire", (int)s);
        pFire = p;
        mFire = m;
        sFire = s;
    }

    public void SetHelpfulButtons(KeyCode e, KeyCode i, KeyCode m)
    {
        PlayerPrefs.SetInt("escape", (int)e);
        PlayerPrefs.SetInt("inventory", (int)i);
        PlayerPrefs.SetInt("map", (int)m);
        escape = e;
        inventory = i;
        map = m;
    }

    public void GetButtonsFromMem()
    {
        backward = (KeyCode) PlayerPrefs.GetInt("backward");
        right =  (KeyCode) PlayerPrefs.GetInt("right");
        left = (KeyCode) PlayerPrefs.GetInt("left");
        jump = (KeyCode) PlayerPrefs.GetInt("jump");
        crouch = (KeyCode) PlayerPrefs.GetInt("crouch");
        forward = (KeyCode) PlayerPrefs.GetInt("forward");
        pFire = (KeyCode) PlayerPrefs.GetInt("pFire");
        mFire = (KeyCode) PlayerPrefs.GetInt("mFire");
        sFire = (KeyCode) PlayerPrefs.GetInt("sFire");
        escape = (KeyCode) PlayerPrefs.GetInt("escape");
        inventory = (KeyCode) PlayerPrefs.GetInt("inventory");
        map = (KeyCode) PlayerPrefs.GetInt("map");
        sprint = (KeyCode)PlayerPrefs.GetInt("sprint");
        use = (KeyCode)PlayerPrefs.GetInt("use");
        drop = (KeyCode)PlayerPrefs.GetInt("drop");
    }
}
