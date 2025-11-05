using UnityEngine;
using UnityEngine.UI;

public class Book : MonoBehaviour
{
    [Header("Páginas del libro")]
    public Image paginaIzquierdaImage;
    public Image paginaDerechaImage;

    [Header("Sprites de las páginas")]
    public Sprite[] paginasIzquierda;
    public Sprite[] paginasDerecha;

    [Header("Animaciones de paso de página")]
    public Animator animadorSiguiente; 
    public Animator animadorRegresar;  
    public string triggerSiguiente = "PasarPagina";
    public string triggerRegresar = "RegresarPagina";

    private int indicePagina = 0;
    private bool animando = false;

    void Start()
    {
        ActualizarPaginas();
    }

    public void SiguientePagina()
    {
        if (animando || indicePagina >= paginasIzquierda.Length - 1)
            return;

        StartCoroutine(PasarPagina(true));
    }

    public void PaginaAnterior()
    {
        if (animando || indicePagina <= 0)
            return;

        StartCoroutine(PasarPagina(false));
    }

    private System.Collections.IEnumerator PasarPagina(bool siguiente)
    {
        animando = true;

        Animator animador = siguiente ? animadorSiguiente : animadorRegresar;
        string trigger = siguiente ? triggerSiguiente : triggerRegresar;

        // ✅ Verificar que exista el animator antes de usarlo
        if (animador != null)
        {
            animador.gameObject.SetActive(true);
            animador.SetTrigger(trigger);
            yield return new WaitForSeconds(0.5f);
        }

        // Cambiar página
        indicePagina += siguiente ? 1 : -1;
        ActualizarPaginas();

        if (animador != null)
        {
            yield return new WaitForSeconds(0.5f);
            animador.gameObject.SetActive(false);
        }

        animando = false;
    }

    private void ActualizarPaginas()
    {
        if (paginasIzquierda.Length > 0 && indicePagina < paginasIzquierda.Length)
            paginaIzquierdaImage.sprite = paginasIzquierda[indicePagina];

        if (paginasDerecha.Length > 0 && indicePagina < paginasDerecha.Length)
            paginaDerechaImage.sprite = paginasDerecha[indicePagina];
    }
}
