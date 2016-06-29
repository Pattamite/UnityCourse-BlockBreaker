using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour 
{
	public static int LastestLevel;

	public void LoadLevel(string name)
	{
		LastestLevel = Application.loadedLevel;
		Debug.Log ("Level load requested for: " + name);
		Ball.started = false;
		Application.LoadLevel(name);
	}
	
	public void LoadNextLevel()
	{
		LastestLevel = Application.loadedLevel;
		Debug.Log ("Next level load requested for: " + Application.loadedLevel +1);
		Ball.started = false;
		Application.LoadLevel(Application.loadedLevel +1);
	}
	
	public void LoadLastestLevel()
	{
		int temp = Application.loadedLevel;
		Application.LoadLevel (LastestLevel);
		LastestLevel = temp;
	}
	
	public void QuitRequest()
	{
		Debug.Log ("Quit Requested");
		Application.Quit();
	}

}
