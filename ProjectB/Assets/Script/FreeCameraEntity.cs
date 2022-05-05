using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeCameraEntity : MonoBehaviour
{
    [SerializeField] Camera m_Camera;
    Vector3 m_MousePosition;

    float Camera_origin_x = 29f;
    float Camera_origin_y = 233f;
    float Camera_origin_z = -3.5f;
    float m_HorizontalAngle = 0;
    float m_VerticalAngle = 0;
    float m_Scale = 0;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            m_MousePosition = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 mouseDeltaPosition = m_MousePosition - Input.mousePosition;

            m_HorizontalAngle -= mouseDeltaPosition.x * 0.1f;
            m_VerticalAngle -= mouseDeltaPosition.y * 0.1f;

            m_Camera.transform.localEulerAngles = new Vector3(Camera_origin_x - m_VerticalAngle, Camera_origin_y + m_HorizontalAngle, Camera_origin_z);

            m_MousePosition = Input.mousePosition;
        }

        m_Scale += -Input.GetAxis("Mouse ScrollWheel") * 20;
        m_Camera.fieldOfView = 65 + m_Scale;
    }
}
