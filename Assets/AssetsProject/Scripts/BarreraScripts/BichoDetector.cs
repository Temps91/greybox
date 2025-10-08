using UnityEngine;

public class BichoDetector : MonoBehaviour
{
    public AudioManager audioManagerBichoDetector;
    public GameObject aire;
    public GameObject destino;
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == aire)
        {
            Debug.Log("Se detecto aire");
            audioManagerBichoDetector.BichoSound(transform.position);
            Debug.Log("Sonido activado");
        }
        else if (other.gameObject == player)
        {
            this.gameObject.SetActive(false);

        }
        else if (other.gameObject == destino)
        {

            this.gameObject.SetActive(false) ;

        }
    }



}
