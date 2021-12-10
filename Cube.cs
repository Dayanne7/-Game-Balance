using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioSource audioSource2;


    private CubeGenerator cubeGenerator;
    private GameController gameController ;
    private movimentarPeca script; 
    public bool firstTime = true;
    public Sprite[] explosions;
    private Rigidbody2D rb;
    private SpriteRenderer render;


    // Start is called before the first frame update
    void Start()
    {
        cubeGenerator = FindObjectOfType(typeof(CubeGenerator)) as CubeGenerator;
        gameController = FindObjectOfType(typeof(GameController)) as GameController;
        render = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = gameController.gravityScale;
    }

    void FixedUpdate(){
        checkOverlap();
    }

    void checkOverlap(){
        Collider2D[] hitColliders = Physics2D.OverlapBoxAll(gameObject.transform.position, transform.localScale*14, 0f);
        int i = 0;
        Debug.Log("Hit : " + hitColliders.Length);

        //Check when there is a new collider coming into contact with the box
        while (i < hitColliders.Length)
        {
            //Output all of the collider names
            Debug.Log("Hit : " + hitColliders[i].name + i);
            if(!firstTime && hitColliders[i].gameObject.tag == "threshold"){
                cubeGenerator.clearCubes();
                gameController.levelUp();
                i = hitColliders.Length;
            }
            //Increase the number of Colliders in the array
            i++;
        }


    }
  
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Check that it is being run in Play Mode, so it doesn't try to draw this in Editor mode
        
            //Draw a cube where the OverlapBox is (positioned where your GameObject is as well as a size)
            Gizmos.DrawWireCube(transform.position, transform.localScale*14);
    }

    void OnTriggerEnter2D(Collider2D other){
        Debug.Log("entrou em trig");
        if(!firstTime){
            Debug.Log("entrouuu");

            cubeGenerator.clearCubes();
            gameController.levelUp();
        }
        
    }
    
    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag!="wall"){

            if(other.gameObject.tag != "threshold" && firstTime){
                cubeGenerator.cubeDone(); 
                script = GetComponent<movimentarPeca>();
                script.enabled = false;
                firstTime = false;

                   
            }

            if(other.gameObject.tag=="threshold" && !firstTime){
            //    cubeGenerator.clearCubes();
            //    gameController.levelUp();

            }else if(other.gameObject.tag=="special"){
                audioSource2.Play();
                Destroy(other.gameObject);
                Destroy(gameObject);

            }else if(other.gameObject.tag=="floor"){
                audioSource.Play();
                gameController.lives -=1;
                if(gameController.lives>0){
                    gameController.updateLivesSprite();

                }
                StartCoroutine(ExplosionAnimation());
            }
        }
    }
            
    



    IEnumerator ExplosionAnimation(){
        gameObject.transform.localScale = new Vector3(0.1f,0.1f,0.1f);

        for (int i=0; i<explosions.Length; i++){
            render.sprite = explosions [i];
            yield return new WaitForSeconds(0.01f);

        }

        Destroy(gameObject);

    }
}
