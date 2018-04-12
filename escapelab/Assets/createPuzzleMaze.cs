using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class createPuzzleMaze : MonoBehaviour {
	public int[,] solutionArr;
	public int puzzleWidth = 4;
	public int puzzleHeight = 4;
	public int[,] pathSolution; //coordinates
	public float blockHeight = 0.25f;
	public float blockWidth= 0.25f;
	public GameObject[,] physicalMaze, physicalMazeSolution;
	public GameObject individualBlock;
	public Material defaultMaterial;

	public Material left;
	public Material right;
	public Material up;
	public Material down;
	public Material goalMaterial;


	Stack pathStack;
	System.Random rnd;




	int[,] possibleDirections = new int[4,2] { {-1,0}, {0,-1}, {0,1}, {1,0} };

	// Use this for initialization
	void Start () {

		//this is not inside createNewPuzzle because we don't need to repeat this to create a new maze. 
		//we will only change the material of the maze so that it looks different.
		physicalMaze = new GameObject[puzzleHeight,puzzleWidth];

		for (int i = 0; i < puzzleHeight; i++) {
			for (int j = 0; j < puzzleWidth; j++) {

				//create the actual object of blocks.
				physicalMaze[i,j] = Instantiate(individualBlock, new Vector3(j * blockWidth , i * blockHeight , 0), Quaternion.identity);

                physicalMazeSolution[i, j] = Instantiate(individualBlock, new Vector3(j * blockWidth, i * blockHeight, 0), Quaternion.identity);
                physicalMazeSolution[i, j].GetComponent<MeshRenderer>().material = defaultMaterial;

            }
        }

        //create solution puzzle
       
        createNewPuzzle ();

	}


	
	// Update is called once per frame
	void Update () {
		
	}


	void createNewPuzzle(){

		pathStack = new Stack ();
		rnd = new System.Random();

		createAbstractPuzzle (); //in terms of arrays
		createRandomSolution (); //creating the path that needs to be traversed

        printAbstractMaze(solutionArr);

        print("the path for this was\n");
        for (int i = 0; i < pathSolution.GetLength(0); i++)
        {

            print(pathSolution[i, 0].ToString() + " " + pathSolution[i, 1].ToString());

        }

        createPhysicalPuzzlePath (); //physical implementation, giving materials to blocks

	}

	void createAbstractPuzzle(){

		solutionArr = new int[puzzleHeight, puzzleWidth];
		for (int i = 0; i < puzzleHeight; i++) {
			for (int j = 0; j < puzzleWidth; j++) {

				solutionArr [i,j] = 0;
				
			}
		}
	}



	void createRandomSolution(){
		
		int[] currentPos = new int[] { 0, 0 };
		solutionArr [0, 0] = 1; //1 if the path has been travelled.
		pathStack.Push (currentPos);
		recurseSolution ();

		createSolution (pathStack);
	
	}

	Stack recurseSolution(){

		int[] currentPos = (int[]) pathStack.Peek ();
		Stack possiblePos = findPossiblePos (currentPos);

		//there are no possible paths from here
		if (possiblePos.Count == 0) {

			solutionArr [currentPos [0], currentPos [1]] = 0;
			return possiblePos;
		}

		//shuffle all possible routes
		shufflePositions (possiblePos);

		while (possiblePos.Count != 0) {
			int[] nextPosition = ( int[] ) possiblePos.Pop();

			pathStack.Push (nextPosition);
			solutionArr [nextPosition [0], nextPosition [1]] = 1;

			//solution is found
			if ((nextPosition [0] == puzzleHeight - 1) && (nextPosition [1] == puzzleWidth - 1)) {
			
				return pathStack;
				
			} else {

				Stack solution = recurseSolution ();

				if (solution.Count == 0) {
				
					pathStack.Pop ();
					solutionArr [nextPosition [0], nextPosition [1]] = 0;

				} else {
				
					return solution;
					
				}


			}
		
		}
			
		//the stack is empty because we already popped out everything. we return empty stack as an indicator that this path doesn't work.
		return possiblePos;


	}

	Stack findPossiblePos(int[] currentPos){

		Stack possiblePosition = new Stack();

		for (int i = 0; i < possibleDirections.GetLength(0); i++) {

			int row = currentPos [0] + possibleDirections [i, 0];
			int col = currentPos [1] + possibleDirections [i, 1];

			if ((row >= 0 && row < puzzleHeight) && (col >= 0 && col < puzzleWidth) && (solutionArr [row, col] != 1)) {
				int [] pos = {row,col};
				possiblePosition.Push(pos);
			}

		
		}

		return possiblePosition;

	}

	void shufflePositions(Stack possiblePos){

		List<int[]> tempArray = new List<int[]> ();
		while (possiblePos.Count != 0) {
			tempArray.Add ( (int[])possiblePos.Pop() );
		}

		Shuffle (tempArray);

		for(int i = 0; i < tempArray.Count; i++) {

			(possiblePos).Push (tempArray [i]);
		
		}

	}

	void Shuffle(List<int[]> list)  
	{  
		int n = list.Count;  
		while (n > 1) {  
			n--;
			int k = rnd.Next(n + 1);  
			int[] value = list[k];  
			list[k] = list[n];  
			list[n] = value;  
		}  
	}

	int relativeDirectionOfNextBlockInPath(int indexInSolutionArr){

		//currently only returns the four directions
		//up(0), left(1), right(2), down(3)
		//this limits the types of block materials that can exist, but 
		//that's something we can do later

		int nextRow = pathSolution [indexInSolutionArr + 1, 0];
		int nextCol = pathSolution [indexInSolutionArr + 1, 1];

		int currRow = pathSolution [indexInSolutionArr, 0];
		int currCol = pathSolution [indexInSolutionArr, 1];

		if (nextRow < currRow) {
		//go up
			return 0;
		
		} else if (nextCol < currCol) {
		//go left
			return 1;
		
		} else if (nextCol > currCol) {
		//go right
			return 2;

		} else if (nextRow > currRow) {
		// go down	
			return 3;

		} else {
            print("nothing");
            // this should NOT happen
            return 4;
           
		}


	}

	void createPhysicalPuzzlePath(){

		for (int i = 0; i < puzzleHeight; i++) {
			for (int j = 0; j < puzzleWidth; j++) {

				//reset the material of blocks.
				physicalMaze[i,j].GetComponent<MeshRenderer>().material = defaultMaterial;
			
			}
		}
		

		for (int i = 0; i < pathSolution.GetLength (0) -1; i++) {
            
			int blockType = relativeDirectionOfNextBlockInPath (i);
            
            

            Material correspondingMaterial;
			if (blockType == 0) {
                print("up");

                correspondingMaterial = up;

			} else if (blockType == 1) {
				
				correspondingMaterial = left;
                print("left");

            } else if (blockType == 2) {

				correspondingMaterial = right;
                print("right");
            } else {

				correspondingMaterial = down;
                print("down");
            }
            
			physicalMaze [pathSolution [i-1, 0], pathSolution [i-1, 1]].GetComponent<MeshRenderer> ().material = correspondingMaterial;

		
		}


		//add the material for the final one.
		//physicalMaze[puzzleHeight-1, puzzleWidth-1].GetComponent<MeshRenderer>().material = goalMaterial;

	}


	void createSolution(Stack solutionStack){
		
		int i = solutionStack.Count;
			
		pathSolution = new int[i,2];
		while (solutionStack.Count != 0) {

			i--;
			int[]value  = (int[]) solutionStack.Pop();

			pathSolution [i, 0] = value [0];
			pathSolution [i, 1] = value [1];

		}
			
	}

	void printAbstractMaze(int [,] array){

		for (int i = 0; i < puzzleHeight; i++) {
			for (int j = 0; j < puzzleWidth; j++) {

				print(solutionArr [i,j]);

			}
			print ("\n");

		}


	}

}
