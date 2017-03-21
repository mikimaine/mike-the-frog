using UnityEngine;
using System.Collections;

public class ThanksButtonPressed : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		AndriodCheck();

		//EditorCheck();

	}

	void AndriodCheck(){
		
		if(Input.GetTouch (0).phase == TouchPhase.Ended){
			Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast(pos,Vector2.zero);
			if(hit != null && hit.collider != null){
				switch(hit.collider.name){
				case "MainMenu":
					Application.LoadLevel("MainMenu");
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
				case "MainMenu":
					Application.LoadLevel("MainMenu");
					break;
			
				}
			}
			
		}
		
	}
}
