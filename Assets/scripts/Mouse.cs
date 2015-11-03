using UnityEngine;
using System.Collections;

public class Mouse : MonoBehaviour {

	public Transform cat;
	public AudioSource seecat;
	Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 directionToCat = cat.position - transform.position;
		float angle = Vector3.Angle(transform.forward, directionToCat);
		if (angle < 180.0f) {
			Ray mouseRay = new Ray( transform.position, directionToCat );
			RaycastHit mouseRayHitInfo = new RaycastHit();
		if ( Physics.Raycast ( mouseRay, out mouseRayHitInfo, 40f ) ) {
			if (mouseRayHitInfo.collider.tag == "Cat") {
					seecat.Play();
					rb.AddForce(-directionToCat.normalized * 1000f);
			}
		}
	}

}
}