using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HidePlayer : MonoBehaviour
{
    public GameObject interactText;

    public Color original;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactText.SetActive(true);

            Color temp = other.gameObject.GetComponent<SpriteRenderer>().color;
            original = other.gameObject.GetComponent<SpriteRenderer>().color;

            temp = new Color(original.r, original.g, original.b, 0.6f);
            original = new Color(original.r, original.g, original.b, 1f);

            if (Input.GetKeyDown(KeyCode.S))
            {
                Debug.Log("Hide");
                other.gameObject.GetComponent<PlayerMovement>().playerState = PlayerMovement.PlayerState.HIDING;
                other.gameObject.GetComponent<SpriteRenderer>().color = temp;
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                Debug.Log("Show");
                other.gameObject.GetComponent<PlayerMovement>().playerState = PlayerMovement.PlayerState.IDLE;
                other.gameObject.GetComponent<SpriteRenderer>().color = original;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<SpriteRenderer>().color = original;
            other.gameObject.GetComponent<PlayerMovement>().playerState = PlayerMovement.PlayerState.IDLE;
            interactText.SetActive(false);
        }
    }
}
