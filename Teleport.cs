// Copyright (C) Stanislaw Adaszewski, 2013
// http://algoholic.eu

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Teleport : MonoBehaviour {
	
	public Transform OtherEnd;
	public Transform shiba;
	public GameObject[] disableThis;
//	public GameObject shiba;
//	public Rigidbody shibaRid;

	HashSet<Collider> colliding = new HashSet<Collider>();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other) {
		if (!colliding.Contains(other)) {
			
			
			Quaternion q1 = Quaternion.FromToRotation(transform.up, OtherEnd.up);
			Quaternion q2 = Quaternion.FromToRotation(-transform.up, OtherEnd.up);
			
			Vector3 newPos = OtherEnd.position + q2 * (other.transform.position - transform.position);// + OtherEnd.transform.up * 2;;

			shiba.transform.position = newPos;

//			if (other.GetComponent<Rigidbody>() != null) {
//				GameObject o = (GameObject) GameObject.Instantiate(other.gameObject, newPos, other.transform.localRotation);
//				o.GetComponent<Rigidbody>().velocity = q2 * other.GetComponent<Rigidbody>().velocity;
//				o.GetComponent<Rigidbody>().angularVelocity = other.GetComponent<Rigidbody>().angularVelocity;
//				other.gameObject.SetActive(false);
//				Destroy(other.gameObject);
//				other = o.GetComponent<Collider>();
//			}
			
			OtherEnd.GetComponent<Teleport>().colliding.Add(other);
			
			other.transform.position = newPos;
			
			Vector3 fwd = other.transform.forward;
			
			if (other.GetComponent<Rigidbody>() == null) {
				other.transform.LookAt(other.transform.position + q2 * fwd, OtherEnd.transform.forward);
			}

			if (disableThis.Length > 0) {
				for (int i = 0; i < disableThis.Length; i++) {
					disableThis [i].SetActive (false);
				}
			}
		}
	}
	
	void OnTriggerExit(Collider other) {
//		colliding.Remove(other);
	}
}
