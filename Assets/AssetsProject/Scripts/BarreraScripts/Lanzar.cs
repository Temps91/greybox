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
        float probabiliad = gameManager.timer;
        if (probabiliad >= 3 && probabiliad <= 4)
        {
            if (other.gameObject == jugador)
            {
                Debug.Log("Objeto ya lanzado");
                int randomIndex = Random.Range(0, objetos.Length);
                objetoSeleccionado = objetos[randomIndex];
                Rigidbody rb = objetoSeleccionado.GetComponent<Rigidbody>();
                objetoSeleccionado.transform.LookAt(jugador.transform);
                Vector3 direction = objetoSeleccionado.transform.forward;
                rb.AddForce(direction * fuerza, ForceMode.Acceleration);
                objetoSeleccionado.GetComponent<Rigidbody>().isKinematic = false;
                objetoSeleccionado.GetComponent<Rigidbody>().useGravity = true;

                var detector = objetoSeleccionado.GetComponent<DeteccionCaida>();
                if (detector != null)
                {
                    detector.audioManagerDeteccionCaida = audioManager;
                }


            }
        }

    }



}
