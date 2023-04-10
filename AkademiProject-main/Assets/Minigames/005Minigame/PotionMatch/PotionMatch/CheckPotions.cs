using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPotions : MonoBehaviour
{
    public GameObject mixingPoint1, mixingPoint2, potionToCraft;

    [HideInInspector] public string id1, id2;
    private string currentid1, currentid2;
    [HideInInspector]public bool isCompleted = false;
    private PotionMatchController potionMatchController;

    private void Start()
    {
        potionMatchController = GameObject.Find("PotionMatch_Controller").GetComponent<PotionMatchController>();
    }

    private void Update()
    {
        if (mixingPoint1.GetComponent<MixingPoint>().isFull && mixingPoint2.GetComponent<MixingPoint>().isFull)
        {
            Check();
        }
    }

    public void Check()
    {
        if (mixingPoint1 != null)
        {
            id1 = mixingPoint1.GetComponent<MixingPoint>().collidingObject.GetComponent<Potion>().potionId;
        }
        if (mixingPoint2 != null)
        {
            id2 = mixingPoint2.GetComponent<MixingPoint>().collidingObject.GetComponent<Potion>().potionId;
        }

        currentid1 = id1 + id2;
        currentid2 = id2 + id1;

        if (!isCompleted)
        {
            if (potionToCraft.GetComponent<PotionToCraft>().id1 == currentid1 || potionToCraft.GetComponent<PotionToCraft>().id1 == currentid2 || potionToCraft.GetComponent<PotionToCraft>().id2 == currentid1 || potionToCraft.GetComponent<PotionToCraft>().id2 == currentid2)
            {
                isCompleted = true;
                potionMatchController.PotionMatchCompleted();
            }
        }
        
    }
}
