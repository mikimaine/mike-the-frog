using UnityEngine;
using System.Collections;

public class MainmenuButtonPressed : MonoBehaviour {

	// Use this for initialization
	void Start () {
	  
	}
	
	// Update is called once per frame
	void Update () {
		//only for testing

		AndriodCheck();
    
		//EditorCheck();

	}

	void AndriodCheck(){

		if(Input.GetTouch (0).phase == TouchPhase.Ended){
			Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast(pos,Vector2.zero);
			if(hit != null && hit.collider != null){
				switch(hit.collider.name){
				case "Play":
					Application.LoadLevel("Play");
					break;
				case "Thanks":
					Application.LoadLevel("ThanksMenu");
					break;
				case "Exit":
					Application.Quit();
					break;
				case "HowToPlay":
					Application.LoadLevel("HowToPlayMenu");
					break;
				}
			}
		}
	}

	void EditorCheck(){

		if(Input.GetMouseButtonUp(0)){
			Vector3 pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast(pos,Vector2.zero);
			if(hit != null && hit.collider != null){
				switch(hit.collider.name){
				case "Play":
					Application.LoadLevel("Play");
					break;
				case "Thanks":
					Application.LoadLevel("ThanksMenu");
					break;
				case "Exit":
					Application.Quit();
					break;
				case "HowToPlay":
					Application.LoadLevel("HowToPlayMenu");
					break;
				}
			}

		}

	}
}
