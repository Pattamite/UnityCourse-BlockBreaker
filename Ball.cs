using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour 
{
	private Paddle paddle;
	private Vector3 paddleToBallVector;
	public static bool started = false;
	public float badspeed = 0.2f;

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
		if (Input.GetMouseButtonDown(0) && !started)
		{
			print ("Mouse clicked");
			started = true;
			this.rigidbody2D.velocity = new Vector2 (2.3f ,10f);
		}
	}
	
	void OnCollisionEnter2D (Collision2D collision)
	{
		float tweak = Random.Range(0.7f, 2.0f);
		//print (tweak);
		if(started)
		{
			audio.Play();
			
			//tweak ball's velocity to prevent infinite loop.
			if(rigidbody2D.velocity.x < badspeed && rigidbody2D.velocity.x > (-1f*badspeed)) 
			{
				rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x + tweak, rigidbody2D.velocity.y);
			}
			if(rigidbody2D.velocity.y < badspeed && rigidbody2D.velocity.y > (-1*badspeed)) 
			{
				rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, rigidbody2D.velocity.y + tweak);
			}
			//print (rigidbody2D.velocity);
		}
	}
}
