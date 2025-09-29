using UnityEngine;

public class Lanzar : MonoBehaviour
{
    public GameObject[] objetos;
    public float fuerza;
    public GameObject jugador;
    public AudioClip sonidoCaida;
    private GameObject objetoSeleccionado;
    


    private void Start()
    {

    }
    public void OnTriggerEnter(Collider other)
    {
        if ( other.gameObject == jugador)
        {
            Debug.Log("Objeto ya lanzado");
            int randomIndex = Random.Range(0, objetos.Length);
            objetoSeleccionado = objetos[randomIndex];
            Rigidbody rb = objetoSeleccionado.GetComponent<Rigidbody>();
            objetoSeleccionado.transform.LookAt(jugador.transform);
            Vector3 direction = objetoSeleccionado.transform.forward;
            rb.AddForce(direction * fuerza);
            objetoSeleccionado.GetComponent<Rigidbody>().isKinematic = false;
            objetoSeleccionado.GetComponent <Rigidbody>().useGravity = true;


            
        }

        if (other.gameObject == objetoSeleccionado)
        {
            AudioSource.PlayClipAtPoint(sonidoCaida, objetoSeleccionado.transform.position);
        }

        
    }

}
