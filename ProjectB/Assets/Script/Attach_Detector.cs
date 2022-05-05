using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attach_Detector : MonoBehaviour
{
    const float ATTACH_DISTANCE = 3f;
    GameObject m_DetectedObject;

    ConfigurableJoint m_JointForObject;
    [SerializeField] LineRenderer m_Cable;

    void Update()
    {
        if(m_JointForObject == null)
            DetectObject();

        if (Input.GetKeyDown(KeyCode.Space))
            AttachOrDetachObject();
        UpdateCable();
    }

    void DetectObject()
    {
        Ray ray = new Ray(this.transform.position, Vector3.down);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, ATTACH_DISTANCE))
        {
            if (m_DetectedObject == hit.collider.gameObject)
                return;

            RecoverDetectedObject();

            if(hit.collider.tag == "Pig")
            {
                SkinnedMeshRenderer renderer = hit.collider.GetComponent<SkinnedMeshRenderer>();
                if (renderer != null)
                {
                    renderer.material.color = Color.blue;

                    m_DetectedObject = hit.collider.gameObject;
                }
            }
        }
        else
        {
            RecoverDetectedObject();
        }
    }

    void RecoverDetectedObject()
    {
        if (m_DetectedObject != null)
        {
            if(m_DetectedObject.GetComponent<WalkingPath>().enabled == true)
            {
                m_DetectedObject.GetComponent<SkinnedMeshRenderer>().material.color = Color.white;
            }
            else
            {
                m_DetectedObject.GetComponent<SkinnedMeshRenderer>().material.color = Color.black;
            }     
            m_DetectedObject = null;
        }
    }

    void AttachOrDetachObject()
    {
        if (m_JointForObject == null)
        {
            if (m_DetectedObject != null)
            {
                var joint = this.gameObject.AddComponent<ConfigurableJoint>();
                joint.xMotion = ConfigurableJointMotion.Limited;
                joint.yMotion = ConfigurableJointMotion.Limited;
                joint.zMotion = ConfigurableJointMotion.Limited;
                joint.angularXMotion = ConfigurableJointMotion.Free;
                joint.angularYMotion = ConfigurableJointMotion.Free;
                joint.angularZMotion = ConfigurableJointMotion.Free;

                var limit = joint.linearLimit;
                limit.limit = 3.0f;

                joint.linearLimit = limit;

                joint.autoConfigureConnectedAnchor = false;
                joint.connectedAnchor = new Vector3(0f, 0.5f, 0f);
                joint.anchor = new Vector3(0f, 0f, 0f);

                joint.connectedBody = m_DetectedObject.GetComponent<Rigidbody>();
                m_DetectedObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

                m_JointForObject = joint;

                m_DetectedObject.GetComponent<SkinnedMeshRenderer>().material.color = Color.red;
            }

        }
        else
        {
            m_DetectedObject.GetComponent<SkinnedMeshRenderer>().material.color = Color.black;
            m_DetectedObject.GetComponent<WalkingPath>().enabled = false;
            m_DetectedObject = null;
            GameObject.Destroy(m_JointForObject);
            m_JointForObject = null;
        }
    }

    void UpdateCable()
    {
        m_Cable.enabled = m_JointForObject != null;

        if (m_Cable.enabled)
        {
            m_Cable.SetPosition(0, this.transform.position);
            m_Cable.SetPosition(1, m_JointForObject.connectedBody.transform.position);
        }
    }
}