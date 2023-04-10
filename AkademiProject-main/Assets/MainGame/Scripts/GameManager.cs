using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    [Header("Audio")]
    [SerializeField] AudioSource _audioSource;

    [Header("Player Skills")]
    public static int PlayerMagicPower = 50;
    public static int PlayerKnowledge = 50;
    public static int PlayerSociability = 50;
    public static int PlayerHealth = 50;
    public static int MaxValue = 100;
    //[SerializeField] int _minValue = 0;

    [Header("Assignments")]
    [SerializeField] GameObject _cardGameObject;
    [SerializeField] ResourceManager _resourceManager;
    [SerializeField] CardCreateManager _cardCreateManager;
    CardController _mainCardController;
    SpriteRenderer _cardSpriteRenderer;

    [Header("Card Variables")]
    public Card CurrentCard;
    [SerializeField] Card _firstCard;
    string _leftAnswer;
    string _rightAnswer;
    public string Direction { get; private set; }

    [Header("Tweaking Variables")]
    [SerializeField] float _movingSpeed;
    [SerializeField] float _rotatingSpeed;
    [SerializeField] float _sideMargin;
    [SerializeField] float _sideTrigger;
    [SerializeField] float _divineValue;
    [SerializeField] float _backgroundDivineValue;
    [SerializeField] float _actionBGTransparency = .7f;
    [SerializeField] float _inclineCard;
    [SerializeField] Color _textColor;
    [SerializeField] Color _actionBGColor;
    [SerializeField] Vector2 _defaultPosCard = new Vector2(0, 0);

    [Header("UI")]
    [SerializeField] TMP_Text _caharacterName;
    [SerializeField] TMP_Text _caharacterDialogue;
    [SerializeField] TMP_Text _actionText;
    [SerializeField] SpriteRenderer _actionBG;

    [Header("Substituting Card")]
    [SerializeField] bool _isSubstituting;
    [SerializeField] Vector3 _cardRotation;    //Default
    [SerializeField] Vector3 _initRotation;    //ilk donme


    void Awake()
    {
        //Assignments(Atamalar)
        _mainCardController = _cardGameObject.GetComponent<CardController>();
        _cardSpriteRenderer = _cardGameObject.GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        LoadCard(_firstCard);
        _audioSource.Play();
        _audioSource.PlayOneShot(CurrentCard.CardAudioClip, 0.5f);
    }
    void Update()
    {
        //Dialog text Ayari
        _textColor.a = Mathf.Min((Mathf.Abs(_cardGameObject.transform.position.x) - _sideMargin) / _divineValue, 1);
        _actionBGColor.a = Mathf.Min((Mathf.Abs(_cardGameObject.transform.position.x) - _sideMargin) / _backgroundDivineValue, _actionBGTransparency);

        if (_cardGameObject.transform.position.x > _sideTrigger)
        {
            if (Input.GetMouseButtonUp(0))
            {
                _audioSource.Stop();
                CurrentCard.Right();
                _cardCreateManager.CardCreate(CurrentCard);
                _audioSource.PlayOneShot(CurrentCard.CardAudioClip, 0.5f);
                 AudioManager.Instance.PlaySlideSound();
            }
            Direction = "right";
        }
        else if (_cardGameObject.transform.position.x > _sideMargin) { Direction = "right"; }
        else if (_cardGameObject.transform.position.x > -_sideMargin)
        {
            _textColor.a = 0;
            Direction = "none";
        }
        else if (_cardGameObject.transform.position.x > -_sideTrigger) { Direction = "left"; }
        else
        {
            if (Input.GetMouseButtonUp(0))
            {
                _audioSource.Stop();
                CurrentCard.Left();
                _cardCreateManager.CardCreate(CurrentCard);
                _audioSource.PlayOneShot(CurrentCard.CardAudioClip);
                AudioManager.Instance.PlaySlideSound();
            }
            Direction = "left";
        }
        UpdateActionDialogue();

        //Hareket
        if (Input.GetMouseButton(0) && _mainCardController.IsMouseOver)
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _cardGameObject.transform.position = pos;
            _cardGameObject.transform.eulerAngles = new Vector3(0, 0, _cardGameObject.transform.position.x * _inclineCard);
        }
        else if (!_isSubstituting)
        {
            _cardGameObject.transform.position = Vector2.MoveTowards(_cardGameObject.transform.position, _defaultPosCard, _movingSpeed);
            _cardGameObject.transform.eulerAngles = Vector3.zero;
        }
        else if (_isSubstituting)
        {
            _cardGameObject.transform.eulerAngles = Vector2.MoveTowards(_cardGameObject.transform.eulerAngles, _defaultPosCard, _rotatingSpeed);
        }

        //Rotation
        if (_cardGameObject.transform.eulerAngles == _cardRotation)
        {
            _isSubstituting = false;
        }
    }
    void UpdateActionDialogue()
    {
        _actionText.color = _textColor;
        _actionBG.color = _actionBGColor;
        if (_cardGameObject.transform.position.x < 0)
            _actionText.text = _leftAnswer;
        else
            _actionText.text = _rightAnswer;
    }

    public void LoadCard(Card card)
    {
        CurrentCard = card;
        _caharacterName.text = card.CardName;
        _cardSpriteRenderer.sprite = _resourceManager.Sprites[(int)card.CardSprite];
        _caharacterDialogue.text = card.CardDialogue;
        _leftAnswer = card.LeftAnswer;
        _rightAnswer = card.RightAnswer;

        //Reset position card
        _cardGameObject.transform.position = _defaultPosCard;
        _cardGameObject.transform.eulerAngles = Vector3.zero;

        //initialize of the substitution
        _isSubstituting = true;
        _cardGameObject.transform.eulerAngles = _initRotation;
        _audioSource.clip = card.CardAudioClip;
        _audioSource.Play();
        AudioManager.Instance.PlayCardArrivalSound();
    TypeWriterEffect typeWriterEffect = _caharacterDialogue.GetComponent<TypeWriterEffect>();
    typeWriterEffect.SetText(card.CardDialogue);

    }
}



