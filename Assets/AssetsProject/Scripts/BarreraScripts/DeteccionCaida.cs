using UnityEngine;

public class DeteccionCaida : MonoBehaviour
{
    public GameObject suelo;
    [HideInInspector] public AudioManager audioManagerDeteccionCaida;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == suelo)
        {
            if (audioManagerDeteccionCaida != null)
            {
                audioManagerDeteccionCaida.CaidaSound(transform.position);
            }
        }

        
    }

}
