using UnityEngine;
using System.Collections;

public class triggerBody : MonoBehaviour {

    public SkinnedMeshRenderer triggerThis;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider who) {
        if (who.tag == "Player") {
           // print("here");
            triggerThis.enabled = !triggerThis.enabled;
        }

    }
}
