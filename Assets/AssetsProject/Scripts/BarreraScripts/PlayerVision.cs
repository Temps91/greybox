using UnityEngine;

public class PlayerVision : MonoBehaviour
{
    public float rayDistance = 10f;
    public LayerMask layer;
    public GameManager gameManager;

    private void Update()
    {
        float probabilidad = gameManager.timer;
        Vector3 origin = transform.position;
        Vector3 direction = transform.forward;
        RaycastHit hit;
        if (probabilidad >= 4.5f && probabilidad <= 5)
        {
            if (Physics.Raycast(origin, direction, out hit, rayDistance, layer))
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

}
