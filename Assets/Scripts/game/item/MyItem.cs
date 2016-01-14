
using UnityEngine;
using System.Collections;

public abstract class MyItem : MonoBehaviour {

	[SerializeField] private int damagecarvalue = 0;
	[SerializeField] private AudioClip hititemsound;
	static public bool itemFlag = true;
	public MyTimeControl timecontrol;

	protected abstract void collidedItemAction(GameObject collidedobject);

	protected abstract void setItemAppearedPosition(Transform cartransform);


	void Start() {
		timecontrol = GameObject.Find("GameControl").GetComponent<MyTimeControl>();
	}

	// layer 8 is "Car"
	void OnCollisionEnter(Collision other) {
		if(other.gameObject.layer == 8) {
			GameObject carobject = other.transform.root.gameObject;
			AudioSource.PlayClipAtPoint(hititemsound, carobject.transform.position);
			if(itemFlag) {
				collidedItemAction(carobject);
				damageCarByItem(carobject.GetComponent<MyCarLifePoint>());
			}
			destroyItem(gameObject);
		}
	}

	protected void damageCarByItem(MyCarLifePoint carlifepoint) {
		carlifepoint.changeLifePoint(damagecarvalue);
	}

	protected virtual void destroyItem(GameObject collideobject) {
		Destroy(collideobject);
	}

	protected void setItemAppearedPlace(Transform cartransform) {
		setItemAppearedRotation(cartransform);
		setItemAppearedPosition(cartransform);
	}

	protected void setItemAppearedRotation(Transform cartransform) {
		gameObject.transform.rotation = Quaternion.Euler(cartransform.eulerAngles.x, cartransform.eulerAngles.y, cartransform.eulerAngles.z);
	}
}
