using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInventoryController : MonoBehaviour
{
    [SerializeField] private GameObject panelInventory;

    public void InputUseInventory(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            panelInventory.SetActive(!panelInventory.activeInHierarchy);
        }
    }

}
