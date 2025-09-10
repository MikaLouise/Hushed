using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickOpenClue : MonoBehaviour
{
    public GameObject clueToShow;

    //public GameObject[] cluesToOpen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowClue()
    {
        UnlockClueManager.instance.UnlockClue(clueToShow);
        this.gameObject.GetComponent<Button>().interactable = false;
    }
}
