
using UnityEngine;
using System.Collections;

public abstract class MyItem : MonoBehaviour {

	[SerializeField] private int       damagecarvalue = 0;
	[SerializeField] private AudioClip setitemsound;
	[SerializeField] private AudioClip hititemsound;

	protected abstract void collidedItemAction (GameObject collidedobject);
	protected abstract void setItemAppearedPosition (Transform cartransform); 

	void OnEnable() {
		GetComponent<AudioSource>().PlayOneShot(setitemsound);
	}

	// layer 8 is "Car"
	void OnCollisionEnter(Collision other) {
		if (other.gameObject.layer == 8) {
			GameObject carobject = other.transform.root.gameObject;
			AudioSource.PlayClipAtPoint(hititemsound, carobject.transform.position);
			collidedItemAction(carobject);
			damageCarByItem(carobject.GetComponent<MyCarLifePoint> ());
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
/*

using UnityEngine;
using System.Collections;

public abstract class MyItem : MonoBehaviour {
	
	[SerializeField] private int damagecarvalue = 0;
	
	protected bool          touchflag = false;
	
	protected AudioSource[] itemsounds;	// 0:hit, 1:set
	
	protected abstract void collidedItemAction (GameObject collidedobject);
	protected abstract void setItemAppearedPosition (Transform cartransform);
	protected abstract void destroyItem();
	protected abstract void OnEnableItemAction();
	
	void OnEnable() {
		itemsounds = gameObject.GetComponents<AudioSource>();
		OnEnableItemAction();
	}
	
	// layer 8 is "Car"
	protected virtual void OnCollisionEnter(Collision other) {
		if(!touchflag) {
			if (other.gameObject.layer == 8) {
				touchflag = true;
				GameObject carobject = other.gameObject;
				collidedItemAction(carobject);
				damageCarByItem(carobject.GetComponent<MyCarLifePoint> ());
				itemsounds[0].Play();
				destroyItem();
			}
			else if(other.gameObject.tag == "Item") {
				touchflag = true;
				destroyItem();
			}
		}
	}
	
	protected void damageCarByItem(MyCarLifePoint carlifepoint) {
		carlifepoint.changeLifePoint(damagecarvalue);
	}
	
	protected IEnumerator keepAndDestroyItem(float delay) {
		yield return new WaitForSeconds (delay);
		Destroy(gameObject);
	}
	
	protected void setItemAppearedPlace(Transform cartransform) {
		setItemAppearedRotation(cartransform);
		setItemAppearedPosition(cartransform);
	}
	
	protected void setItemAppearedRotation(Transform cartransform) {
		gameObject.transform.rotation = Quaternion.Euler(cartransform.eulerAngles.x, cartransform.eulerAngles.y, cartransform.eulerAngles.z);
	}
}
*/