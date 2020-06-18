using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetIsObservedWithVirtualRealityTag : MonoBehaviour
{
    public IsObserved linkedScript;
    bool foundHead;

    private void Start()
    {
        if (linkedScript.m_head == null)
        {
            VirtualRealityTags.GetClassicVrTag(VirtualRealityClassicTags.EyesCenter, out foundHead, out linkedScript.m_head);
        }
    }

    private void Update()
    {
        if(linkedScript.m_head == null)
        {
            VirtualRealityTags.GetClassicVrTag(VirtualRealityClassicTags.EyesCenter, out foundHead, out linkedScript.m_head);
        }
    }
}
