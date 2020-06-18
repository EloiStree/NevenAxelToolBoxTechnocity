using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LookingAtSomething : MonoBehaviour
{
    [SerializeField]
    Transform m_head;
    [SerializeField]
    Transform m_target;

    [SerializeField]
    float m_precisionRange;
    [SerializeField]
    LayerMask m_layerRestriction;


    [SerializeField]
    UnityEvent StartedLooking;
    [SerializeField]
    UnityEvent StoppedLooking;

    [SerializeField]
    float m_lookDuration;

    [SerializeField]
    UnityEvent LookedForDuration;

    bool m_isHitting;
    bool m_hasLookedForDuration;
    float m_currentlookDuration;

    Vector3 objectDirection;
    Quaternion localQuaternionOfObject;
    float angle;

    // check if the object is behind a wall and if not it will not trigger

    private void Update()
    {
        objectDirection = m_target.position - m_head.position;
        localQuaternionOfObject = Quaternion.LookRotation(objectDirection, m_head.up);
        float angle = Quaternion.Angle(m_head.rotation, localQuaternionOfObject);


        Debug.DrawRay(m_head.position, m_head.forward, Color.red);
        RaycastHit hit;

        if (angle < m_precisionRange && Physics.Raycast(m_head.position, objectDirection, out hit, Mathf.Infinity, m_layerRestriction) && hit.collider.gameObject == m_target.gameObject)
        {
            if (!m_isHitting)
            {
                StartedLooking.Invoke();
                // should I keep the debug or not ?
                Debug.Log("Started Looking");
            }
            m_isHitting = true;


            m_currentlookDuration = m_currentlookDuration += Time.deltaTime;
            if (m_currentlookDuration > m_lookDuration && !m_hasLookedForDuration)
            {
                m_hasLookedForDuration = true;
                LookedForDuration.Invoke();
                Debug.Log("Looked for a certain amount of time");
            }
        }
        else
        {
            Debug.DrawRay(m_head.position, m_head.forward, Color.white);
            if (m_isHitting)
            {
                StoppedLooking.Invoke();
                Debug.Log("StoppedLooking");
            }

            m_currentlookDuration = 0;
            m_isHitting = false;
            m_hasLookedForDuration = false;
        }
    }
}
