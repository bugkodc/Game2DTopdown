using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textLine;
    [SerializeField] private TextMeshProUGUI textName;
    [SerializeField] private Image icon;
    DialohueContainer currentDialouge;
    int currentTextLine;
    [Range(0f, 1f)]
    [SerializeField] float visibleTextPercent;
    [SerializeField] float timePerLetter = 0.05f;
    float totalTimeToType;
    float currentTime;
    string lineToShow;
    private void Update()
    {
        TypeOutText();
    }
    private void TypeOutText()
    {
        if (visibleTextPercent >= 1f) return;
        currentTime += Time.deltaTime;
        visibleTextPercent = currentTime / totalTimeToType;
        visibleTextPercent = Mathf.Clamp(visibleTextPercent, 0,1f);
        UpdateText();
    }
    private void UpdateText()
    {
        int letterCount = (int)(lineToShow.Length * visibleTextPercent);
        textLine.text = lineToShow.Substring(0, letterCount);
    }
    public void InputUseDialogue(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            PushText();
        }
    }
    private void PushText()
    {
        if(visibleTextPercent < 1f)
        {
            visibleTextPercent = 1f;
            UpdateText();
            return;
        }
        if (currentTextLine >= currentDialouge.line.Count)
        {
            Conclude();
        }
        else
        {
            CyleLine();
        }
    }
    private void CyleLine()
    {
        lineToShow = currentDialouge.line[currentTextLine];
        totalTimeToType = lineToShow.Length * timePerLetter;
        currentTime = 0f;
        visibleTextPercent = 0f;
        currentTextLine += 1;
        textLine.text = " ";
    }
    public void Initalize(DialohueContainer dialohueContainer)
    {
        Show(true);
        currentDialouge = dialohueContainer;
        currentTextLine = 0;
        CyleLine();
        UpdateIcon();
    }

    private void UpdateIcon()
    {
        icon.sprite = currentDialouge.actorData.protrait;
        textName.text = currentDialouge.actorData.Name;
    }

    private void Conclude()
    {
        Debug.Log(" bug dialogue");
        Show(false);
    }
    private void Show(bool ischeckd)
    {
        gameObject.SetActive(ischeckd);
    }
}
