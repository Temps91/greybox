using UnityEngine;

public class CuadroCollider : MonoBehaviour
{
    public GameObject player;
    public PlayerVision playervida;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            playervida.QuitarVida(1);
            this.gameObject.SetActive(false);

        }
    }
}
