using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    private int score = 0;
    private float scoreAux = 0;
    private int highScore;
    //public Canvas gameOverCanvas;
    //public Text gameOverText;
    //public Text newHighScoreText;
    public Text mainScoreText;

    public int lives = 5;
    public GameObject livesObject;
    public Sprite[] livesSprites;
    private SpriteRenderer livesRenderer;

    public float gravityScale = 0.3f;

    public int currentLevel = 1;
    public Text levelText;
    public GameObject levelUpCanvas;
    private levelUp levelUpScript;
    public bool pausedGame = false;

    // Start is called before the first frame update
    void Start()
    {
        levelUpScript = FindObjectOfType(typeof(levelUp)) as levelUp;

        livesRenderer = livesObject.GetComponent<SpriteRenderer>();
        if (PlayerPrefs.HasKey("highscore")) {
            highScore = PlayerPrefs.GetInt("highscore");
        } else {
            highScore = 0;
        }

        //StartCoroutine(IncreaseGravity());

    }
    // Update is called once per frame
    void Update()
    {
        if(lives==0){
            GameOver();
        }

        if(!pausedGame){
             scoreAux += Time.deltaTime * 10;
            score = (int) scoreAux; 
            mainScoreText.text = score.ToString("D8");
        }
       

    }
    private void UpdateHighScore() {
        highScore = score;
        PlayerPrefs.SetInt("highscore", score);
    }
    public void GameOver() {
        //Time.timeScale = 0f;

        PlayerPrefs.SetInt("score", score);
        //gameOverText.text = "" + score;
        // gameOverCanvas.gameObject.SetActive(true);

        if (score > highScore) {
            UpdateHighScore();
            //newHighScoreText.gameObject.SetActive(true);
        }

        SceneManager.LoadScene("GameOver");


    }
    
    public void levelUp(){
        currentLevel = currentLevel +  1;
        levelText.text = "" + currentLevel;
        levelUpCanvas.SetActive(true);
        IncreaseGravity();
        pausedGame = true;
        levelUpScript.pauseGame();

    }

    public void updateLivesSprite(){
        livesRenderer.sprite = livesSprites[lives-1];

    }

    private void IncreaseGravity(){
        gravityScale += 0.1f;

    }

    // IEnumerator IncreaseGravity(){
    //     yield return new WaitForSeconds(10);
    //     gravityScale += 0.05f;

    // }
}
