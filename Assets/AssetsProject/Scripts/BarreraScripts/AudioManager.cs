using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Lanzar objeto;
    public AudioClip caida;
    public void OnTriggerEnter(Collider other)
    {
        GameObject objetousado = objeto.objetoSeleccionado;
        objetousado = null;
        if (other.gameObject == objetousado)
        {
            AudioSource.PlayClipAtPoint(caida, objetousado.transform.position);
        }
    }

}
