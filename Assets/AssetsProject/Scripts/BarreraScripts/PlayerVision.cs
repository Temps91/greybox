using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerVision : MonoBehaviour
{
    public float rayDistance = 10f;
    public LayerMask layer;
    public GameReset gameReset;
   
    public GameManager gameManager;
    public float vida = 10f;
    public float vidaMaxima = 10f;
    public float tiempoRegeneracion = 0f;
    public float tiempoRegenerar = 10f;

    private void Update()
    {
        float probabilidad = gameManager.timer;
        Vector3 origin = transform.position;
        Vector3 direction = transform.forward;
        RaycastHit hit;

        if (Physics.Raycast(origin, direction, out hit, rayDistance, layer))
        {
            int layerGolpeado = hit.collider.gameObject.layer;
            string nombreLayer = LayerMask.LayerToName(layerGolpeado);
            if (nombreLayer == "Enemie" && probabilidad >= 4.5f && probabilidad <= 5)
            {


            }
            if (nombreLayer == "Sight")
            {
                if (hit.collider.TryGetComponent<IVisible>(out var visibleObject))
                {
                    visibleObject.InSight();

                }
            }
        }
        if (vida < vidaMaxima)
        {
            tiempoRegeneracion += Time.deltaTime;

            if (tiempoRegeneracion >= tiempoRegenerar)
            {
                vida += 1;
                if (vida > vidaMaxima)
                {
                    vida = vidaMaxima;
                    tiempoRegeneracion = 0f;
                }
            }
        }
        else
        {
            tiempoRegeneracion = 0f;
        }

        

        
        Debug.DrawLine(origin, direction, Color.red);
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Enemigo"))
        {
            QuitarVida();
        }
    }

    private void QuitarVida()
    {
        vida--;
        Debug.Log("Golpe recibido. Vida restante: " + vida);

        if (vida <= 0)
        {
            gameReset.ResetJuego();

        }
    }

}



public interface IVisible
{
    void InSight();
}
