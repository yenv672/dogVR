using UnityEngine;
using System.Collections;

public class loadLevelAddtive : MonoBehaviour {

	public int whatLevel = 1;
	public enableThese enableThisWhenDone;

	IEnumerator Start() {
		AsyncOperation async = Application.LoadLevelAdditiveAsync(whatLevel);
		yield return async;
		enableThisWhenDone.enabled = true;
		Debug.Log("Loading complete");
	}
}
