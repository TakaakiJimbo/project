using UnityEngine;
using System.Collections;

public class  CreateLoad : MonoBehaviour {

	public GameObject PlayerCar;
	public GameObject Load1;
	public GameObject Load2;
	public GameObject Checkpoint;
	public int border = 250;

	void Update (){
		if ((PlayerCar != null) && PlayerCar.transform.position.z > border) {
			CreateMap();
		}
	}
	
	void CreateMap(){
		if (Load1.transform.position.z < border) {
			border += 250;
			Vector3 temp = new Vector3 (0,0,border);
			Load1.transform.position = temp;
		} else if (Load2.transform.position.z < border) {
			border += 250;
			Vector3 temp = new Vector3 (0,0,border);
			Load2.transform.position = temp;
			Checkpoint.SetActiveRecursively(true);
		}
	}
}
