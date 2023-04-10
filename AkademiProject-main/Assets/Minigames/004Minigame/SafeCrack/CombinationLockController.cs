using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CombinationLockController : MonoBehaviour
{
    [SerializeField] MinigameManager _minigameManager;

    public float startTime = 120f;
    public TMP_Text combinationLockTimeText;

    private float timeRemaining;

    private void Start()
    {
        timeRemaining = startTime;
    }

    private void Update()
    {
        timeRemaining -= Time.deltaTime;

        combinationLockTimeText.text = "TIME: " + Mathf.RoundToInt(timeRemaining).ToString();

        if (timeRemaining <= 0)
        {
            timeRemaining = 0;
            CombinationLockFailed();
        }

    }

    public void CombinationLockCompleted()
    {
        _minigameManager.Win();
    }

    public void CombinationLockFailed()
    {
        _minigameManager.Lose();
    }
}
