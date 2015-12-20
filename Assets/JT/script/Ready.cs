using UnityEngine;
using System.Collections;

public class Ready : MonoBehaviour 
{


	void FixedUpdate () 
	{
		if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Space)) 
		{
			Application.LoadLevel("Goal");
		}
	}
}

