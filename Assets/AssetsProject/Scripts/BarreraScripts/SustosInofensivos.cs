using UnityEngine;

public class SustosInofensivos : MonoBehaviour
{
    public enum TipoDeSonido
    {
        Inofensivo,
        Susto,
        Dialogo,
        Ambiente
    }

    [Header("Zona de sonido")]
    public TipoDeSonido tipo;
    public GameObject jugador;       
    public Transform puntoDeSonido;  
    public int indexDialogo = 0;     
    private bool activado = false;   

    private void OnTriggerEnter(Collider other)
    {
        if (activado) return;

        if (other.gameObject == jugador)
        {
            activado = true;
            Vector3 posicion = puntoDeSonido != null ? puntoDeSonido.position : transform.position;

            switch (tipo)
            {
                case TipoDeSonido.Inofensivo:
                    AudioManager.Instance.PlayInofensivo(posicion);
                    break;

                case TipoDeSonido.Susto:
                    AudioManager.Instance.PlaySusto(posicion);
                    break;

                case TipoDeSonido.Dialogo:
                    AudioManager.Instance.PlayDialogo(indexDialogo);
                    break;

                case TipoDeSonido.Ambiente:
                    AudioManager.Instance.CambiarAmbiente(indexDialogo);
                    break;
            }
        }
    }

}
