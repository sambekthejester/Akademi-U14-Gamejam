using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PotionMatchController : MonoBehaviour
{
    [SerializeField] MinigameManager _minigameManager;

    public float startTime = 120f;
    public TMP_Text potionTimeText;

    private float timeRemaining;

    private void Start()
    {
        timeRemaining = startTime;
    }

    private void Update()
    {
        timeRemaining -= Time.deltaTime;

        potionTimeText.text = "TIME: " + Mathf.RoundToInt(timeRemaining).ToString();

        if (timeRemaining <= 0)
        {
            timeRemaining = 0;
            PotionMatchFailed();
        }

    }

    public void PotionMatchFailed()
    {
        _minigameManager.Lose();
    }

    public void PotionMatchCompleted()
    {
        _minigameManager.Win();


    }
}
