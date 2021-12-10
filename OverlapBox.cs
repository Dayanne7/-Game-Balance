using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlapBox : MonoBehaviour
{
    private CubeGenerator cubeGenerator;
    private GameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        cubeGenerator = FindObjectOfType(typeof(CubeGenerator)) as CubeGenerator;
        gameController = FindObjectOfType(typeof(GameController)) as GameController;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
