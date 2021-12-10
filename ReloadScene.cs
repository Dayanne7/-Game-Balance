using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ReloadScene : MonoBehaviour
{
    private GameController gameController ;
    private CubeGenerator cubeGenerator;


    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType(typeof(GameController)) as GameController;
        cubeGenerator = FindObjectOfType(typeof(CubeGenerator)) as CubeGenerator;


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadScene(){
        Scene scene = SceneManager.GetActiveScene();
        Time.timeScale = 1f;
        SceneManager.LoadScene(scene.name);
        cubeGenerator.gameOver = false;

    }
}
