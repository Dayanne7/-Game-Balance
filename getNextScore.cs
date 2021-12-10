using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class getNextScore : MonoBehaviour
{
    private GameController gameController ;
    public Text nextScoreText;

    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType(typeof(GameController)) as GameController;

    }

    // Update is called once per frame
    void Update()
    {
        var nextLevel = gameController.currentLevel + 1;
        nextScoreText.text = "" + nextLevel;
    }
}
