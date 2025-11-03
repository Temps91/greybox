using UnityEngine;

public class Sigilos : MonoBehaviour, IVisible
{
    
    public GameManager gameManager;
    public void InSight(){
        if (gameManager != null){
        gameManager.sigilosEncontrados += 1;

        gameObject.SetActive(false);

        Debug.Log("Me desaparezco soy un sigilo");
        
        }
        else if (gameManager == null){
            return;
        }

    }
}
