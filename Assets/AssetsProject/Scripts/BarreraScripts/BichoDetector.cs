using UnityEngine;

public class BichoDetector : MonoBehaviour
{
    [HideInInspector] public AudioManager audioManagerBichoDetector;
    public GameObject aire;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == aire)
        {
            if (audioManagerBichoDetector != null)
            {
                audioManagerBichoDetector.BichoSound(transform.position);
            }
        }
    }


}
