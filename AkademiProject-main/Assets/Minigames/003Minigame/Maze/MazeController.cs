using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MazeController : MonoBehaviour
{
    [SerializeField] MinigameManager _minigameManager;
    public float startTime = 120f;
    public TMP_Text mazeTimeText;

    private float timeRemaining;

    private void Start()
    {
        timeRemaining = startTime;
    }

    private void Update()
    {
        timeRemaining -= Time.deltaTime;

        mazeTimeText.text = "TIME: " + Mathf.RoundToInt(timeRemaining).ToString();

        if (timeRemaining <= 0)
        {
            timeRemaining = 0;
            MazeFailed();
        }
    }

    public void MazeCompleted()
    {
        _minigameManager.Win();
    }

    public void MazeFailed()
    {
        _minigameManager.Lose();
    }
}
