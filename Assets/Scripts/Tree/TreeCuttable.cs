using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCuttable : ToolHit
{
    [SerializeField] private GameObject pickUpDrop;
    [SerializeField] private float spread = 0.7f;
    [SerializeField] private ItemData item;
    [SerializeField] private int itemCountInoneDrop = 1;
    [SerializeField] private int dropCount;
    public override void Hit()
    {
        base.Hit();
        while(dropCount > 0)
        {
            dropCount--;
            Vector3 position = transform.position;
            position.x += spread * Random.value - spread / 2;
            position.y += spread * Random.value - spread / 2;
            ItemSpawnManager.Instance.SpawnItem(position, item,itemCountInoneDrop);
        }
        Destroy(gameObject);
    }
}
