using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Vector3 respawnPoint = new Vector3(-12.1f, -0.02000001f, -1.7f);
    public GameObject player;

    public GameObject winPanel, gameOverPanel;

    public List<GameObject> objectivesList;
    public List<GameObject> KeyQuestionsList;
    public enum GameState
    {
        ACTIVE,
        PAUSED,
        GAMEOVER,
        WIN
    }

    public GameState gameState;

    public bool hasKey;
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
        switch(gameState)
        {
            case GameState.ACTIVE:
                Time.timeScale = 1f;
                break;
            case GameState.GAMEOVER:
                Time.timeScale = 0f;
                break;
            case GameState.WIN:
                Time.timeScale = 0f;
                break;
            case GameState.PAUSED:
                Time.timeScale = 0f;
                break;
        }
    }

    public void StageClear()
    {
        winPanel.SetActive(true);
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
    }

    public void ObjectiveClear(int objectiveID)
    {
        objectivesList[objectiveID].SetActive(false);
        if (CompletedAllObjectivees(objectivesList) && CompletedAllKeyQuestions())
        {
            NewObjective(5);
        }
    }

    public void NewObjective(int objectiveID)
    {
        objectivesList[objectiveID].SetActive(true);
    }

    public bool CompletedAllObjectivees(List<GameObject> collection)
    {
        for (int i = 0; i < collection.Count; i++)
            if (collection[i].activeSelf)
            {
                return false;
            }
        return true;
    }

    public bool CompletedAllKeyQuestions()
    {
        for (int i = 0; i < KeyQuestionsList.Count; i++)
            if (KeyQuestionsList[i].GetComponent<ClueSlot>().asnwerCorrect == false)
            {
                return false;
            }
        return true;
    }
}
