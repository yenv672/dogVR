using UnityEngine;
using System.Collections;

public class stateMachine : MonoBehaviour {
  public  enum GameState {
        GameInitialization, Stage01,OnStage01End, Stage02Initialization, Stage02, 
		OnStage02End,Stage03Initialization,Stage03, OnStage03End,
		Stage04Initialization
    };

    //[SerializeField]
   public GameState CurrentGamestates;
    float lastStateChage = 0.0f;
    [SerializeField]
    private Transform Frame, DogBed, Box, HomeRubbishBin, Dogbowl,Napkin;
	public GameObject stageFourLoadEnable;
	public bool IsFrameChecked, IsBoxChecked,IsRubbishBinChecked,IsBowlChecked,IsNapkinChecked;

    // Use this for initialization
    void Start () {
        SetCurrentState(GameState.GameInitialization);
        StateCheck();

    }
    void SetCurrentState(GameState _state)
    {
        CurrentGamestates = _state;
        lastStateChage = Time.time;
    }
    public GameState getCurrentGameState() {
        return CurrentGamestates;
    }


    float GetStateElapsed()
    {
        return Time.time - lastStateChage;
    }
    // Update is called once per frame
    void Update () {
        //StateCheck();
    }

    public void  StateCheck() {
      //  Debug.Log("CheckState");
        switch (CurrentGamestates)
        {
            case GameState.GameInitialization:
                Debug.Log("GameInitialization");
                //Initialization game()
                InitializeGame();
                SetCurrentState(GameState.Stage01);  //go to stage 01;
                StateCheck();
                break;
            case GameState.Stage01:
                if (IsFrameChecked ) {
                    SetCurrentState(GameState.OnStage01End);//go to stage01 end
                    StateCheck();
                }              
                Debug.Log("Stage01");
                break;
            case GameState.OnStage01End:
                EndStage01();
                SetCurrentState(GameState.Stage02Initialization);//go to stage 02;
                Debug.Log("OnStage01End");
                StateCheck();
                break;
            case GameState.Stage02Initialization:
                InitializationsStage02();
                Debug.Log("Stage02Initialization");
                SetCurrentState(GameState.Stage02);//go to stage 02;
                StateCheck();
                break;
            case GameState.Stage02:
                Debug.Log("Stage02");
			if (IsRubbishBinChecked && IsBowlChecked && IsBoxChecked) {
                    SetCurrentState(GameState.OnStage02End);
                    StateCheck();
                }
                break;
            case GameState.OnStage02End:
                EndStage02();
                Debug.Log("OnStage02End");
                SetCurrentState(GameState.Stage03Initialization);//go to stage 03;
                StateCheck();
                break;
            case GameState.Stage03Initialization://START STAGE 03;
                InitializationStage03();
                Debug.Log("Stage03Initialization");
                SetCurrentState(GameState.Stage03);
                StateCheck();
                break;
            case GameState.Stage03:
                if (IsFrameChecked) {
                    SetCurrentState(GameState.OnStage03End);//END THE STAGE 03
                    StateCheck();
                }
                Debug.Log("Stage03");
                break;
            case GameState.OnStage03End:
                EndStage03();
                Debug.Log("OnStage04End");
				SetCurrentState(GameState.Stage04Initialization);//go to stage 04;
                StateCheck();
                break;
			case GameState.Stage04Initialization:
				InitializationStage04 ();
				Debug.Log ("InitializationStage04");
				break;
			default:
				break;
        }
    }
    void InitializeGame() {
		Frame.tag = "Interactable";
        Frame.GetComponent<ObjectInteractions>().ColorHorver();
        Napkin.gameObject.SetActive(false);
    }

    void EndStage01() {
        IsFrameChecked =IsBoxChecked=IsRubbishBinChecked=IsBowlChecked = IsNapkinChecked = false;
        Frame.gameObject.tag = "Untagged";
        Box.GetComponent<ObjectInteractions>().DisableColorHorver();
        Frame.GetComponent<ObjectInteractions>().DisableColorHorver();
    }

    void InitializationsStage02() {
        IsFrameChecked = IsBoxChecked = IsRubbishBinChecked = IsBowlChecked= IsNapkinChecked = false;
		DogBed.gameObject.SetActive (false);
		Box.GetComponent<Renderer> ().enabled = true;
		Box.gameObject.tag = "Interactable";
		Box.GetComponent<ObjectInteractions>().ColorHorver();
		HomeRubbishBin.tag = "Interactable";
        HomeRubbishBin.GetComponent<ObjectInteractions>().ColorHorver();
        Dogbowl.tag = "Interactable";
        Dogbowl.GetComponent<ObjectInteractions>().ColorHorver();
    }

    void EndStage02() {
        IsFrameChecked = IsBoxChecked = IsRubbishBinChecked = IsBowlChecked = IsNapkinChecked = false;
		Box.tag = "Untagged";
		Box.GetComponent<ObjectInteractions>().DisableColorHorver();
		HomeRubbishBin.tag = "Untagged";
        HomeRubbishBin.GetComponent<ObjectInteractions>().DisableColorHorver();
        Dogbowl.tag = "Untagged";
        Dogbowl.GetComponent<ObjectInteractions>().DisableColorHorver();
    }

    void InitializationStage03() {
        IsFrameChecked = IsBoxChecked = IsRubbishBinChecked = IsBowlChecked = IsNapkinChecked = false;
        Frame.gameObject.tag = "Interactable";
        Frame.GetComponent<ObjectInteractions>().ColorHorver();
        Napkin.gameObject.SetActive(true);
    }

    void EndStage03() {
        IsFrameChecked = IsBoxChecked = IsRubbishBinChecked = IsBowlChecked= IsNapkinChecked = false;
        Frame.gameObject.tag = "Untagged";
    }

	void InitializationStage04() {
		IsFrameChecked = IsBoxChecked = IsRubbishBinChecked = IsBowlChecked= IsNapkinChecked = false;
		stageFourLoadEnable.SetActive (true);
	}
}
