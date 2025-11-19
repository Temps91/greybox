using System;
using UnityEngine;

public class DemonsManager : MonoBehaviour
{
    public Demons[] allDemons;
    public GameObject[] enemyGenericItems;

    private void Start()
    {
        DesactivateAllEnemyItems();
    }

    public void CheckItem(Item pickedItem)
    {
        foreach (var demon in allDemons)
        {
            bool activated = demon.AddItem(pickedItem);
            if (activated)
            {
                demon.ActiveAllObjects();
                ActiveAllEnemyItems();
                Debug.Log($"Evento: Demon {demon.demonName} activado por el manager");
            }
        }
    }
    
    public void ActiveAllEnemyItems()
    {
        for(int i = 0; i < enemyGenericItems.Length; i++)
        {
            enemyGenericItems[i].SetActive(true);
        }
    }
    
    public void DesactivateAllEnemyItems()
    {
        for(int i = 0; i < enemyGenericItems.Length; i++)
        {
            enemyGenericItems[i].SetActive(false);
        }
    }
}
