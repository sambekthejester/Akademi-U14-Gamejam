using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Card : ScriptableObject
{
    [Header("Basic Card Values")]
    [SerializeField] int _cardID;
    [SerializeField] string _cardName;
    [SerializeField] CardSpriteEnum _cardSprite;
    [SerializeField] [TextArea()] string _cardDialogue;
    [SerializeField] string _leftAnswer;
    [SerializeField] string _rightAnswer;
    [SerializeField] AnswersEnum _trueAnswer;
    [SerializeField] bool _isMinigame;
    public string LeftEffect;
    public string RightEffect;
    AnswersEnum _chosenAnswer;
    public AudioClip ses;
    public int CardID { get { return _cardID; } }
    public string CardName { get { return _cardName; } }
    public CardSpriteEnum CardSprite { get { return _cardSprite; } }
    public string CardDialogue { get { return _cardDialogue; } }
    public string LeftAnswer { get { return _leftAnswer; } }
    public string RightAnswer { get { return _rightAnswer; } }
    public AnswersEnum TrueAnswer { get { return _trueAnswer; } }
    public AnswersEnum ChosenAnswer { get { return _chosenAnswer; } }
    public bool IsMinigame { get { return _isMinigame; } }

    [Header("Impact Card Values")]
    [Header("Left")]
    [Range(-20, 20)] [SerializeField] int _magicPowerLeft;
    [Range(-20, 20)] [SerializeField] int _knowledgeLeft;
    [Range(-20, 20)] [SerializeField] int _sociabilityLeft;
    [Range(-20, 20)] [SerializeField] int _healthLeft;
    public int MagicPowerLeft { get { return _magicPowerLeft; } }
    public int KnowledgeLeft { get { return _knowledgeLeft; } }
    public int SociabilityLeft { get { return _sociabilityLeft; } }
    public int HealthLeft { get { return _healthLeft; } }

    [Header("Right")]
    [Range(-20, 20)] [SerializeField] int _magicPowerRight;
    [Range(-20, 20)] [SerializeField] int _knowledgeRight;
    [Range(-20, 20)] [SerializeField] int _sociabilityRight;
    [Range(-20, 20)] [SerializeField] int _healthRight;
    public int MagicPowerRight { get { return _magicPowerRight; } }
    public int KnowledgeRight { get { return _knowledgeRight; } }
    public int SociabilityRight { get { return _sociabilityRight; } }
    public int HealthRight { get { return _healthRight; } }

    [Header("Card Audio")]
    [SerializeField] AudioClip _cardAudioClip;
    public AudioClip CardAudioClip { get { return _cardAudioClip; } }

    public void Left()
    {
        Debug.Log(CardName + " - left");
        GameManager.PlayerMagicPower += _magicPowerLeft;
        GameManager.PlayerKnowledge += _knowledgeLeft;
        GameManager.PlayerSociability += _sociabilityLeft;
        GameManager.PlayerHealth += _healthLeft;
        _chosenAnswer = AnswersEnum.LeftAnswer;
    }
    public void Right()
    {
        Debug.Log(CardName + " - right");
        GameManager.PlayerMagicPower += _magicPowerRight;
        GameManager.PlayerKnowledge += _knowledgeRight;
        GameManager.PlayerSociability += _sociabilityRight;
        GameManager.PlayerHealth += _healthRight;
        _chosenAnswer = AnswersEnum.RightAnswer;
    }

}
