using UnityEngine;
using System.Collections;

public class MyLevelControl : MonoBehaviour {

	public MyCamera targetcamera;
	public static int level;
	public int firstlevel = 1;
	public AudioClip checkedsound;
	AudioSource audioSource;
	[SerializeField]  private GameObject Heal;
	[SerializeField]  private GameObject Invinsible;
	[SerializeField]  private GameObject Accelerate;

	// Use this for initialization
	void Start () {
		audioSource = gameObject.GetComponent<AudioSource>();
		audioSource.clip =  checkedsound;
		//debug only
		level = firstlevel;
		itemGenerate (1);
		if(firstlevel > 1){
			for(int i = 1; i <= firstlevel; i++){
				MyTimeControl.ShortInterval();
			}
			targetcamera.showNowLevel(level);
		}
	}

	public void levelup(){
		level++;
		audioSource.Play();
		MyTimeControl.ShortInterval();
		targetcamera.showNowLevel(level);
		if((level - 1)  % 3 == 0){
			itemGenerate(level);
		}
	}

	void itemGenerate(int level){
		float position;


		int itemposition = level * 500 - 600;
		if(level == 1){
			itemposition = 100;
		}

		GameObject obj = (GameObject)Instantiate(Heal, new Vector3 (UnityEngine.Random.Range (-18f, -6f), 1f, itemposition),Quaternion.identity);
		GameObject obj2 = (GameObject)Instantiate(Accelerate, new Vector3 (UnityEngine.Random.Range (-6f, 6f), 1f, itemposition),Quaternion.identity);
		GameObject obj3 = (GameObject)Instantiate(Invinsible, new Vector3 (UnityEngine.Random.Range (6f, 18f), 1f, itemposition),Quaternion.identity);
		Destroy(obj , 15);
		Destroy(obj2, 15);
		Destroy(obj3 , 15);
		Resources.UnloadUnusedAssets();
	}

}
