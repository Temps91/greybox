using UnityEngine;

public class Criature : MonoBehaviour
{
    public GameObject prefabCriatura;
    public GameObject player;
    public float velocidad;
    [HideInInspector] public AudioManager audioManager;


    public void ActivarCriatura()
    {
        prefabCriatura.SetActive(true);
        prefabCriatura.transform.LookAt(player.transform.position);
        prefabCriatura.transform.Translate(Vector3.forward * velocidad * Time.deltaTime, Space.World);
        audioManager.BichoSound(transform.position);

    }

}
