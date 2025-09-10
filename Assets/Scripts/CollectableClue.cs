using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollectableClue : Interactable
{
    public GameObject openClueMain,openClueSpecific;
    // Start is called before the first frame update
    public override void ShowText()
    {
        base.ShowText();
        base.interactText.GetComponent<TextMeshPro>().text = "[F] Collect Clue";
    }

    public override void Interact()
    {
        openClueMain.SetActive(true);
        openClueSpecific.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
