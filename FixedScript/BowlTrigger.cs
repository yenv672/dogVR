using UnityEngine;
using System.Collections;

public class BowlTrigger : MonoBehaviour {
    [SerializeField]
    Renderer Food;
    Color StartColor,TargetColor;
    private bool HideColor;
	// Use this for initialization
	void Start () {
        StartColor = Food.material.color;
        TargetColor = new Color(StartColor.r, StartColor.g, StartColor.b, 0);

    }
	
	// Update is called once per frame
	void Update () {
        if (HideColor)
        {
            hideFood();
        }
        else {
            ShowFood();
        }

    }

    void OnTriggerEnter() {
        this.GetComponent<ObjectInteractions>().DogBowlChecked();
        //doing LeanTween;
        HideColor = true;
        
    }

    void OnTriggerExit() {
        //doing LeanTween;
        HideColor = false;
        
    }

    void hideFood() {
       
            LeanTween.color(Food.gameObject, TargetColor, 1f);
        
       
    }

    void ShowFood() {

        LeanTween.color(Food.gameObject, StartColor, 1f);
         
        
    }
}
