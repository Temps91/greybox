using UnityEngine;
using System.Collections;

public class Cauldron : MonoBehaviour
{
    public Queue organs;
    public Queue candles;
    public Queue genericObjects;

    public ParticleSystem fire;
    public ParticleSystem vfx;

    public DemonsManager demonsManager;
    public GameReset gameReset;

    private void Start()
    {
        organs = new Queue();
        candles = new Queue();
        genericObjects = new Queue();

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<TriggerItems>(out var otherItem))
        {

            switch (otherItem.thisItem.typeItem)
            {
                case enumTypeItem.organ:
                    if (organs.Count == 0)
                    {
                        Debug.Log("Ahi va un organo nuevo");
                        organs.Enqueue(otherItem.thisItem);

                        demonsManager.CheckItem(otherItem.thisItem);
                        vfx.gameObject.SetActive(false);
                        vfx.gameObject.SetActive(true);
                    }
                    else
                    {
                        Debug.Log("Ya hay un organo");
                        gameReset.StartCoroutine(gameReset.ResetJuego());
                        //Reinicia Todo
                    }
                    break;
                case enumTypeItem.objectGeneric:
                {
                        if (organs.Count <= 4)
                        {
                            Debug.Log("Ahi va un item nuevo");
                            genericObjects.Enqueue(otherItem.thisItem);

                            demonsManager.CheckItem(otherItem.thisItem);
                            vfx.gameObject.SetActive(false);
                            vfx.gameObject.SetActive(true);
                        }
                        else
                        {
                            Debug.Log("Ya no cabo");
                            gameReset.StartCoroutine(gameReset.ResetJuego());
                            //Reinicia Todo
                        }
                        
                }
                break;
            
                case enumTypeItem.candle:
                {
                    if (candles.Count == 0)
                    {
                        Debug.Log("Velita y me pinto de....");
                        Color newCandleColor = ((Candle)otherItem.thisItem).targetColor;
                        var mainProperties = fire.main;
                        mainProperties.startColor = newCandleColor;
                        candles.Enqueue(otherItem.thisItem);
                        demonsManager.CheckItem(otherItem.thisItem);
                            vfx.gameObject.SetActive(false);
                            vfx.gameObject.SetActive(true);
                        }
                    else
                    {
                       Debug.Log("Ya hay una vela");
                       gameReset.StartCoroutine(gameReset.ResetJuego());
                            //Reinicia Todo
                    }



                }
                break;
            }
            
            otherItem.gameObject.SetActive(false);
        }
    }
}
