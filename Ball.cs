using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour 
{
	private Paddle paddle;
	private Vector3 paddleToBallVector;
	private bool started = false;

	// Use this for initialization
	void Start () 
	{
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Lock the ball realative to paddle.
		if(!started)this.transform.position = paddle.transform.position + paddleToBallVector;
		
		// Waiting for a mouse press to launch.
		if (Input.GetMouseButtonDown(0))
		{
			print ("Mouse clicked");
			started = true;
			this.rigidbody2D.velocity = new Vector2 (2.3f ,10f);
		}
	}
}
