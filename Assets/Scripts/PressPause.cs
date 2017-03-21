using UnityEngine;
using System.Collections;

public class PressPause : MonoBehaviour {
	public GameObject frog;
	public GameObject pausemenu;

	// Use this for initialization
	void Start () {
	   
		pausemenu.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
			
					checkTouchAndriod();
			
					//checkTouchComputer();
			
	}


	void checkTouchAndriod(){

		if(Input.GetTouch (0).phase == TouchPhase.Ended){
			//Touch touch = Input.GetTouch(i);
			Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast(pos,Vector2.zero);
			if(hit != null && hit.collider != null){
				switch(hit.collider.name){
				case "PauseBtn":
					StartCoroutine(stopFrogFromMoving());
					Time.timeScale = 0.0f;
					pausemenu.SetActive(true);
					break;
				case "ResumeGame":
					Time.timeScale = 1.0f;
					pausemenu.SetActive(false);
					break;
				case "RestartGame":
					Application.LoadLevel("Play");
					Time.timeScale = 1.0f;
					break;
				case "GoHome":
					Application.LoadLevel("MainMenu");
					Time.timeScale = 1.0f;
					break;

				}

			}
		}
	}

	void checkTouchComputer(){

		if (Input.GetMouseButtonUp(0)){
			Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast(pos,Vector2.zero);

			if(hit != null && hit.collider != null){
				switch(hit.collider.name){
				case "PauseBtn":
					StartCoroutine(stopFrogFromMoving());
					Time.timeScale = 0.0f;
					pausemenu.SetActive(true);
					break;
				case "ResumeGame":
					Time.timeScale = 1.0f;
					pausemenu.SetActive(false);
					break;
				case "RestartGame":
					Application.LoadLevel("Play");
					Time.timeScale = 1.0f;
					break;
				case "GoHome":
					Application.LoadLevel("MainMenu");
					Time.timeScale = 1.0f;
					break;
					
				}
				
			}
		}

	}

	IEnumerator stopFrogFromMoving(){
		yield return new WaitForSeconds(0.01f);
		frog.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

	}
}
