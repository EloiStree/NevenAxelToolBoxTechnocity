using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public int m_myAge;

    public int getAgeOfUser() { return m_myAge; }
    public void setAgeOfUser(int ageValue) { m_myAge = ageValue; }

    private void Update()
    {
        
    }

    private Rotate m_target;
}
