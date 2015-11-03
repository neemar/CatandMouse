using UnityEngine;
using System.Collections;

public class Cat : MonoBehaviour {

	public Transform mouse;
	Rigidbody rb;
	
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 directionToMouse = mouse.position - transform.position;
		float angle = Vector3.Angle(transform.forward, directionToMouse);
		if (angle < 90.0f) {
			Ray mouseRay = new Ray( transform.position, directionToMouse );
			RaycastHit mouseRayHitInfo = new RaycastHit();
			if ( Physics.Raycast ( mouseRay, out mouseRayHitInfo, 50f ) ) {
				if (mouseRayHitInfo.collider.tag == "Mouse") {
					rb.AddForce(directionToMouse.normalized * 800f);
				}
			}
		}
		
	}
}
