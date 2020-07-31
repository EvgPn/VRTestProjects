using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSDisplayScript : MonoBehaviour
{
	[SerializeField] private Text _fpsText;

	private void Update()
	{
		float current = (int)(1f / Time.deltaTime);
		if(Time.frameCount % 50 == 0)
		{
			_fpsText.text = "FPS " + current.ToString();
		}
	}
}
