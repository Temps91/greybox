using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float timer = 0;
    public float maxTimer;


    private void Update()
    {
        Contador();
    }
    public void Contador()
    {
        timer += Time.deltaTime;
        if (timer >= maxTimer)
        {
            timer = 0;
        }
    }

}

