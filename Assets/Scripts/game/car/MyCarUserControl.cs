using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car {
	[RequireComponent(typeof(CarController))]
	// [RequireComponent(typeof (MyCarItem))]
	public class MyCarUserControl : MyCar {

		private CarController car;
		// the car controller we want to use
		//	private MyCarItem       item;

		protected override void initialize() {
			car = GetComponent<CarController>();
//			item = GetComponent<MyCarItem>();
		}

		private void FixedUpdate() {
			//float h        = CrossPlatformInputManager.GetAxis("Horizontal"+identifier);
			float h = Input.GetAxis("Mouse X");
			float v = 0.2f;
//			float v        = CrossPlatformInputManager.GetAxis("Vertical"+identifier);
//			bool  use      = CrossPlatformInputManager.GetButtonDown ("Useitem"+identifier);
			car.Move(15f * h, v, v, 0f);
//			item.useItem (use);
		}
	}
}