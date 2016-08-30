using UnityEngine;
using System.Collections;

public class DogBedTrigger : MonoBehaviour {
    [SerializeField]
    Renderer Box;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnTriggerExit()
    {
        Box.tag = "Interactable";
        Box.GetComponent<ObjectInteractions>().ColorHorver();
        Box.enabled = true;
        //HideTheBed
        this.GetComponent<Ph_InteractiveObject>().OnClick();
        
    }
}
