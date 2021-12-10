using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelUp : MonoBehaviour
{
    private GameController gameController ;
    private CubeGenerator cubeGenerator;


    public void pauseGame()
    {
        Time.timeScale = 0;
    }

    public void PlayGame()
    {
        gameController = FindObjectOfType(typeof(GameController)) as GameController;
        cubeGenerator = FindObjectOfType(typeof(CubeGenerator)) as CubeGenerator;

        gameController.pausedGame = false;
        cubeGenerator.cubeDone();

        Time.timeScale = 1;
    }
}
