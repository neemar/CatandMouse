using UnityEngine;
using System.Collections;

public class Cat : MonoBehaviour {

	public GameObject mouse;
	public AudioSource caught;
	public AudioSource killed;
	Rigidbody rb;

	
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 directionToMouse = mouse.transform.position - transform.position;
		float angle = Vector3.Angle(transform.forward, directionToMouse);
		if (angle < 90.0f) {
			Ray mouseRay = new Ray( transform.position, directionToMouse );
			RaycastHit catRayHitInfo = new RaycastHit();
			if ( Physics.Raycast ( mouseRay, out catRayHitInfo, 50f ) ) {
				if (catRayHitInfo.collider.tag == "Mouse") {
					caught.Play();
					if (catRayHitInfo.distance <= 5) {
						Destroy(mouse);
						killed.Play();
					} else {
					rb.AddForce(directionToMouse.normalized * 1500f);

				}
			}
		}
		
	}
}
}