using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimitivesPicker : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject m_ClickedObject;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FireRaycast();
        }
        if (Input.GetMouseButtonUp(0))
        {
            RecoverClickedObject();
        }
       
}
    void FireRaycast()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            SkinnedMeshRenderer renderer = hit.collider.GetComponent<SkinnedMeshRenderer>();
            if (renderer != null)
            {
                renderer.material.color = Color.green;
                m_ClickedObject = hit.collider.gameObject;
            }
        }
    }
    void RecoverClickedObject()
    {
        if (m_ClickedObject != null)
        {
            m_ClickedObject.GetComponent<SkinnedMeshRenderer>().material.color = Color.black;
            m_ClickedObject.GetComponent<WalkingPath>().enabled = false;
            m_ClickedObject = null;
        }
    }
}
