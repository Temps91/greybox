using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip caida;
    public AudioClip bichos;

    public void CaidaSound(Vector3 posicion)
    {
        AudioSource.PlayClipAtPoint(caida, posicion);
    }
    public void BichoSound(Vector3 posicion)
    {
        AudioSource.PlayClipAtPoint(bichos, posicion);
    }
}
