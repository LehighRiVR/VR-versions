using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PointerUI : MonoBehaviour
{
    public float m_DistanceUI = 10.0f;        
    public LineRenderer m_LineRendererUI = null;
    public LayerMask m_EverythingMask = 0;    
    public LayerMask m_UinteractMask = 0;    
    public UnityAction<Vector3, GameObject> OnPointerUpdate = null;          
    
    private Transform m_CurrentOriginUI = null;
    private GameObject m_CurrentObjectUI = null;
    public VRInputModule m_InputModule;

    public GameObject m_Dot;


    private void Awake()
    {
        PlayerEvents.OnControllerSource += UpdateOriginUI;
        PlayerEvents.OnTouchpadDown += ProcessTouchpadDown;
        

        m_LineRendererUI = GetComponent<LineRenderer>();

    }

    private void Start()
    {
        SetLineColorUI();
    }

    private void OnDestroy()
    {
        PlayerEvents.OnControllerSource -= UpdateOriginUI;
        PlayerEvents.OnTouchpadDown -= ProcessTouchpadDown;
        
    }

    private void Update()
    {
        Vector3 hitPointUI = UpdateLineUI();
                
        m_CurrentObjectUI = UpdatePointerStatusUI();

        if (OnPointerUpdate != null)
            OnPointerUpdate(hitPointUI, m_CurrentObjectUI);
    }

    private Vector3 UpdateLineUI()
    {
        // Use default or distance
        PointerEventData data = m_InputModule.GetData();
        float targetLength = data.pointerCurrentRaycast.distance == 0 ? m_DistanceUI : data.pointerCurrentRaycast.distance;

        // Create ray
        RaycastHit hitUI = CreateRaycastUI(m_UinteractMask);

        // Default end
        Vector3 endPositionUI = m_CurrentOriginUI.position + (m_CurrentOriginUI.forward * m_DistanceUI);

        // Check hit
        if (hitUI.collider != null)
            endPositionUI = hitUI.point;
        
        // Set position of the dot
        m_Dot.transform.position = endPositionUI;

        // Set line renderer 
        m_LineRendererUI.SetPosition(0, transform.position);
        m_LineRendererUI.SetPosition(1, endPositionUI);

        // Set position
        m_LineRendererUI.SetPosition(0, m_CurrentOriginUI.position);
        m_LineRendererUI.SetPosition(1, endPositionUI);

        return endPositionUI;
    }

    private void UpdateOriginUI(OVRInput.Controller controller, GameObject controllerObjectUI)
    {
        // Set origin of pointer
        m_CurrentOriginUI = controllerObjectUI.transform;

        // Is the laser visible?
        if (controller == OVRInput.Controller.Gamepad)
        {
            m_LineRendererUI.enabled = false;
        }
        else
        {
            m_LineRendererUI.enabled = true;
        }
    }      

    private GameObject UpdatePointerStatusUI()
    {
        // Create a Ray
        RaycastHit hitUI = CreateRaycastUI(m_UinteractMask);

        // Check hit
        if (hitUI.collider)
            return hitUI.collider.gameObject;

        // Return
        return null;
    }
    
        private RaycastHit CreateRaycastUI(int m_UinteractMask)
        {
            Ray rayUI = new Ray(m_CurrentOriginUI.position, m_CurrentOriginUI.forward);
            Physics.Raycast(rayUI, out RaycastHit hitUI, m_DistanceUI, this.m_UinteractMask);

            return hitUI;
        }    
        

    private void SetLineColorUI()
    {
        if (!m_LineRendererUI)
            return;

        Color endColorUI = Color.green;
        endColorUI.a = 0.0f;

        m_LineRendererUI.endColor = endColorUI;            

    }
        
    private void ProcessTouchpadDown()
    {
        if (!m_CurrentObjectUI)
            return;     
        
        UInteract uinteract = m_CurrentObjectUI.GetComponent<UInteract>();
        uinteract.AcceptTouchpadClick();
        uinteract.UIButton();
        
        //uinteract.ContinueClicked();
        //uinteract.ReturnClicked();
        //uinteract.SpriteClicked();
    }    
        
}
