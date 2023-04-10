using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceManager : MonoBehaviour
{
    [Header("Card")]
    [SerializeField] GameManager _gameManager;
    [SerializeField] GameObject _card;

    [Header("UI Icons")]
    [SerializeField] Image MagicPowerIcon;
    [SerializeField] Image KnowledgeIcon;
    [SerializeField] Image SociabilityIcon;
    [SerializeField] Image HealthIcon;
    
    [Header("UI Impact Icons")]
    [SerializeField] Image MagicPowerIconImpact;
    [SerializeField] Image KnowledgeIconImpact;
    [SerializeField] Image SociabilityIconImpact;
    [SerializeField] Image HealthIconImpact;


    void Update()
    {
        //UI icons (artis azalisa gore ayar)
        MagicPowerIcon.fillAmount = (float)GameManager.PlayerMagicPower / GameManager.MaxValue;
        KnowledgeIcon.fillAmount = (float)GameManager.PlayerKnowledge / GameManager.MaxValue;
        SociabilityIcon.fillAmount = (float)GameManager.PlayerSociability / GameManager.MaxValue;
        HealthIcon.fillAmount = (float)GameManager.PlayerHealth / GameManager.MaxValue;

        //UI impact icons (Etkilenecek olan ikonun(yani artan veya azalan) altinda isaret cikiyor)
        //Right
        if (_gameManager.Direction == "right")
        {
            if (_gameManager.CurrentCard.MagicPowerRight != 0)
                MagicPowerIconImpact.transform.localScale = new Vector3(1, 1, 0);
            if (_gameManager.CurrentCard.KnowledgeRight != 0)
                KnowledgeIconImpact.transform.localScale = new Vector3(1, 1, 0);
            if (_gameManager.CurrentCard.SociabilityRight != 0)
                SociabilityIconImpact.transform.localScale = new Vector3(1, 1, 0);
            if (_gameManager.CurrentCard.HealthRight != 0)
                HealthIconImpact.transform.localScale = new Vector3(1, 1, 0);
            Debug.Log(_gameManager.Direction);
        }
        //Left
        else if (_gameManager.Direction == "left")
        {
            if (_gameManager.CurrentCard.MagicPowerLeft != 0)
                MagicPowerIconImpact.transform.localScale = new Vector3(1, 1, 0);
            if (_gameManager.CurrentCard.KnowledgeLeft != 0)
                KnowledgeIconImpact.transform.localScale = new Vector3(1, 1, 0);
            if (_gameManager.CurrentCard.SociabilityLeft != 0)
                SociabilityIconImpact.transform.localScale = new Vector3(1, 1, 0);
            if (_gameManager.CurrentCard.HealthLeft != 0)
                HealthIconImpact.transform.localScale = new Vector3(1, 1, 0);
            Debug.Log(_gameManager.Direction);
        }
        else
        {
            MagicPowerIconImpact.transform.localScale = Vector3.zero;
            KnowledgeIconImpact.transform.localScale = Vector3.zero;
            SociabilityIconImpact.transform.localScale = Vector3.zero;
            HealthIconImpact.transform.localScale = Vector3.zero;
            Debug.Log(_gameManager.Direction);
        }
    }
}
