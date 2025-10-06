using UnityEngine;

public class Criature : MonoBehaviour
{
    public GameObject prefabCreature; // Prefab a instanciar
    public GameObject player;         // Jugador
    public float velocidad = 10f;

    private GameObject instanciaPrefab;
    private Rigidbody rb;

    public void ActivarMovimiento()
    {
        // Instanciar el prefab si aún no existe
        if (instanciaPrefab == null)
        {
            instanciaPrefab = Instantiate(prefabCreature, transform.position, transform.rotation);

            // Asegurarse que tenga Rigidbody
            rb = instanciaPrefab.GetComponent<Rigidbody>();
            if (rb == null)
            {
                rb = instanciaPrefab.AddComponent<Rigidbody>();
            }
        }

        // Apuntar al jugador
        instanciaPrefab.transform.LookAt(player.transform);

        // Aplicar fuerza
        Vector3 direccion = instanciaPrefab.transform.forward;
        rb.velocity = Vector3.zero; // reset de velocidad
        rb.angularVelocity = Vector3.zero;
        rb.AddForce(direccion * velocidad, ForceMode.Impulse);
    }
}
