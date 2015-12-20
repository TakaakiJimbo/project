/*
using UnityEngine;
using System.Collections;

public class EnemyAppearance : MonoBehaviour {
	
	public GameObject Enemy;
	public float interval;
	private bool SpawnStart = true;
	//public float randMin = 1.0f;
	//public float randMax = 3.0f;
	// Use this for initialization
	void Start () {
		StartCoroutine("SpawnEnemy");
	}
	
	IEnumerator SpawnEnemy () {
		while(true) {
			interval = 1.0f;//Random.Range(randMin,randMax);
			Instantiate(Enemy, new Vector3(Random.Range(-20f,20f),3f,Random.Range(0f,100f)), Quaternion.identity);
			yield return new WaitForSeconds(interval);
		}
	}
	/*
	void SpawnStop () {
		StopCoroutine("SpawnEnemy");
	}

}
*/