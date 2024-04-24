using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnManager : Singleton<ItemSpawnManager>
{
    [SerializeField] private GameObject pickUpItemPrefab;
    public void SpawnItem(Vector3 position , ItemData item , int count)
    {
        GameObject obj = Instantiate(pickUpItemPrefab , position , Quaternion.identity);
        obj.GetComponent<PickUpitem>().Set(item , count);
    }
}
