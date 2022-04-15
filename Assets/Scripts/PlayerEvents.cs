using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerEvents : MonoBehaviour
{
    public GameObject mainCanvas;

    public Vector2 DpadGO;
    public GameObject playerGO;
    public float speedGO;
    public GameObject centerEye;

    #region Events
    public static UnityAction OnTouchpadDown = null;
    public static UnityAction OnTriggerClick = null;
    
    public static UnityAction<OVRInput.Controller, GameObject> OnControllerSource = null;
    #endregion

    #region Anchors
    public GameObject m_LeftAnchor;
    public GameObject m_RightAnchor;
    public GameObject m_HeadAnchor;
    #endregion

    #region Input
    private Dictionary<OVRInput.Controller, GameObject> m_ControllerSets = null;
    private OVRInput.Controller m_InputSource = OVRInput.Controller.None;
    private OVRInput.Controller m_Controller = OVRInput.Controller.None;
    private bool m_InputActive = true;
    #endregion

    private void Awake()
    {        
        OVRManager.HMDMounted += PlayerFound;
        OVRManager.HMDUnmounted += PlayerLost;

        m_ControllerSets = CreateControllerSets();        
    }
    
    private void OnDestroy()
    {
        OVRManager.HMDMounted -= PlayerFound;
        OVRManager.HMDUnmounted -= PlayerLost;
    }

    private void Update()
    {
        //Check for active input
        if (!m_InputActive)
            return;

        // Check if a controller exists
        CheckForController();

        // Check for input source  
        CheckInputSource();

        // Check for actual input
        InputSetUp();
    }

    protected void CheckForController()
    {
        OVRInput.Controller controllerCheck = m_Controller;

        //right remote
        if (OVRInput.IsControllerConnected(OVRInput.Controller.RTrackedRemote))
                controllerCheck = OVRInput.Controller.RTrackedRemote;
                
        //left remote   <<This is selected within Oculus Home Options>>
        if (OVRInput.IsControllerConnected(OVRInput.Controller.LTrackedRemote))
                controllerCheck = OVRInput.Controller.LTrackedRemote;
                
        // if no controllers, set it to the GAMEPAD
        if (!OVRInput.IsControllerConnected(OVRInput.Controller.LTrackedRemote) &&
            !OVRInput.IsControllerConnected(OVRInput.Controller.RTrackedRemote))
                controllerCheck = OVRInput.Controller.Gamepad;                
        
        //Update
        m_Controller = UpdateSource(controllerCheck, m_Controller);

    }

    private void CheckInputSource()
    {
        //Update
        m_InputSource = UpdateSource(OVRInput.GetActiveController(), m_InputSource);
    }

    private void InputSetUp()  //this is where we configure each button action
    {

        #region Moving with OculusGO Controller

        DpadGO = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);   // << Oculus GO

        transform.eulerAngles = new Vector3(0, centerEye.transform.localEulerAngles.y, 0);
        transform.Translate(Vector3.forward * speedGO * -DpadGO.y * Time.deltaTime);
        transform.Translate(Vector3.right * speedGO * -DpadGO.x * Time.deltaTime);

        playerGO.transform.position = Vector3.Lerp(playerGO.transform.position, transform.position, 10.0f * Time.deltaTime);

        #endregion

        #region USING Oculus BACK button
        if (OVRInput.GetDown(OVRInput.Button.Two) && mainCanvas.activeInHierarchy == false)
        {
            mainCanvas.SetActive(true);
        }
        else if (OVRInput.GetDown(OVRInput.Button.Two) && mainCanvas.activeInHierarchy == true)
        {
            mainCanvas.SetActive(false);
            Debug.Log("Main Canvas closed");
        }
        #endregion


        //Touchpad down
        if (OVRInput.GetDown(OVRInput.Button.PrimaryTouchpad))
        {
            if (OnTouchpadDown != null)
                OnTouchpadDown();

        }             

        //trigger click ---> OculusGO back trigger + Xbox (LT & RT)
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) || (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger)))
        {
            if (OnTriggerClick  != null)
                OnTriggerClick();
        }
               
        // Gamepad Xbox X
        if (Input.GetButtonUp("Oculus_CrossPlatform_Button4") && mainCanvas.activeInHierarchy == false)
        {
            mainCanvas.SetActive(true);
            Debug.Log("Menu pressed!");

        }
        else if (Input.GetButtonUp("Oculus_CrossPlatform_Button4") && mainCanvas.activeInHierarchy == true)
        {
            mainCanvas.SetActive(false);
            Debug.Log("Main Canvas closed");
        }             

    }

    private OVRInput.Controller UpdateSource(OVRInput.Controller check, OVRInput.Controller previous)
    {
        // If values are the same, return
        if (check == previous)
            return previous;

        // Get controller object
        GameObject controllerObject = null;
        m_ControllerSets.TryGetValue(check, out controllerObject);

        // If no controller, set to the GAMEPAD
        if (controllerObject == null)
            controllerObject = m_HeadAnchor;

        // Send out the event
        if (OnControllerSource != null)
            OnControllerSource(check, controllerObject);

        // Return new value
        return check;
    }

    private void PlayerFound()
    {
        m_InputActive = true;
    }

    private void PlayerLost()
    {
        m_InputActive = false;
    }

    private Dictionary<OVRInput.Controller, GameObject> CreateControllerSets()
    {
        Dictionary<OVRInput.Controller, GameObject> newSets = new Dictionary<OVRInput.Controller, GameObject>()
        {
            { OVRInput.Controller.LTrackedRemote, m_LeftAnchor},
            { OVRInput.Controller.RTrackedRemote, m_RightAnchor},
            { OVRInput.Controller.Gamepad, m_HeadAnchor}
        };

        return newSets;
    }
}
