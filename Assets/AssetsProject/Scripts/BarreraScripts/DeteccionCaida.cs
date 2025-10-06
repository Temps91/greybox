using UnityEngine;

public class DeteccionCaida : MonoBehaviour
{
    public GameObject suelo;
    [HideInInspector] public AudioManager audioManager;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == suelo)
        {
            if (audioManager != null)
            {
                audioManager.CaidaSound(transform.position);
            }
        }
    }

}
