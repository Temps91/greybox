using UnityEngine;

public class BichoDetector : MonoBehaviour
{
    public AudioManager audioManagerBichoDetector;
    public GameObject aire;
    public GameObject destino;
    public GameObject player;
    public PlayerVision playerVida;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == destino)
        {

            this.gameObject.SetActive(false) ;

        }
        else if (other.gameObject == player)
        {
            playerVida.QuitarVida(1) ;
            this.gameObject.SetActive(false) ;
        }
    }



}
