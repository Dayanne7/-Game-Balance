using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialCube : MonoBehaviour
{
    public AudioSource audioSource;

    private CubeGenerator cubeGenerator;
    private movimentarPeca script; 

    private bool firstTime = true;



    // Start is called before the first frame update
    void Start()
    {
        cubeGenerator = FindObjectOfType(typeof(CubeGenerator)) as CubeGenerator;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        // if(other.gameObject.tag!="wall"){
        // cubeGenerator.cubeDone(gameObject); 


        // if(other.gameObject.tag=="block"){
        //     // script = GetComponent<movimentarPeca>();
        //     // script.enabled = false;

        //     Destroy(other.gameObject);
            
        // }

        //  Destroy(gameObject);
        // }
            
    }

    void OnCollisionEnter2D(Collision2D other){
        
        if(other!= null){
            if(other.gameObject.tag!="wall" && other.gameObject.tag!="threshold" ){

                if(firstTime){
                    script = GetComponent<movimentarPeca>();
                    script.enabled = false;                
                    cubeGenerator.cubeDone(); 

                    firstTime = false;
                }
                

                if(other.gameObject.tag=="floor"){
                    audioSource.Play();
                    Destroy(gameObject);

                }     
            }
        }
       
           
    }
}
