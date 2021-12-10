using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botaoPausa : MonoBehaviour
{
    public bool flag; //true se for o botao de pause da tela de pause, false se for o pause do jogo
    public Canvas pauseCanvas;

    public void pauseGame()
    {
        if (flag)
        {
            pauseCanvas.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            pauseCanvas.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
