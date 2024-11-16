using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField]  short ammoPoints;

    // Start is called before the first frame update
    void Start()
    {
        ammoPoints = 0;
    }

    public void AddAmmo(short _count)
    {
        ammoPoints += _count;
    }
    void RemoveAmmo(short _count)
    {
        ammoPoints -= _count;
    }
    short GetAmmo()
    {
        return ammoPoints;
    }
}
