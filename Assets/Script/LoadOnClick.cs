using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadOnClick : MonoBehaviour {

	public GameObject loadingImage;
	public GameObject btn;
	public int level;

	public void LoadScene(int level)
	{
		if (level == 1) {
			loadingImage.SetActive(true);
			btn.SetActive (false);
		}
		Application.LoadLevel(level);
	}
}
