using UnityEngine;

public class Criature : MonoBehaviour
{
    public GameObject prefabCriatura;
    public GameObject player;
    public float velocidad;
    [HideInInspector] public AudioManager audioManager;
    private bool criaturaActivada;
    public float distanceMax;


    private void Start()
    {
        criaturaActivada = false;
    }
    private void FixedUpdate()
    {
        if (criaturaActivada)
        {
            prefabCriatura.SetActive(true);
            prefabCriatura.transform.LookAt(player.transform.position);
            prefabCriatura.transform.Translate(Vector3.forward * velocidad * Time.deltaTime, Space.World);
            var bichoCreado = prefabCriatura.GetComponent<BichoDetector>(); ;
            if (bichoCreado != null)
            {
                bichoCreado.audioManagerBichoDetector = audioManager;
            }
        }
        else
        {
            return;
        }
    }

    public void ActivarCriatura()
    {
        criaturaActivada = true;

    }

}
