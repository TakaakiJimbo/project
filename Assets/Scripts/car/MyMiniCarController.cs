using UnityEngine;
using System.Collections;

public class MyMiniCarController : MonoBehaviour {

	private int count ;

	void Start () {
		count = gameObject.transform.childCount;
		StartCoroutine(loop());
	}
	
	private IEnumerator loop() {
		while (true) {
			yield return new WaitForSeconds(1.5f);
			enableMiniCar();
		}
	}

	private void enableMiniCar() {
		gameObject.transform.GetChild (Random.Range (0, count)).gameObject.SetActive (true);
	}
}
