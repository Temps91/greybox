using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Demons
{
    public string demonName;
    public List<Item> itemsToSummon;
    public GameObject[] objectsToActivate;
    public Color fogColor;

    public int collectedItems = 0;

    public bool AddItem(Item item)
    {
        if (itemsToSummon.Exists(i => i.name == item.name))
        {
            collectedItems++;
            Debug.Log($"Demon {demonName} recibió {item.name}, contador: {collectedItems}");

            if (collectedItems >= 6)
            {
                Debug.Log($"¡Demon {demonName} ha sido activado!");
                RenderSettings.fogColor = fogColor;
                return true;
            }
        }
        return false;
    }

    public void ActiveAllObjects()
    {
        for(int i = 0; i < objectsToActivate.Length; i++)
        {
            objectsToActivate[i].SetActive(true);
        }
    }


}
