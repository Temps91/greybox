using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerVision : MonoBehaviour
{
    public float rayDistance = 10f;
    public LayerMask layer;
    public GameManager gameManager;
    public int vida = 3;

    private void Update()
    {
        float probabilidad = gameManager.timer;
        Vector3 origin = transform.position;
        Vector3 direction = transform.forward;
        RaycastHit hit;

        if (Physics.Raycast(origin, direction, out hit, rayDistance, layer))
        {
            if (probabilidad >= 4.5f && probabilidad <= 5)
            {
                Criature criatura = hit.collider.GetComponent<Criature>();
                if (criatura != null)
                {
                    criatura.ActivarCriatura();

                }
            }
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
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

}
