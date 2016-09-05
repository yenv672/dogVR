using UnityEngine;
using System.Collections;

public class ObjectInteractions : MonoBehaviour {
    [SerializeField]
    Renderer Render;
    stateMachine StateMachine;
   
    bool isColorHover=true;

    Color[] HoverColor = new Color[2];
    int index = 0;
    // Use this for initialization
    void Start () {
        StateMachine = GameObject.Find("StateMachine").GetComponent<stateMachine>();
        HoverColor[0] = Render.material.color;
        HoverColor[1] = Color.white;

    }
	
	// Update is called once per frame
	void Update () {
	
	}

  

    //HideTheDogBed Show DogBox is in the DogBedTrigger Script
    public void HideDogBed() {
        this.GetComponent<Collider>().enabled = false;
        Render.enabled = false;
    }

    public void DogBowlChecked() {
        Debug.Log("DogBowlChecked");
        StateMachine.IsBowlChecked = true;
        this.gameObject.tag = "Untagged";
        StateMachine.StateCheck();
    }

    public void RubbishBinChecked() {
        Debug.Log("RubbishBinChecked");
        StateMachine.IsRubbishBinChecked = true;
        this.gameObject.tag = "Untagged";
        StateMachine.StateCheck();
    }

    public void BoxChecked() {
        Debug.Log("boxChecked");
        StateMachine.IsBoxChecked = true;
        this.gameObject.tag = "Untagged";
        StateMachine.StateCheck();
    }
		

    public void FrameChecked() {
        Debug.Log("FrameCheck");
        if (StateMachine.getCurrentGameState() != stateMachine.GameState.Stage03)
        {
            StateMachine.IsFrameChecked = true;
            this.gameObject.tag = "Untagged";
        }
        else {
            StateMachine.IsFrameChecked = true;
            this.gameObject.tag = "Untagged";
            this.GetComponent<Rigidbody>().useGravity = true;
        }
        StateMachine.StateCheck();
    }


    public void DisableColorHorver (){
        isColorHover = false;
     
        }

    /// <summary>
    /// HighLight the InteractiveObject using LeanTween;
    /// </summary>
    public void ColorHorver() {

        if (isColorHover)
        {
            LeanTween.color(Render.gameObject, HoverColor[index], 1f).setOnComplete(delegate ()
            {
                index += 1;
                if (index > 1)
                {
                    index = 0;
                }
                ColorHorver();
            });
        }
        else {
            Render.material.color = HoverColor[0];
        }
    }
}
