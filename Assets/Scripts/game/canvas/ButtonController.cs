using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour {

	private AudioSource sound;

	public void Retry() {
		sound = GetComponent<AudioSource>();
		sound.PlayOneShot(sound.clip);
		Application.LoadLevel ("debug");
	}

	public void BackTitle() {
		sound = GetComponent<AudioSource>();
		sound.PlayOneShot(sound.clip);
		Application.LoadLevel ("main");
	}
}