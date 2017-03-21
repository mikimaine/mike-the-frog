using UnityEngine;
using System.Collections;

public class MoveBubbles : MonoBehaviour {
	public Vector2 bubbleSpeed = new Vector2 (-2.5f, 0f);
	private float maxBubbleSpeedDevation;

	void Awake(){
		maxBubbleSpeedDevation = 0.5f;
	}
	// Use this for initialization
	void Start () {
		GetComponent< Rigidbody2D> ().velocity = new Vector2 (bubbleSpeed.x, Random.Range(-maxBubbleSpeedDevation,maxBubbleSpeedDevation));
	}
	// Update is called once per frame
	void Update () {
	
	}
}
