using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="Data/Item/ ItemData")]
public class ItemData : ScriptableObject
{
    public string Name;
    public bool stackable;
    public Sprite icon;
}
