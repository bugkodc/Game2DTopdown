using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DayTimeController : MonoBehaviour
{
    const float sencondsInDay = 86400f;
    [SerializeField] private Color nightLightColor;
    [SerializeField] private AnimationCurve nightTimeCurve;
    [SerializeField] private Color dayLightColor = Color.white;
    float time;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] float timeScale = 60f;
    [SerializeField] Light2D globalLight;
    private int days;
    void Start()
    {
        
    }
    float Hours{    get { return time / 3600f; }}
    float Minutes { get { return time % 3600f / 60f; } }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime * timeScale;
        int hh = (int)Hours;
        int mm = (int)Minutes;
        text.text = Hours.ToString("00")+ ":" + mm.ToString("00");
        float v = nightTimeCurve.Evaluate(Hours);
        Color c = Color.Lerp(dayLightColor,nightLightColor,v);  
        globalLight.color = c;
        if(time > sencondsInDay)
        {
            NextDay();
        }
    }
    private void NextDay()
    {
        time = 0;
        days += 1;
    }
}
