using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvComponent : MonoBehaviour
{
    [SerializeField]
    RawImage rawImg;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetImg(Texture t)
    {
        rawImg.texture = t;
    }
}
