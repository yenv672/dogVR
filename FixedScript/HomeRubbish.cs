using UnityEngine;
using System.Collections;

public class HomeRubbish : MonoBehaviour {
    private bool lookingcheck;
    
    [SerializeField]
    GameObject streetgrbage;
	// Use this for initialization
	void Start () {
        

    }
	
	// Update is called once per frame
	void Update () {

	}

    void OnTriggerStay(Collider _collider) {
      
            Debug.Log(gameObject.GetComponentInChildren<Renderer>().isVisible);
            if (gameObject.GetComponentInChildren<Renderer>().isVisible)
            {
                lookingcheck = true;
                Debug.LogWarning("SEEING THE BIN");
            }
            else
            {
                if (lookingcheck)
                {
                        Debug.LogWarning("Show Street Grabage");
                    this.GetComponent<ObjectInteractions>().RubbishBinChecked();
                    this.GetComponent<ObjectInteractions>().DisableColorHorver();
                    gameObject.GetComponentInChildren<Renderer>().enabled = false;
                    this.GetComponent<Collider>().enabled = false;
                    streetgrbage.SetActive(true);

                
            }
        }

    }
}
