using UnityEngine;

public class PlayerVision : MonoBehaviour
{
    [Header("Raycast")]
    public float rayDistance = 10f;
    public LayerMask layer;

    [Header("Referencias")]
    public GameManager gameManager;

    [Header("Vida")]
    public float vida = 10f;
    public float vidaMaxima = 10f;
    public float tiempoRegeneracion = 0f;
    public float tiempoRegenerar = 10f;

    [Header("Daño UI")]
    public CanvasGroup dañoUI;

    private void Update()
    {
        if (dañoUI != null && dañoUI.alpha > 0)
            dañoUI.alpha -= Time.deltaTime;

        Vector3 origin = transform.position;
        Vector3 direction = transform.forward;
        RaycastHit hit;

        if (Physics.Raycast(origin, direction, out hit, rayDistance, layer))
        {
            int layerGolpeado = hit.collider.gameObject.layer;
            string nombreLayer = LayerMask.LayerToName(layerGolpeado);

            float probabilidad = gameManager != null ? gameManager.timer : 0f;

            if (nombreLayer == "Enemy" && hit.collider.TryGetComponent<Criature>(out var enemy))
            {
                enemy.InSight();
            }

            if (nombreLayer == "Sight" && hit.collider.TryGetComponent<IVisible>(out var visibleObject))
            {
                visibleObject.InSight();
            }
        }

        Debug.DrawRay(origin, direction * rayDistance, Color.red);

        RegenerarVida();
    }

    private void RegenerarVida()
    {
        if (vida < vidaMaxima)
        {
            tiempoRegeneracion += Time.deltaTime;

            if (tiempoRegeneracion >= tiempoRegenerar)
            {
                vida++;
                tiempoRegeneracion = 0f;

                if (vida > vidaMaxima)
                    vida = vidaMaxima;
            }
        }
        else
        {
            tiempoRegeneracion = 0f;
        }
    }

    public void QuitarVida()
    {
        vida--;
        if (dañoUI != null)
            dañoUI.alpha = 1;

        Debug.Log("Golpe recibido. Vida restante: " + vida);

        if (vida <= 0)
        {
            if (TryGetComponent<GameReset>(out var gameReset))
                gameReset.ResetJuego();
        }
    }
}

public interface IVisible
{
    void InSight();
}

