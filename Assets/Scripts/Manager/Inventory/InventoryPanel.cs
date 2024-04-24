using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPanel : MonoBehaviour
{
    [SerializeField] private ItemContainerData inventory ;
    [SerializeField] private List<InventoryButton> buttons;
    void Start()
    {
        SetIndex();
        ShowPanel();
    }
    private void OnEnable()
    {
        ShowPanel();
    }
    public void ShowPanel()
    {
        for (int i = 0; i < inventory.slots.Count; i++)
        {
            if (inventory.slots[i].item == null)
            {
                buttons[i].Clean();
            }
            else
            {
                buttons[i].Set(inventory.slots[i]);
            }
        }

    }
    private void SetIndex()
    {
        for(int i = 0; i < inventory.slots.Count; i++) 
        {
            buttons[i].SetIndex(i);
        }
    }
}
