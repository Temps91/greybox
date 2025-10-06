using UnityEngine;

public class PlayerVision : MonoBehaviour
{
    public float distanceRay = 10f;

    public GameObject[] creatures; // mejor nombre plural

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, distanceRay))
        {
            foreach (GameObject c in creatures)
            {
                if (hit.collider.gameObject == c)
                {
                    Debug.Log("Toco " + c.name);

                    Criature criatureScript = c.GetComponent<Criature>();
                    if (criatureScript != null)
                    {
                        criatureScript.ActivarMovimiento();
                    }

                    break; // ya activamos la criatura, salimos del foreach
                }
            }
        }

        // Debug para ver el rayo en Scene
        Debug.DrawRay(transform.position, transform.forward * distanceRay, Color.red);
    }
}
