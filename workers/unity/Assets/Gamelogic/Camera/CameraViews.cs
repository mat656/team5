using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraViews : MonoBehaviour {

	private float m_cameraview1;
	private float m_cameraview2;
	private float m_cameraview3;

	private Camera m_camera; 
	private string m_ChangeCameraButton;
	// Use this for initialization
	void Start () {
		m_ChangeCameraButton = "ChangeCamera";
		m_camera= GetComponent<Camera> ();

		m_cameraview1 = m_camera.fieldOfView;
		m_cameraview2 = 85;
		m_cameraview3 = 75;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetButtonDown (m_ChangeCameraButton)) {
			if (m_camera.fieldOfView == m_cameraview1) {
				m_camera.fieldOfView = m_cameraview2;
			} else if (m_camera.fieldOfView == m_cameraview2) {
				m_camera.fieldOfView = m_cameraview3;
			} else if (m_camera.fieldOfView == m_cameraview3) {
				m_camera.fieldOfView = m_cameraview1;
			}
		}
	}
}
