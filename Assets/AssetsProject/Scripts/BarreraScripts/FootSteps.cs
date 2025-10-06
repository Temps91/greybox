using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(AudioSource))]
public class Footsteps : MonoBehaviour
{
    [SerializeField] private AudioClip[] pasos;
    [SerializeField] private float tiempoEntrePasos = 0.5f;
    [SerializeField] private float velocidadUmbral = 0.1f;

    private CharacterController controller;
    private AudioSource audioSource;
    private float tiempoRestante;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        audioSource = GetComponent<AudioSource>();

        audioSource.playOnAwake = false;
    }

    private void Update()
    {
        float velocidad = controller.velocity.magnitude;
        Debug.Log("Velocidad actual: " + velocidad);

        if (velocidad > velocidadUmbral && pasos.Length > 0)
        {
            tiempoRestante -= Time.deltaTime;
            Debug.Log("Jugador en movimiento, tiempo restante: " + tiempoRestante);

            if (tiempoRestante <= 0f)
            {
                int index = Random.Range(0, pasos.Length);
                audioSource.PlayOneShot(pasos[index]);
                Debug.Log("Reproduciendo paso: " + pasos[index].name);

                tiempoRestante = tiempoEntrePasos;
            }
        }
    }
}