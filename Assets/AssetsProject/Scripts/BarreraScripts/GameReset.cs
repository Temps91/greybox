using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameReset : MonoBehaviour
{
    [Header("Player")]
    public Transform player;
    public Vector3 playerPosInicial;
    public Quaternion playerRotInicial;

    [Header("Objetos que se resetean")]
    public GameObject[] objetosPorReset;
    public int[] resetsNecesarios;

    private int contadorResets = 0;
    public EyeBlink eyeBlink;

    void Start()
    {
        Debug.Log(contadorResets);
        contadorResets = PlayerPrefs.GetInt("Resets", 0);
        ActivarObjetosPorReset();
        StartCoroutine(eyeBlink.Blink());
    }

    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.rKey.wasPressedThisFrame)
            StartCoroutine(ResetJuego());
    }

    public IEnumerator ResetJuego()
    {

        if (eyeBlink != null)
        {
            
            yield return StartCoroutine(eyeBlink.Blink());
        }
        contadorResets++;
        playerPosInicial = player.position;
        playerRotInicial = player.rotation;
        PlayerPrefs.SetInt("Resets", contadorResets);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void ActivarObjetosPorReset()
    {
        if (objetosPorReset.Length != resetsNecesarios.Length)
        {
            return;
        }

        for (int i = 0; i < objetosPorReset.Length; i++)
        {
            if (objetosPorReset[i] != null)
            {
                objetosPorReset[i].SetActive(contadorResets >= resetsNecesarios[i]);

            }
        }
    }

    [ContextMenu("Reset All Resets")]
    public void ResetAllResets()
    {
        PlayerPrefs.DeleteKey("Resets");
        contadorResets = 0;
    }
}
