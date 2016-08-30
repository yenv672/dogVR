using UnityEngine;
using System.Collections;

public class ObjectLookingCheck : MonoBehaviour {
	public bool BeLooked;

    public Renderer REND;
    //public bool RayOnlook;
    //	float CDtime = .2F, CurrentCDtime;
    // Use this for initialization
    void Start () {
        //material = new Material(Shader.Find("Outlined/Silhouetted Bumped Diffuse"));
        REND.material.shader = Shader.Find("Outlined/Silhouetted Bumped Diffuse");
    }
	
	// Update is called once per frame
	void Update () {
        ColorSinWave(BeLooked);

        //	ActiveCheck (CDtime, RayOnlook);


    }


    void ColorSinWave(bool _BeLooked) {
        if (_BeLooked == false)
        {
            float Shininess = Mathf.PingPong(Time.time, 1.0f);
            Color shininessColor = new Color(234, 246, 121, Shininess);
            REND.material.SetColor("_OutlineColor", shininessColor);
        }
        else {
            Color shininessColor = new Color(234 , 246, 121, 0);
            REND.material.SetColor("_OutlineColor", shininessColor);
        }
        
    }
/*
	void ActiveCheck(float _CDtime, bool _RayOnlook){
		if (_RayOnlook) {
			CurrentCDtime += Time.deltaTime;
			if (CurrentCDtime >= CDtime) {
				//ACTIVE THE OBJECT 
				BeLooked = true;
				CurrentCDtime = 0F;
			}
		} else {
//RAY NOT LOOKING, SET TIMER BACK TO 0
			CurrentCDtime =0F;
		}

	}
	*/
}
