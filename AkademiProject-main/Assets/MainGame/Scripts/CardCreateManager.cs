using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCreateManager : MonoBehaviour
{
    [SerializeField] GameManager _gameManager;
    [SerializeField] ResourceManager _resourceManager;
    [SerializeField] MinigameManager _minigameManager;

    [SerializeField] Transform _cardBackGroundParent;

    int _storyValue = 0;

    public void CardCreate(Card card)
    {
        Debug.Log(card.ChosenAnswer);
        if (_resourceManager.Cards.Count == 0)
        {
            _gameManager.LoadCard(_resourceManager.EndCards[0]);
            return;
        }
        _minigameManager.Selector(card);

        switch (card.CardID)
        {
            case 0:
                NewCard();
                break;
            case 1:
                if (_storyValue == _resourceManager.Story1.Length - 1)
                {
                    NewCard();
                    _storyValue = 0;
                }
                else
                {
                    if (card.TrueAnswer == card.ChosenAnswer)
                    {
                        _storyValue++;
                        _gameManager.LoadCard(_resourceManager.Story1[_storyValue]);
                    }
                    else
                    {
                        NewCard();
                        _storyValue = 0;
                    }
                }
                break;
            case 2:
                if (_storyValue == _resourceManager.Story2.Length - 1)
                {
                    NewCard();
                    _storyValue = 0;
                }
                else
                {
                    if (card.TrueAnswer == card.ChosenAnswer)
                    {
                        _storyValue++;
                        _gameManager.LoadCard(_resourceManager.Story2[_storyValue]);
                    }
                    else
                    {
                        NewCard();
                        _storyValue = 0;
                    }
                }
                break;
                case 3:
                if (_storyValue == _resourceManager.Story3.Length - 1)
                {
                    NewCard();
                    _storyValue = 0;
                }
                else
                {
                    if (card.TrueAnswer == card.ChosenAnswer)
                    {
                        _storyValue++;
                        _gameManager.LoadCard(_resourceManager.Story3[_storyValue]);
                    }
                    else
                    {
                        NewCard();
                        _storyValue = 0;
                    }
                }
                break;
                case 4:
                if (_storyValue == _resourceManager.Story4.Length - 1)
                {
                    NewCard();
                    _storyValue = 0;
                }
                else
                {
                    if (card.TrueAnswer == card.ChosenAnswer)
                    {
                        _storyValue++;
                        _gameManager.LoadCard(_resourceManager.Story4[_storyValue]);
                    }
                    else
                    {
                        NewCard();
                        _storyValue = 0;
                    }
                }
                break;
        }
    }
    public void NewCard()
    {
        int rollDice = Random.Range(0, _resourceManager.Cards.Count);
        _gameManager.LoadCard(_resourceManager.Cards[rollDice]);

        //Kart tekrari olmamasi icin bu satiri acmak lazim
        _resourceManager.Cards.Remove(_resourceManager.Cards[rollDice]);

        //Holder
        Transform[] childs = _cardBackGroundParent.GetComponentsInChildren<Transform>();
        for (int i = 1; i < childs.Length; i++)
        {
            childs[i].gameObject.SetActive(false);

        }
        switch (_resourceManager.Cards[rollDice].CardID)
        {
            case 0:
                _resourceManager.CardHolders[0].SetActive(true);
                break;
            case 1:
                _resourceManager.CardHolders[1].SetActive(true);
                break;
            case 2:
                _resourceManager.CardHolders[1].SetActive(true);
                break;
                case 3:
                _resourceManager.CardHolders[1].SetActive(true);
                break;
        }
    }
}
