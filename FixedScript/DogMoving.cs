using UnityEngine;
using System.Collections;

public class DogMoving : MonoBehaviour {
	private Transform DogPivotTrans;
	private Animator DogAnim;
	public bool move =false;

	[SerializeField]
	float speed;
	// Use this for initialization
	void Start () {

		DogAnim = GameObject.Find ("Shiba_withikfk").GetComponent<Animator> ();
		DogPivotTrans= GameObject.Find ("Shiba_withikfk").GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {

		if(Cardboard.SDK.Triggered){
			move =	move? false:true;
		}

		if(move){
			//			print("here");
			Vector3 direction = new Vector3(DogPivotTrans.forward.x,0,DogPivotTrans.forward.z);
			DogPivotTrans.position += direction * speed * Time.deltaTime;
			DogAnim.SetBool("walk",true);
		}else{
			DogAnim.SetBool("walk",false);
		}
	}
}
