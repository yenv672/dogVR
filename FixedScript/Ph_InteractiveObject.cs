using UnityEngine;
using System.Collections;
using UnityEngine.Events;
public class Ph_InteractiveObject : MonoBehaviour {
    [System.Serializable]
    public class MyEventType : UnityEvent { }
    public MyEventType click;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClick()
    {
        click.Invoke();
    }
}
