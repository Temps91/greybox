using UnityEngine;

public class Lanzar : MonoBehaviour
{
    public GameObject[] objetos;
    public float fuerza;
    public GameObject jugador;
    [HideInInspector]public GameObject objetoSeleccionado;
    public AudioManager audioManager;
    public GameManager gameManager;


    public void OnTriggerEnter(Collider other)
    {
            if (other.gameObject == jugador)
            {
                Debug.Log("Objeto ya lanzado");
                int randomIndex = Random.Range(0, objetos.Length);
                objetoSeleccionado = objetos[randomIndex];
                Rigidbody rb = objetoSeleccionado.GetComponent<Rigidbody>();
                objetoSeleccionado.transform.LookAt(jugador.transform);
            objetoSeleccionado.GetComponent<Rigidbody>().isKinematic = false;
            Vector3 direction = objetoSeleccionado.transform.forward;
                rb.AddForce(direction * fuerza, ForceMode.Impulse);

                objetoSeleccionado.GetComponent<Rigidbody>().useGravity = true;

                var detector = objetoSeleccionado.GetComponent<DeteccionCaida>();
                if (detector != null)
                {
                    detector.audioManagerDeteccionCaida = audioManager;
                }


            }


    }



}
