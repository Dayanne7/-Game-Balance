using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{
    public bool sonzinho = true;
    public string nomeDaCena;
    
    public void playdoJogo()
    {
        SceneManager.LoadScene(nomeDaCena);
    }
    
    public void comoJogaroJogo()
    {
        SceneManager.LoadScene(nomeDaCena);

    }
    
    public void som()
    {
        if (sonzinho)
        {
            AudioListener.pause = true;
            sonzinho = false;
        }
        else
        {
            AudioListener.pause = false;
            sonzinho = true;
        }
        
    }

    public void voltarPMenu()
    {
        SceneManager.LoadScene(nomeDaCena);

    }

}
