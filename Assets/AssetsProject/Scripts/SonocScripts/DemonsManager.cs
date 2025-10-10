using UnityEngine;

public class DemonsManager : MonoBehaviour
{
    public Demons[] allDemons;

    public void CheckItem(Item pickedItem)
    {
        foreach (var demon in allDemons)
        {
            bool activated = demon.AddItem(pickedItem);
            if (activated)
            {
                Debug.Log($"Evento: Demon {demon.demonName} activado por el manager");
            }
        }
    }
}
