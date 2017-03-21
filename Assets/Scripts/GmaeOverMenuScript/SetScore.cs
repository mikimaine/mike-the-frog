using UnityEngine;
using System.Collections;

public class SetScore : MonoBehaviour {
	public GameObject gameOverPage;
	public GameObject newRecordText;
	public GUIText thisScoreObj;
	public GUIText thisHighScoreObj;
	// Use this for initialization
	void Start () {
	
		int score = PlayerPrefs.GetInt("currentScore");
		int highScoreOld = PlayerPrefs.GetInt("highestScoreOld");

		newRecordText.SetActive(false);

		if(score >highScoreOld){
			newRecordText.SetActive(true);
		}

		thisScoreObj.text = "" + score;
		thisHighScoreObj.text = ""+highScoreOld;
		gameOverPage.SetActive(true);
		AdjustFontSize();
		 
	}

	void AdjustFontSize(){
		if(Screen.height > 480 && Screen.width > 800){
			thisScoreObj.fontSize = 60;
			thisHighScoreObj.fontSize = 60;

		}else if(Screen.height <= 480 && Screen.width <= 800){
			thisScoreObj.fontSize = 40;
			thisHighScoreObj.fontSize = 40;
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
