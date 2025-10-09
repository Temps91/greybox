using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance; 

    [Header("Sonidos individuales")]
    public AudioClip caida;
    public AudioClip bichos;

    [Header("Colecciones de sonidos")]
    public AudioClip[] sonidosInofensivos;
    public AudioClip[] sonidosDeSusto;
    public AudioClip[] dialogos;
    public AudioClip[] ambientes;

    private AudioSource ambienteSource; 
    private AudioSource dialogoSource;  

    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
            return;
        }


        ambienteSource = gameObject.AddComponent<AudioSource>();
        ambienteSource.loop = true;

        dialogoSource = gameObject.AddComponent<AudioSource>();
    }

    public void CaidaSound(Vector3 posicion)
    {
        if (caida != null)
            AudioSource.PlayClipAtPoint(caida, posicion);
    }


    public void BichoSound(Vector3 posicion)
    {
        if (bichos != null)
            AudioSource.PlayClipAtPoint(bichos, posicion);
    }


    public void PlayInofensivo(Vector3 posicion)
    {
        if (sonidosInofensivos.Length > 0)
        {
            AudioClip clip = sonidosInofensivos[Random.Range(0, sonidosInofensivos.Length)];
            AudioSource.PlayClipAtPoint(clip, posicion);
        }
    }


    public void PlaySusto(Vector3 posicion)
    {
        if (sonidosDeSusto.Length > 0)
        {
            AudioClip clip = sonidosDeSusto[Random.Range(0, sonidosDeSusto.Length)];
            AudioSource.PlayClipAtPoint(clip, posicion);
        }
    }

    public void PlayDialogo(int index)
    {
        if (dialogos.Length > index && dialogos[index] != null)
        {
            dialogoSource.Stop();
            dialogoSource.clip = dialogos[index];
            dialogoSource.Play();
        }
    }

    public void CambiarAmbiente(int index)
    {
        if (ambientes.Length > index && ambientes[index] != null)
        {
            ambienteSource.clip = ambientes[index];
            ambienteSource.Play();
        }
    }
}