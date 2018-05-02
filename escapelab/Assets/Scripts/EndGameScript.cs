using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameScript : MonoBehaviour {
	public float fadeSpeed = 0.5F;
	public bool endThisGame = false;
	// canvas overlay component
	RawImage canvasOverlay;
	public int solvedPuzzleCount = 0;

	// Use this for initialization
	void Start () {
		
		//canvasOverlay = GameObject.Find("Overlay").GetComponent<RawImage>();

	}
	
	// Update is cadlled once per frame
	void Update () {

	
		if(solvedPuzzleCount >=3){
			endThisGame=true;
		}



		if (endThisGame) {
			Debug.Log ("game ending");
			SceneManager.LoadScene ("end");
			//StartCoroutine( Fade (0F, 1, fadeSpeed) );
			Debug.Log ("fading");
		}
		
	}

	/*

	IEnumerator Fade(float alpha, int direction, float speed)
	{
		//		float finalAlpha = 1 + direction;
		bool fadeTransition = true;

		while (fadeTransition = true)
		{
			alpha += direction * speed * Time.deltaTime;
			alpha = Mathf.Clamp01(alpha);
			//			Debug.Log (alpha);
			canvasOverlay.color = new Color(0F, 0F, 0F, alpha);

			if (direction > 0 && alpha >= 1)
			{
				fadeTransition = false;
			}
			else if (direction < 0 && alpha <= 0)
			{
				fadeTransition = false;
			}

			yield return null;

		}




	}
*/
}
