using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip caida;

    public void CaidaSound(Vector3 posicion)
    {
        AudioSource.PlayClipAtPoint(caida, posicion);
    }
}
