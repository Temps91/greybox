using UnityEngine;
using System.Collections;

public class Cauldron : MonoBehaviour
{
    public Queue organs;

    public ParticleSystem fire;
    public ParticleSystem vfx;

    public Demons[] allDemons;

    private void Start()
    {
        organs = new Queue();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<TriggerItems>(out var otherItem))
        {
            vfx.Play();

            switch (otherItem.thisItem.typeItem)
            {
                case enumTypeItem.organ:
                    if (organs.Count == 0)
                    {
                        Debug.Log("Ahi va un organo nuevo");
                        organs.Enqueue(otherItem.thisItem);
                    }
                    else
                    {
                        Debug.Log("Ya hay un organo");
                        //Reinicia Todo
                    }
                    break;
                case enumTypeItem.objectGeneric:
                {
                
                }
                    break;
            
                case enumTypeItem.candle:
                {
                    Color newCandleColor = ((Candle)otherItem.thisItem).targetColor;
                    var mainProperties = fire.main;
                    mainProperties.startColor = newCandleColor;
                }
                    break;
            }
        }
    }
}
