using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TalkInteract : Interactable
{
    // Start is called before the first frame update
    public override void ShowText()
    {
        base.ShowText();
        base.interactText.GetComponent<TextMeshPro>().text = "[F] To Talk";
    }

    public override void Interact()
    {
        Debug.Log("talk");
        this.gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
    }
}
