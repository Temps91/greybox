using UnityEngine;

public class PlayerVision : MonoBehaviour
{
    public float rayDistance = 10f;
    public LayerMask layer;

    private void Update()
    {
        Vector3 origin = transform.position;
        Vector3 direction = transform.forward;
        RaycastHit hit;
        if (Physics.Raycast(origin, direction, out hit, rayDistance, layer))
        {
            Criature criatura = hit.collider.GetComponent<Criature>();
            if (criatura != null)
            {
                criatura.ActivarCriatura(); 
            }
        }
        Debug.DrawLine(origin, direction, Color.red);
    }

}
