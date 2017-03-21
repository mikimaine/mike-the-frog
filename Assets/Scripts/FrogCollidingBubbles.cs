using UnityEngine;
using System.Collections;


public class FrogCollidingBubbles : MonoBehaviour {
	public GUIText playerScore;
	private int blueBubbleValue = 1;
	private int redBubbleValue = 2;
	private int blackBubbleValue = -3;
	private int scoreCounter = 0;

	public AudioClip blueBubblePoppingSound;
	public AudioClip redBubblePoppingSound;
	public AudioClip blackBubblePoppingSound;
	public AudioClip greenBubblePoppingSound;

	private int highestScore;
	private int highestScoreOld;

	void Start(){
		if(PlayerPrefs.HasKey("highestScore")){
			highestScore = PlayerPrefs.GetInt("highestScore");
			highestScoreOld = highestScore;
		}else{
			highestScore = 0;
			highestScoreOld = highestScore;

		}
	}

	void OnTriggerEnter2D(Collider2D coll){

		switch (coll.gameObject.tag){
		case "BlueBubbleTag":
			Destroy (coll.gameObject);
			GetComponent<AudioSource>().PlayOneShot(blueBubblePoppingSound);
			scoreCounter += blueBubbleValue;
			playerScore.text = "" + scoreCounter;
			break;
		case "RedBubbleTag":
			Destroy (coll.gameObject);			
			GetComponent<AudioSource>().PlayOneShot(redBubblePoppingSound);
			scoreCounter += redBubbleValue;
			playerScore.text = "" + scoreCounter;
			break;
		case "BlackBubbleTag":
			Destroy (coll.gameObject);
			GetComponent<AudioSource>().PlayOneShot(blackBubblePoppingSound);
			scoreCounter += blackBubbleValue;
			if(scoreCounter < 0)
				gameOver(scoreCounter);
			playerScore.text = "" + scoreCounter;
			break;
		case "GreenBubbleTag":
			Destroy (coll.gameObject);
			GetComponent<AudioSource>().PlayOneShot(greenBubblePoppingSound);
			gameOver(scoreCounter);
			break;
		case "FloorgrassTag":
			//Destroy (coll.gameObject);
			GetComponent<AudioSource>().PlayOneShot(greenBubblePoppingSound);
			gameOver(scoreCounter);
			break;
		}
	}

	void gameOver(int score){
		//Debug.Log("GAME OVER!!! Your Score: " + score);
		Application.LoadLevel("GameOverMenu");
		if(score > highestScore){
			highestScore = score;
		}
		PlayerPrefs.SetInt("currentScore",score); 
		PlayerPrefs.SetInt("highestScore",highestScore);
		PlayerPrefs.SetInt("highestScoreOld",highestScoreOld);
	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
