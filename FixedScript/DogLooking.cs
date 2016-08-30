using UnityEngine;
using System.Collections;

public class DogLooking : MonoBehaviour {
	/*
	enum dogstate{
		standing,
		walking
	}
	*/
	// RAYCAST LOOKING

	//Ray shootRay;
//	RaycastHit shootHit;
	//int ShootableMask;

	//CHARACTER
	[SerializeField]
	float CDtime,currentTime,StaticCDtime,StaticCurrentTime;
	Quaternion currentRot;
	Transform VRDogViewTrans;
	Transform DogPivotTrans;
	Transform DogHead;
	Transform CameraLocater;

	Quaternion VRRot;
	// Use this for initialization
	void Start () {
		//ShootableMask = LayerMask.GetMask("interact");
        Cursor.visible = false;
        DogHead = GameObject.Find ("Spine_front_8").GetComponent<Transform> ();
		VRDogViewTrans = GameObject.Find ("Head").GetComponent<Transform> ();
		DogPivotTrans = GameObject.Find ("Shiba_withikfk").GetComponent<Transform> ();
		CameraLocater = GameObject.Find ("CameraLocater").GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 rot = VRDogViewTrans.rotation.eulerAngles;
		Quaternion QuaternionRot = VRDogViewTrans.rotation;
		Vector3 pos = CameraLocater.position;
       
		//if statement when you standing 
		SynchronizeVRRotToDogRot(QuaternionRot);

		SynchronizeVRRotToHeadRot (rot);
		SynchronizeCameraPosition (pos);
	//	RayCast ();

	}

	void SynchronizeVRRotToDogRot(Quaternion _QuaternionRot){
        if (FindObjectOfType<DogMoving>().move == true)
        {
            currentTime += Time.deltaTime;

            if (currentTime >= CDtime)
            {
                currentRot = _QuaternionRot;
                currentTime = 0;
            }
            Quaternion value = Quaternion.Lerp(DogPivotTrans.rotation, currentRot, .1f);
            //float	value	=Vector3.Lerp (DogPivotTrans.rotation.eulerAngles, currentRot, .05f).y;
            //DogPivotTrans.rotation = Quaternion.Euler (0, value, 0);
            DogPivotTrans.rotation = value;
            DogPivotTrans.rotation = Quaternion.Euler(0, DogPivotTrans.rotation.eulerAngles.y, 0);
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~when dog not moving synchronize the rotation
        float Rotdelta =Mathf.Abs (DogPivotTrans.rotation.eulerAngles.y - (VRDogViewTrans.rotation.eulerAngles.y));

     //   Debug.Log(Rotdelta);
        if (FindObjectOfType<DogMoving>().move == false&& Rotdelta >60) {

            StaticCurrentTime += Time.deltaTime;

            if (StaticCurrentTime >= CDtime)//synchronizing rotation every .05f seconds, when delta >90 degrees.  
            {
                currentRot = _QuaternionRot;
                StaticCurrentTime = 0;
            }
            //  Debug.Log(Mathf.Cos(localrotY));
           

        //    Debug.Log("Not MOVING TURING");
                Quaternion value = Quaternion.Lerp(DogPivotTrans.rotation, currentRot, .05f);
                DogPivotTrans.rotation = value;
                DogPivotTrans.rotation = Quaternion.Euler(0, DogPivotTrans.rotation.eulerAngles.y, 0);
        }
        
	}

	void SynchronizeVRRotToHeadRot(Vector3 _Rot){
		
		DogHead.rotation = Quaternion.Euler (_Rot.z,_Rot.y+90 ,_Rot.x);
	}

	void SynchronizeCameraPosition(Vector3 _pos){
		transform.position = _pos;
	}
    /*
	void RayCast(){
		Vector3 fwd = VRDogViewTrans.forward;
        Debug.DrawRay(VRDogViewTrans.position, fwd, Color.red);
		if (Physics.Raycast (VRDogViewTrans.position, fwd, out shootHit, 10, ShootableMask)) {
			
			if (shootHit.collider.gameObject.GetComponent<ObjectLookingCheck> () != null) {
				
				shootHit.collider.gameObject.GetComponent<ObjectLookingCheck> ().BeLooked = true;
			}

		}
		//Debug.DrawRay(VRDogViewTrans.position, fwd, Color.green, 10000, true);
	
	}
    */
}
