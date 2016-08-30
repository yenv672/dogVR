using UnityEngine;
using System.Collections;

public class RayCaster : MonoBehaviour {
    [SerializeField]
    private bool m_ShowDebugRay;
    [SerializeField]
    private Transform m_Camera;
    [SerializeField]
    private float m_DebugRayLength = 5f;           // Debug ray length.
    [SerializeField]
    private float m_DebugRayDuration = 1f;
    [SerializeField]
    private float m_RayLength = 500f;
    [SerializeField]
    private LayerMask m_ExclusionLayers;
    // Use this for initialization

    private Ph_InteractiveObject m_CurrentInteractible;
    private Ph_InteractiveObject m_LastInteractible;
    public Ph_InteractiveObject CurrentInteractible
    {
        get { return m_CurrentInteractible; }
    }

    private bool IsHit;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
            EyeRayCaster();

    }

    private void EyeRayCaster()
    {
        if (m_ShowDebugRay)
        {
            Debug.DrawRay(m_Camera.position, m_Camera.forward * m_DebugRayLength, Color.blue, m_DebugRayDuration);
        }
        Ray ray = new Ray(m_Camera.position, m_Camera.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, m_RayLength, ~m_ExclusionLayers))
        {
            Ph_InteractiveObject interactible = hit.collider.GetComponent<Ph_InteractiveObject>(); //attempt to get the VRInteractiveItem on the hit object
            m_CurrentInteractible = interactible;

            if (m_CurrentInteractible != null && m_CurrentInteractible.tag == "Interactable")
            {
                if (IsHit == false)
                {
                    OnRayCastEnter();
                    IsHit = true;
                }
                else
                {
                    OnRayCastStay();
                }


            }
            else
            {
                if (IsHit)
                {
                    OnRayCastExit();
                    IsHit = false;
                    m_CurrentInteractible = null;
                }
            }

            m_CurrentInteractible = null;
        }
    }

    void OnRayCastEnter()
    {
       // Debug.Log("enter");
        m_CurrentInteractible.GetComponent<Ph_InteractiveObject>().OnClick();


    }

    void OnRayCastExit()
    {
      //  Debug.Log("exit");

    }

    void OnRayCastStay()
    {
       // Debug.Log("Stay");
    }
}
