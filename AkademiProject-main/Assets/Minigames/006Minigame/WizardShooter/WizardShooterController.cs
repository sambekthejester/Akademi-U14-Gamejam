using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardShooterController : MonoBehaviour
{
    [SerializeField] MinigameManager _minigameManager;


    public void WizardShooterCompleted()
    {
        _minigameManager.Win();
    }

    public void WizardShooterFailed()
    {
        _minigameManager.Lose();

    }
}
