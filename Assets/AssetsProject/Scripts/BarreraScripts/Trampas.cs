using Unity.XR.CoreUtils;
using UnityEngine;

public class Trampas : MonoBehaviour
{
    public GameObject player;
    public float velocidad;
    public float velocidadnormal;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            velocidad -= 5;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            velocidad = velocidadnormal;
        }
    }
}
