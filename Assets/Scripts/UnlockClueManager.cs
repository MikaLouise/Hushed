using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class UnlockClueManager : MonoBehaviour
{
    public static UnlockClueManager instance;

    public GameObject clueImage, clueName, clueCategory, clueDesc;

    public GameObject clueUnlockedPanel;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UnlockClue(GameObject clue)
    {
        var clues = Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.name == clue.name);
        foreach (var i in clues)
        {
            i.gameObject.SetActive(true);
        }

        clueUnlockedPanel.SetActive(true);

        Clues clueInfo = clue.GetComponent<Clues>(); 

        clueImage.GetComponent<Image>().sprite = clueInfo.clueImage;
        clueName.GetComponent<TextMeshProUGUI>().text = clueInfo.clueName;
        clueDesc.GetComponent<TextMeshProUGUI>().text = clueInfo.clueInfo;

        switch (clueInfo.clueCategory)
        {
            case Clues.ClueCategory.WITNESS_STATEMENTS:
                clueCategory.GetComponent<TextMeshProUGUI>().text = "Witness Statement";
                break;

            case Clues.ClueCategory.PHYSICAL_EVIDENCE:
                clueCategory.GetComponent<TextMeshProUGUI>().text = "Physical Evidence";
                break;

            case Clues.ClueCategory.TIMELINE:
                clueCategory.GetComponent<TextMeshProUGUI>().text = "Timeline";
                break;
        }
    }

    public void OpenCluesInNotebook()
    {
        var clues = Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.name == this.gameObject.name);
        foreach (var i in clues)
        {
            i.gameObject.SetActive(false);
        }
    }
}
