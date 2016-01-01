using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour {

	[SerializeField] private AudioClip sound;

	public void Retry() {
		GetComponent<AudioSource>().PlayOneShot(sound);
		StartCoroutine ("LoadScene", "debug");
	}

	public void BackTitle() {
		GetComponent<AudioSource>().PlayOneShot(sound);
		StartCoroutine ("LoadScene", "main");
	}
		
	private IEnumerator LoadScene(string scene) {
		yield return new WaitForSeconds (0.5f);
		Application.LoadLevelAsync(scene);
	}
}