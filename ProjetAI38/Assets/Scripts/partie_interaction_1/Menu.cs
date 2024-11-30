using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	public void LoadSceneInteraction()
	{
		SceneManager.LoadScene("testInteraction");
	}

	public void LoadSceneStation()
	{
		SceneManager.LoadScene("testStation");
	}

	public void LoadSceneLab()
	{
		SceneManager.LoadScene("testLab");
	}
}
