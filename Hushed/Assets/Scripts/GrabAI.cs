using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GrabAI : MonoBehaviour
{
    public GameObject player;
    public float speed;
    private float counter = 0f;
    public float breakTime;
    private int grab;
    public GameObject[] arms;
    public enum AIState
    {
        IDLE,
        CHASE,
        GRAB,
        GRABBED,
        DOWNED
    }

    public AIState aiState;
    // Start is called before the first frame update
    void Start()
    {
        grab = UnityEngine.Random.Range(0, 2);
    }

    // Update is called once per frame
    void Update()
    {
        switch(aiState)
        {
            case AIState.IDLE:

                break;

            case AIState.CHASE:
                ChasePlayer();
                break;

            case AIState.GRAB:
                Grabbing();
                break;

            case AIState.GRABBED:
                player.gameObject.SetActive(false);
                if(GameManager.instance.gameState == GameManager.GameState.ACTIVE)
                {
                    aiState = AIState.IDLE;
                }
                
                break;

            case AIState.DOWNED: 
                this.gameObject.SetActive(false);
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.gameObject;
            aiState = AIState.CHASE;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = null;
            aiState = AIState.IDLE;
        }
    }

    public void ChasePlayer()
    {
        transform.position = Vector2.MoveTowards(this.transform.position, new Vector2(player.transform.position.x, this.transform.position.y), speed * Time.deltaTime);
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance < 2)
        {
            Debug.Log("huli");
            aiState = AIState.GRAB;

        }
    }

    public void Grabbing()
    {
        player.GetComponent<PlayerMovement>().playerState = PlayerMovement.PlayerState.GRABBED;

        switch(grab)
        {
            case 0:
                arms[grab].SetActive(true);
                StartCoroutine(BreakGrab(grab));
                break;

            case 1:
                arms[grab].SetActive(true);
                StartCoroutine(BreakGrab(grab));
                break;
        }
    }

    public IEnumerator BreakGrab(int key)
    {
        if (Input.GetMouseButtonDown(key))
        {
            arms[key].SetActive(false);
            yield return aiState = AIState.DOWNED;
        }

        yield return new WaitForSeconds(breakTime);
            arms[key].SetActive(false);
            aiState = AIState.GRABBED;
            GameManager.instance.GameOver();
            GameManager.instance.gameState = GameManager.GameState.GAMEOVER;
    }
}
