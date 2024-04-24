using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkInteract : Interactable
{
    [SerializeField] private DialohueContainer dialohueContainer;
    public override void Interact(Player player)
    {
        GameManager.Instance.dialogueSystem.Initalize(dialohueContainer);
    }
}
