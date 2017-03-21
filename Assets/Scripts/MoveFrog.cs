using UnityEngine;
using System.Collections;

public class MoveFrog : MonoBehaviour {
	private float lastTouchTime, currentTouchTime;

	public float velocityVal;
	public float torqueVal;
	public float thresholdTime;

	void Awake(){
	
		velocityVal = 8.0f;
		torqueVal = 200.0f;
		thresholdTime = 0.3f;
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		#if UNITY_ANDROID
		moveFrogAndroid();
		#endif

		#if UNITY_EDITOR
		moveFrog();
		#endif
	}

	//For testing in our computer
	void moveFrog(){
		Vector3 currentPos, touchedPos, distanceVec;
		if (Input.GetMouseButtonDown (0)) {
		
			startRotatingFrogAndStopIt();

		}
		else if(Input.GetMouseButtonUp(0)){
			currentPos = Camera.main.WorldToScreenPoint(transform.position);
			touchedPos = Input.mousePosition;
			distanceVec = (touchedPos - currentPos).normalized;
			stopRotatingFrogAndMoveIt(distanceVec,velocityVal);

		}
	
	}


	void moveFrogAndroid(){
	
		Vector3 currentPos, touchedPos, distanceVec;

		for (int i=0; i < Input.touches.Length; i++){
			Touch touch = Input.GetTouch(i);
			currentPos = Camera.main.WorldToScreenPoint(transform.position);
			touchedPos = touch.position;
			distanceVec = (touchedPos - currentPos).normalized;
			if(Input.GetTouch(0).phase == TouchPhase.Began){
				startRotatingFrogAndStopIt();
			}else if(Input.GetTouch(0).phase == TouchPhase.Ended){
				currentTouchTime = Time.time;
				if (currentTouchTime - lastTouchTime > thresholdTime){ //No Double Touch detected ...
					lastTouchTime =Time.time;
					stopRotatingFrogAndMoveIt(distanceVec,velocityVal);
				}else if(currentTouchTime - lastTouchTime < thresholdTime){
					lastTouchTime =   Time.time;
					stopRotatingFrogAndMoveIt(distanceVec,velocityVal*2.0f);
				}
			}
		}
	}

	void startRotatingFrogAndStopIt(){
		//we rotate the frog
		GetComponent<Rigidbody2D>().fixedAngle = false;
		GetComponent<Rigidbody2D>().AddTorque (torqueVal*2);

		// .... and stop it
		GetComponent<Rigidbody2D>().velocity = Vector2.zero;
	}

	void stopRotatingFrogAndMoveIt(Vector3 distanceVec, float velocity){
		//we stop rotating the frog
		Quaternion frogQuatern = new Quaternion ();
		frogQuatern.eulerAngles = new Vector3 (0, 0, 0);
		GetComponent<Rigidbody2D>().fixedAngle = true;
		GetComponent<Rigidbody2D>().transform.rotation = frogQuatern;

		//... and move it.
		GetComponent<Rigidbody2D>().velocity = distanceVec * velocity;
		//print("im at last");
		//GetComponent<Rigidbody2D>().MovePosition(distanceVec);

	}



}
