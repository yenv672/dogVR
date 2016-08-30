using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider collider) {
        if (collider.name == "Shiba_withikfk") {
            Application.LoadLevel("Street");
        }
    }
}
