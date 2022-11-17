using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItem
{
    public void PrimaryUse();
    public void SecondaryUse();
    public GameObject GetHoldingPoint();
    public void Drop();
}
