using UnityEngine;
using System.Collections;

public class loadLevelAddtive : MonoBehaviour {

	public int whatLevel = 1;

	IEnumerator Start() {
		AsyncOperation async = Application.LoadLevelAdditiveAsync(whatLevel);
		yield return async;
		Debug.Log("Loading complete");
	}
}
