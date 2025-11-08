using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private PlayerVision playerVision;

    private void Start()
    {
        playerVision = GetComponent<PlayerVision>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemigo"))
        {
            Debug.Log("toque al player bicho");
            other.gameObject.SetActive(false);
            playerVision.QuitarVida(1);
        }
    }
}
