using UnityEngine;

public class SightRayCast : MonoBehaviour
{
    public float rayDistance;
    public LayerMask layer;

    public GameManager gameManager;

    private void Update()

    {
        Vector3 origin = transform.position;
        Vector3 direction = transform.forward;
        RaycastHit hit;
        if (Physics.Raycast(origin, direction, out hit, rayDistance, layer))
        {
            int layerGolpeado = hit.collider.gameObject.layer;
            string nombreLayer = LayerMask.LayerToName(layerGolpeado);

              if (nombreLayer == "Sight" && hit.collider.TryGetComponent<IVisible>(out var visibleObject))
            {
                visibleObject.InSight();
            }
        }

        Debug.DrawRay(origin, direction * rayDistance, Color.blue);
    }
}
