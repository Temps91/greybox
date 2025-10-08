using UnityEngine;

public class DeteccionCaida : MonoBehaviour
{
    public GameObject suelo;
    [HideInInspector] public AudioManager audioManagerDeteccionCaida;
    public GameObject player;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == suelo)
        {
            if (audioManagerDeteccionCaida != null)
            {
                audioManagerDeteccionCaida.CaidaSound(transform.position);
            }
        }
        if (collision.gameObject == player)
        {
            audioManagerDeteccionCaida.CaidaSound(transform.position);
        }
       

        
    }

}
