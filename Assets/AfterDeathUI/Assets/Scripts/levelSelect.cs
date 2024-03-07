using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class levelSelect : MonoBehaviour
{
	public bool levelJedna;
	public bool levelDva;
	public bool levelTri;

	//public GameObject zamekLevelDva;
	//public GameObject zamekLevelTri;

	void Start()
	{
		levelJedna = true;
		levelDva = false;
		levelTri = false;
	}
	void Update()
	{

		//if (levelDva)
		//{
		//	zamekLevelDva.SetActive(false);
		//}
		//else
		//{
		//	zamekLevelDva.SetActive(true);
		//}

		//if (levelTri)
		//{
		//	zamekLevelTri.SetActive(false);
		//}
		//else
		//{
		//	zamekLevelTri.SetActive(true);
		//}
	}
	public void LevelJedna()
	{
		if (levelJedna)
		{
			SceneManager.LoadScene(1);
			Debug.Log("Load pøíslušné scény");
		}
	}
	public void LevelDva()
	{
		if (levelDva)
		{
			//SceneManager.LoadScene()
			Debug.Log("Load pøíslušné scény");
		}
		else
		{
			Debug.Log("Level dva nebyl odemèen.");
		}

	}
	public void LevelTri()
	{
		if (levelTri)
		{
			//SceneManager.LoadScene()
			Debug.Log("Load pøíslušné scény");
		}
		else
		{
			Debug.Log("Level Tri nebyl odemèen.");
		}
	}
}
