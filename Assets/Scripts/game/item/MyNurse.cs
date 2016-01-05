﻿using UnityEngine;
using System.Collections;

public class MyNurse : MyItem {
	
	void FixedUpdate() {
		gameObject.transform.Rotate(0, 4f, 0);	
	}
		
	protected override void collidedItemAction(GameObject collidedobject) {
	}

	protected override void setItemAppearedPosition (Transform cartransform) {
		Transform gameobjecttransform = gameObject.transform;
		gameobjecttransform.position  = cartransform.position +  cartransform.up * 0.5f +  cartransform.forward * (-4);
	}
}