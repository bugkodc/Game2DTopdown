using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootContrainerInteract : Interactable
{
    [SerializeField] private GameObject closedCheats;
    [SerializeField] private GameObject openCheats;
    [SerializeField] private bool opened;

    public override bool Equals(object other)
    {
        return base.Equals(other);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override void Interact(Player player)
    {
        if(opened == false)
        {
            opened = true;
            closedCheats.SetActive(false);
            openCheats.SetActive(true);
        }
        else
        {
            opened = false;
            closedCheats.SetActive(true);
            openCheats.SetActive(false);
        }
    }
}
