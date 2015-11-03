using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public Rigidbody rb;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate () {
		rb.velocity = transform.forward * 10f + Physics.gravity;


		Ray moveRay = new Ray( transform.position, transform.forward) ;
		Debug.DrawRay ( moveRay.origin, moveRay.direction );

		if ( Physics.Raycast ( moveRay, 3f ) ) {
			int randomNumber = Random.Range (0, 2); // random num, 0 or 1
			if ( randomNumber == 0) {
				// turn left
				transform.Rotate (0f, -90f, 0f);
			} else {
				// turn right
				transform.Rotate (0f, 90f, 0f);
			}
	} 

}
}