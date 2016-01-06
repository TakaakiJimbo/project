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
		if(level % 1 == 0){
			itemGenerate(level);
		}
	}

	void itemGenerate(int level){
		int itemposition = level * 500 - 500;
		if(level == 1){
			itemposition = 20;
		}
		GameObject obj = (GameObject)Instantiate(Heal, new Vector3 (15f, 1f, itemposition),Quaternion.identity);
		GameObject obj2 = (GameObject)Instantiate(Accelerate, new Vector3 (0f, 1f, itemposition),Quaternion.identity);
		GameObject obj3 = (GameObject)Instantiate(Invinsible, new Vector3 (-15f, 1f, itemposition),Quaternion.identity);
		Destroy(obj , 10);
		Destroy(obj2, 10);
		Destroy(obj3 , 10);
		Resources.UnloadUnusedAssets();
	}

}
