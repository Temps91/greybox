using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float timer = 0;
    public float maxTimer;
    public int sigilosEncontrados;
    public GameReset gameReset;


    private void Update()
    {
        Contador();
        //Debug.Log("Tiempo es de: " + timer);
        if (sigilosEncontrados >= 3)
        {
            gameReset.ResetJuego();

        }
    }
    public void Contador()
    {
        timer += Time.deltaTime;
        if (timer >= maxTimer)
        {
            timer = 0;
        }
    }

    public void ReinicioScene()
    {
        SceneManager.LoadScene("greybox");
    }
    

}

