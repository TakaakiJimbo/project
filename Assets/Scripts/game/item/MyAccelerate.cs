using UnityEngine;
using System.Collections;

public class MyAccelerate : MyItem {

	void FixedUpdate() {
		gameObject.transform.Rotate(0, 4f, 0);	
	}

	protected override void collidedItemAction(GameObject collidedobject) {
		itemFlag = false;
		Debug.Log("start");
		timecontrol.getItem();
		accelerateCar(collidedobject);
	}

	private void accelerateCar(GameObject collidedobject) {
		collidedobject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 20f), ForceMode.VelocityChange);
	}

	protected override void setItemAppearedPosition(Transform cartransform) {
		Transform gameobjecttransform = gameObject.transform;
		gameobjecttransform.position = cartransform.position + cartransform.up * 0.5f + cartransform.forward * (-4);
	}
}