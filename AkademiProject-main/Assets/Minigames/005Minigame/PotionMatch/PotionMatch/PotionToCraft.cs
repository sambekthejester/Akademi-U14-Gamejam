using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionToCraft : MonoBehaviour
{
    private GameObject potionToCraft;
    public string id1, id2;
    public List<GameObject> potions;

    private void Start()
    {
        GeneratePotion();
    }

    private void GeneratePotion()
    {
        potionToCraft = potions[Random.Range(0, potions.Count)];
        Instantiate(potionToCraft, gameObject.transform);
        id1 = potionToCraft.GetComponent<CraftedPotion>().craftedId1;
        id2 = potionToCraft.GetComponent<CraftedPotion>().craftedId2;
    }
}
