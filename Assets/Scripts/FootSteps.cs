using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Footsteps : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] pasos;
    [SerializeField] private float tiempoEntrePasos = 0.5f;
    [SerializeField] private float velocidadUmbral = 0.1f; 

    private CharacterController controller;
    private float tiempoRestante;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {

        float velocidad = controller.velocity.magnitude;

        if (velocidad > velocidadUmbral)
        {
            tiempoRestante -= Time.deltaTime;

            if (tiempoRestante <= 0f)
            {
                int index = Random.Range(0, pasos.Length);
                audioSource.PlayOneShot(pasos[index]);

                
                tiempoRestante = tiempoEntrePasos;
            }
        }
        else
        {
            tiempoRestante = 0f;
        }
    }
}