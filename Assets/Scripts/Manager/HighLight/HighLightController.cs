using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighLightController : MonoBehaviour
{
    [SerializeField] private GameObject highLighter;
    GameObject currentTarget;
    public void HighLight(GameObject target)
    {
        if (currentTarget == target) return;
        currentTarget = target;
        Vector3 position = target.transform.position + Vector3.up * 0.5f;
        HighLight(position);

    }
    public void HighLight(Vector3 position)
    {
        highLighter.SetActive(true);
        highLighter.transform.position = position;
    }
    public void Hide()
    {
        currentTarget = null;
        highLighter.SetActive(false);
    }
}
