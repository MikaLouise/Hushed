using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public GameObject interactText;
    public bool interactEnabled = false;
    // Start is called before the first frame update
    void Start()
    {
        interactText = this.gameObject.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if(interactEnabled)
            {
                Interact();
            }      
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Player"))
        {
            ShowText();
            interactEnabled = true;
            
        }    
    }

    private void OnTriggerExit(Collider collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            interactText.SetActive(false);
            interactEnabled = false;
        }
    }

    public virtual void ShowText()
    {
        interactText.SetActive(true);
        
    }

    public virtual void Interact()
    {
        Debug.Log("This is base class");
    }
}
