using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MinigameManager : MonoBehaviour
{
    [SerializeField] List<GameObject> _minigames;
    [SerializeField] GameObject _gameScene;
    [SerializeField] ResourceManager _resourceManager;
    [SerializeField] TMP_Text characterDialogue; // Bu satırı ekleyin

    private TypeWriterEffect typeWriterEffect; // Bu satırı ekleyin
    
    int _randomKey;

    private void Awake() // Bu metodu ekleyin
    {
        typeWriterEffect = characterDialogue.GetComponent<TypeWriterEffect>();
    }

    public void Selector(Card card)
    {
        if (_minigames.Count == 0)
            return;

        if (card.IsMinigame && card.ChosenAnswer == AnswersEnum.RightAnswer)
        {
            typeWriterEffect.StopTyping(); // Bu satırı ekleyin
            _randomKey = Random.Range(0, _minigames.Count);
            _minigames[_randomKey].SetActive(true);
            _gameScene.SetActive(false);
        }
    }
    public void Win()
    {
        Debug.Log("Win");
        _minigames[_randomKey].SetActive(false);
        _gameScene.SetActive(true);
        _minigames.Remove(_minigames[_randomKey]);
        typeWriterEffect.ResumeTyping(); // Bu satırı ekleyin
    }
    public void Lose()
    {
        Debug.Log("Lose");
        _minigames[_randomKey].SetActive(false);
        _gameScene.SetActive(true);
        _minigames.Remove(_minigames[_randomKey]);
        typeWriterEffect.ResumeTyping(); // Bu satırı ekleyin
    }
}
