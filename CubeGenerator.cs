using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenerator : MonoBehaviour
{
    public GameObject[] cubePrefabs;
    private Vector3 cubeSize;
    private Vector3 upperRightCorner;
    public bool gameOver = false;
    private bool nextCubeAvailable = true;
    private List<GameObject> cubesOnAir;
    public GameObject gameArea;
    private bool specialCubeGo = false;

    // Start is called before the first frame update
    void Start()
    {
        
        cubeSize = cubePrefabs[0].GetComponent<SpriteRenderer>().bounds.size;
        upperRightCorner = gameArea.transform.position;

        cubesOnAir = new List<GameObject>();
        StartCoroutine(specialCubeRoutine());

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //checkIfCubeAvailable();

        if (!gameOver){
            if(nextCubeAvailable){
                nextCubeAvailable = false;

                cubesOnAir.Add(SpawnCube());
            }
        }


    }

    GameObject SpawnCube() {
        Quaternion spawnRotation = Quaternion.identity;
        Vector3 spawnPosition = new Vector3(
            Random.Range(-4+cubeSize.x, 4+ cubeSize.x), 3.4f
        );

        var index = Random.Range(0,5);

        if(cubesOnAir.Count>10 && specialCubeGo){
            index = 5;
            specialCubeGo = false;
        }
        


        GameObject spawnedCube = Instantiate(cubePrefabs[index], spawnPosition, spawnRotation);

        return spawnedCube;
    }

    public void cubeDone(){
        //cubeGenerator.cubesOnAir.Remove(cube);
        

        // Debug.Log("entrou no cube done");
        nextCubeAvailable = true;

    }

    public void clearCubes(){
        for(int i=0; i<cubesOnAir.Count; i++){
            if(cubesOnAir[i]!=null){
                Destroy(cubesOnAir[i]);
            }
        }

        cubesOnAir = new List<GameObject>();
    }

    IEnumerator specialCubeRoutine(){
        while(true){
            yield return new WaitForSeconds(10);
            specialCubeGo = true;
        }
        
    }

}
