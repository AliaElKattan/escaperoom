using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeLockSolution : MonoBehaviour {
    public int[,] solutionArr;
    public int puzzleWidth = 4;
    public int puzzleHeight = 4;
    public int[,] pathSolution; //coordinates
    public float blockHeight = 0.25f;
    public float blockWidth = 0.25f;
    public GameObject[,] physicalMazeKey, physicalMazeSolution;
    public GameObject individualBlock;
    public Material defaultMaterial;

    public Material left;
    public Material right;
    public Material up;
    public Material down;
    public Material goalMaterial;
    // Use this for initialization
    void Start () {
        physicalMazeKey = new GameObject[puzzleHeight, puzzleWidth];
        physicalMazeSolution = new GameObject[puzzleHeight, puzzleWidth];
        for (int i = 0; i < puzzleHeight; i++)
        {
            for (int j = 0; j < puzzleWidth; j++)
            {

                //create the actual object of blocks.
                physicalMazeKey[i, j] = Instantiate(individualBlock, new Vector3(j * blockWidth, i * blockHeight, 5), Quaternion.identity);


                physicalMazeSolution[i, j] = Instantiate(individualBlock, new Vector3(j * blockWidth, i * blockHeight, 0), Quaternion.identity);
                physicalMazeSolution[i, j].GetComponent<MeshRenderer>().material = defaultMaterial;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
