using UnityEngine;
using System.Collections;

public class FallSound : MonoBehaviour {

	AudioSource audioSource;

	// Use this for initialization
	void Start () {
		audioSource = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void fallsound(){
		audioSource.Play();
	}

}
