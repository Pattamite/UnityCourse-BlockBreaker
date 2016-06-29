using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour 
{
	public bool autoPlay = false;
	
	private Ball ball;
	
	void Start()
	{
		ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(autoPlay && Ball.started) AutoPlay();
		else MoveWithMouse();
	}
	
	void AutoPlay()
	{
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, this.transform.position.z);
		Vector3 ballPos = ball.transform.position;
		paddlePos.x = Mathf.Clamp(ballPos.x, 0.5f , 15.5f);
		
		this.transform.position = paddlePos;
	}
	
	void MoveWithMouse()
	{
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, this.transform.position.z);
		float mouseX = Input.mousePosition.x / Screen.width * 16;
		paddlePos.x = Mathf.Clamp(mouseX, 0.5f , 15.5f);
		
		this.transform.position = paddlePos;
	}
}
