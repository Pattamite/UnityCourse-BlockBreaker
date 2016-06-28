using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour 
{

	public int maxHit;
	private LevelManager levelManager;
	private int timesHit;
	
	// Use this for initialization
	
	void Start () 
	{
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		timesHit = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	void OnCollisionEnter2D (Collision2D col)
	{
		timesHit++;
		if(timesHit >= maxHit) Destroy(gameObject);
		
	}
}
