using UnityEngine;
using System.Collections;

public class enableThese : MonoBehaviour {

	public GameObject[] enableItem;


	// Use this for initialization
	void Start () {
		for (int i = 0; i < enableItem.Length; i++) {
			enableItem [i].SetActive (true);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
