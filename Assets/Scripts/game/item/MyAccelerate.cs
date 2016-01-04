using UnityEngine;
using System.Collections;

public class MyAccelerate : MyItem {

	void FixedUpdate() {
		gameObject.transform.Rotate(0, 4f, 0);	
	}
		
	protected override void collidedItemAction(GameObject collidedobject) {
	}
		
	private void accelerateCar(GameObject collidedobject) {
		//collidedobject.GetComponent<Rigidbody>.velocity = new Vector3(0, 0, 1000);
	}
		
	protected override void setItemAppearedPosition (Transform cartransform) {
		Transform gameobjecttransform = gameObject.transform;
		gameobjecttransform.position  = cartransform.position +  cartransform.up * 0.5f +  cartransform.forward * (-4);
	}
}