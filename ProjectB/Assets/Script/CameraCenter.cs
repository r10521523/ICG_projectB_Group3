using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCenter : MonoBehaviour
{
    [SerializeField] Camera[] m_Cameras = new Camera[2];

    int m_SelectedIndex = 0;

    void Start()
    {
        SelectCamera(m_SelectedIndex);
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            NextCamera();
            if (m_SelectedIndex == 0)
            {
                UIEntity.Instance.Camera.text = "<size=25><color=red>Free Camera</color></size>\n";
            }else if(m_SelectedIndex == 1)
            {
                UIEntity.Instance.Camera.text = "<size=25><color=orange>Jib Camera</color></size>\n";
            }else if (m_SelectedIndex == 2)
            {
                UIEntity.Instance.Camera.text = "<size=25><color=yellow>Hook Camera</color></size>\n";
            }
              
        }
    }

    void NextCamera()
    {
        m_SelectedIndex++;
        if (m_SelectedIndex >= m_Cameras.Length)
        {
            m_SelectedIndex = 0;
        }
        SelectCamera(m_SelectedIndex);
    }

    void SelectCamera(int index)
    {
        for (int i = 0; i < m_Cameras.Length; i++)
        {
            m_Cameras[i].enabled = i == index;

        }
    }
}
