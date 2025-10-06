using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class VerRaycast : MonoBehaviour
{
    [Header("Configuración del rayo")]
    public float distanceRay = 10f;         // Longitud del rayo
    public LayerMask layerToHit;            // Capas que puede golpear
    public GameObject hitMarkerPrefab;      // Prefab de esfera para marcar impacto

    private LineRenderer lineRenderer;
    private GameObject hitMarker;

    void Awake()
    {
        // Configurar LineRenderer
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.startWidth = 0.02f;
        lineRenderer.endWidth = 0.02f;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = Color.red;
        lineRenderer.endColor = Color.red;

        // Crear marcador de impacto
        if (hitMarkerPrefab != null)
        {
            hitMarker = Instantiate(hitMarkerPrefab);
            hitMarker.SetActive(false);
        }
    }

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        Vector3 endPosition = ray.origin + ray.direction * distanceRay;

        if (Physics.Raycast(ray, out hit, distanceRay, layerToHit))
        {
            endPosition = hit.point;
            Debug.Log("Golpeó: " + hit.collider.name);

            if (hitMarker != null)
            {
                hitMarker.SetActive(true);
                hitMarker.transform.position = hit.point;
            }
        }
        else
        {
            if (hitMarker != null)
                hitMarker.SetActive(false);
        }

        // Actualizar LineRenderer
        lineRenderer.SetPosition(0, ray.origin);
        lineRenderer.SetPosition(1, endPosition);
    }
}
