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
    public AudioClip[] enterRitual;
    public AudioClip[] wOL;
    public AudioClip[] readBook;
    public AudioClip[] enterHouse;

    private AudioSource ambienteSource;
    private AudioSource dialogoSource;
    private AudioSource audioBook;

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
            Debug.Log("Reproduciendo Sonido");
        }
    }
    public void PlayEnterRitual(Vector3 posicion)
    {
        if (enterRitual.Length > 0)
        {
            AudioClip clip = enterRitual[Random.Range(0, enterRitual.Length)];
            AudioSource.PlayClipAtPoint(clip, posicion);
            Debug.Log("Reproduciendo Sonido");
        }
    }

    public void PlayWOL(Vector3 posicion)
    {
        if (wOL.Length > 0)
        {
            AudioClip clip = wOL[Random.Range(0, wOL.Length)];
            AudioSource.PlayClipAtPoint(clip, posicion);
            Debug.Log("Reproduciendo Sonido");
        }
    }

    public void PlayEnterHouse(Vector3 posicion)
    {
        if (enterHouse.Length > 0)
        {
            AudioClip clip = enterHouse[Random.Range(0, enterHouse.Length)];
            AudioSource.PlayClipAtPoint(clip, posicion);
            Debug.Log("Reproduciendo Sonido");
        }
    }

    public void PlayReadBook(Vector3 posicion)
    {
        if (readBook.Length > 0)
        {
            AudioClip clip = readBook[Random.Range(0, readBook.Length)];
            audioBook.PlayOneShot(clip);
            Debug.Log("Reproduciendo Sonido");
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