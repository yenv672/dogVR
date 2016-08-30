using UnityEngine;
using System.Collections;

public class TestVision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(gameObject.GetComponent<Renderer>().isVisible);
	}
}
