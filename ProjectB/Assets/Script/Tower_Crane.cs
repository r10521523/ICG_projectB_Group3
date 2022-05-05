using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Crane : MonoBehaviour
{
    const float TROLLEY_FORWARD_LIMIT = -0.17f;
    const float TROLLEY_BACKWARD_LIMIT = -0.01f;
    const float TROLLEY_MOVE_SPEED = 4f;
    const float HOOK_HEIGHT_LIMIT = -0.003f;
    const float HOOK_DEEP_LIMIT = -0.1f;
    const float HOOK_MOVE_SPEED = 5f;
    const float JIB_ROTATE_SPEED = 30f;
    const float TOWER_CRANE_MOVE_SPEED = 3f;

    [SerializeField] GameObject m_Tower_crane;
    [SerializeField] GameObject m_Jib;
    [SerializeField] GameObject m_Trolley;
    [SerializeField] GameObject m_Hook;
    [SerializeField] LineRenderer m_Joint;

    void Update()
    {
        if (UIEntity.IsPlaying)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                if (m_Hook.transform.localPosition.z < HOOK_HEIGHT_LIMIT)
                    m_Hook.transform.Translate(0, 0, HOOK_MOVE_SPEED * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.E))
            {
                if (m_Hook.transform.localPosition.z > HOOK_DEEP_LIMIT)
                    m_Hook.transform.Translate(0, 0, -HOOK_MOVE_SPEED * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                if (m_Trolley.transform.localPosition.y > TROLLEY_FORWARD_LIMIT)
                    m_Trolley.transform.Translate(0, -TROLLEY_MOVE_SPEED * Time.deltaTime, 0);
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                if (m_Trolley.transform.localPosition.y < TROLLEY_BACKWARD_LIMIT)
                    m_Trolley.transform.Translate(0, TROLLEY_MOVE_SPEED * Time.deltaTime, 0);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                m_Jib.transform.Rotate(-Vector3.forward * JIB_ROTATE_SPEED * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                m_Jib.transform.Rotate(Vector3.forward * JIB_ROTATE_SPEED * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.W))
            {
                m_Tower_crane.transform.Translate(0, 0, TOWER_CRANE_MOVE_SPEED * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                m_Tower_crane.transform.Translate(0, 0, -TOWER_CRANE_MOVE_SPEED * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.A))
            {
                m_Tower_crane.transform.Translate(-TOWER_CRANE_MOVE_SPEED * Time.deltaTime, 0, 0);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                m_Tower_crane.transform.Translate(TOWER_CRANE_MOVE_SPEED * Time.deltaTime, 0, 0);
            }
        }
        
        m_Joint.enabled = true;
        UpdateCable();
    }

    void UpdateCable()
    {
        m_Joint.SetPosition(0, m_Trolley.transform.position);
        m_Joint.SetPosition(1, m_Hook.transform.position);
    }
}
