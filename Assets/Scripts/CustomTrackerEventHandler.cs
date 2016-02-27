/*============================================================================== 
 * Copyright (c) 2012-2014 Qualcomm Connected Experiences, Inc. All Rights Reserved. 
 * ==============================================================================*/

using UnityEngine;
using System.Collections;
using Vuforia;

public class CustomTrackerEventHandler : MonoBehaviour {

	 #region UNTIY_MONOBEHAVIOUR_METHODS


    public void Start()
    {

        VuforiaAbstractBehaviour vuforiaBehaviour = (VuforiaAbstractBehaviour)FindObjectOfType(typeof(VuforiaAbstractBehaviour));
        if (vuforiaBehaviour)
        {
            vuforiaBehaviour.RegisterVuforiaStartedCallback(OnVuforiaStarted);
        }

    }


    // Deinitialize the tracker when the Behaviour is destroyed.
    void OnDestroy()
    {
        // unregister from the VuforiaBehaviour
        VuforiaAbstractBehaviour vuforiaBehaviour = (VuforiaAbstractBehaviour)FindObjectOfType(typeof(VuforiaAbstractBehaviour));
        if (vuforiaBehaviour)
        {
            vuforiaBehaviour.UnregisterVuforiaStartedCallback(OnVuforiaStarted);
        }
    }

	#endregion UNTIY_MONOBEHAVIOUR_METHODS

    #region Vuforia_Callbacks

    public void OnVuforiaStarted()
	{
		CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
    }

    #endregion // Vuforia_Callbacks
}
