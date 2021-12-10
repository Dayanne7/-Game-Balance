using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    public Sprite[] cubes;
    private int index = 0;
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        StartCoroutine(changingSprites());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator changingSprites(){
        while(true){
            yield return new WaitForSeconds(0.2f);
            index+=1;
            sr.sprite = cubes[index];

            if(index==4){
                index = 0;
            }
            
        }

    }
}
