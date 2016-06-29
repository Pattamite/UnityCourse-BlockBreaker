using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour 
{
	public int maxHit;
	public Sprite[] hitSprites;
	public AudioClip crack;
	public static int breakableCount = 0;
	public GameObject smoke;
	
	private LevelManager levelManager;
	private int timesHit;
	private bool isBreakable;
	
	// Use this for initialization
	
	void Start () 
	{
		isBreakable = (this.tag == "Breakable");
		if(isBreakable) 
		{
			breakableCount++;
			Debug.Log("Breakable brick: " + breakableCount);
		}
		
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		timesHit = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	void OnCollisionEnter2D (Collision2D col)
	{
		AudioSource.PlayClipAtPoint(crack, transform.position);
		if(isBreakable) HandleHits();	
	}
	
	void HandleHits()
	{
		timesHit++;
		if(timesHit >= maxHit) DestroyBrick();
		else LoadSprites();
	}
	
	void DestroyBrick()
	{
		breakableCount--;
		if(Brick.breakableCount <= 0) levelManager.LoadNextLevel();
		Debug.Log("Breakable brick: " + breakableCount);
		PuffSmoke();
		Destroy(gameObject);
	}
	
	void PuffSmoke()
	{
		GameObject smokePuff = Instantiate(smoke, gameObject.transform.position, Quaternion.identity) as GameObject;
		smokePuff.particleSystem.startColor = gameObject.GetComponent<SpriteRenderer>().color;
	}
	
	void LoadSprites ()
	{
		int spriteIndex = timesHit - 1;
		if (hitSprites[spriteIndex])
		{
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}
		else Debug.LogError("Failed to load Sprite: " + spriteIndex);
		
	}
}
