using System.Collections;
using UnityEngine;

public class Criature : MonoBehaviour, IVisible
{
    public GameObject prefabCriatura;
    public GameObject player;
    public float velocidad;
    [HideInInspector] public AudioManager audioManager;
    private bool criaturaActivada;
    public GameObject destino;
    private Rigidbody rb;
    private bool criaturaon;

    private void Start()
    {
        criaturaActivada = false;
        rb = prefabCriatura.GetComponent<Rigidbody>();
        if (rb != null) return;
        {
            rb = prefabCriatura.AddComponent<Rigidbody>();

            rb.isKinematic = true;
        }
    }
    private void FixedUpdate()
    {
        if (criaturaActivada)
        {

            Vector3 direccionCriatura = (destino.transform.position - prefabCriatura.transform.position).normalized;
            rb.MovePosition(rb.position + direccionCriatura * velocidad * Time.fixedDeltaTime);

            var bichoCreado = prefabCriatura.GetComponent<BichoDetector>();
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

    public void InSight()
    {
        ActivarCriatura();
    }
}
