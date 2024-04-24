using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemDrapAndDropController : MonoBehaviour
{
    [SerializeField] private ItemSlot itemSlot;
    [SerializeField] private GameObject drapItemIcon;
    private RectTransform iconTransform;
    private Image itemIconImage;
    private void Start()
    {
        itemSlot = new ItemSlot();
        iconTransform = drapItemIcon.GetComponent<RectTransform>();
        itemIconImage = drapItemIcon.GetComponent<Image>();
    }
    private void Update()
    {
     if(drapItemIcon.activeInHierarchy == true)
        {
            iconTransform.position = Input.mousePosition;
            if(EventSystem.current.IsPointerOverGameObject() == false)
            {
                Debug.Log("kick ngoai panel ");
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                worldPosition.z = 0;
                ItemSpawnManager.Instance.SpawnItem(worldPosition, itemSlot.item, itemSlot.count);
                itemSlot.Clear();
                drapItemIcon.SetActive(false);
            }
        }   
    }
    public void OnClick(ItemSlot slot)
    {
        if(this.itemSlot.item == null)
        {
            this.itemSlot.Copy(slot);
            slot.Clear();
        }
        else
        {
            ItemData item = slot.item;
            int count = slot.count;
            slot.Copy(this.itemSlot);
            this.itemSlot.Set(item,count);
            
        }
        UpdateIcon();
    }
    private void UpdateIcon()
    {
        if(itemSlot.item == null) 
        {
            drapItemIcon.SetActive(false);
        }
        else
        {
            drapItemIcon.SetActive(true);
            itemIconImage.sprite = itemSlot.item.icon;
        }
    }
}
