using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickUpitem : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float pickUpDistance = 1.5f;
    [SerializeField] private float ttl = 10f;
    public ItemData item;
    public int count = 1;
    private void Awake()
    {
        player = GameManager.Instance.player.transform;
    }
    public void Set(ItemData item, int count)
    {
        this.item = item;
        this.count = count;
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = item.icon;
    }
    private void Update()
    {
        PickUpItem();
    }
    private void PickUpItem()
    {
        ttl -= Time.deltaTime;
        if (ttl == 0)
        {
            Destroy(gameObject);
        }
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance > pickUpDistance)
        {
            return;
        }
        transform.position = Vector3.MoveTowards(transform.position , player.position , speed * Time.deltaTime);
        if(distance < 0.1f)
        {
            if(GameManager.Instance.inventoryContainer != null)
            {
               GameManager.Instance.inventoryContainer.Add(item , count);
            }
            else
            {
                Debug.Log(" bug inventory");
            }
            Destroy(gameObject);
        }
    }
}
