using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour 
{
	public void LoadLevel(string name)
	{
		Debug.Log ("Level load requested for: " + name);
		Ball.started = false;
		Application.LoadLevel(name);
	}
	
	public void LoadNextLevel()
	{
		Debug.Log ("Next level load requested for: " + Application.loadedLevel +1);
		Ball.started = false;
		Application.LoadLevel(Application.loadedLevel +1);
	}
	
	public void QuitRequest()
	{
		Debug.Log ("Quit Requested");
		Application.Quit();
	}

}
