using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

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

    void Start()
    {
        contadorResets = PlayerPrefs.GetInt("Resets", 0);
        ActivarObjetosPorReset();
    }

    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.rKey.wasPressedThisFrame)
            ResetJuego();
    }

    public void ResetJuego()
    {
        contadorResets++;
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
