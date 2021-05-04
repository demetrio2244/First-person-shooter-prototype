using UnityEngine;
using System.Collections;



/*
 * Manages the interpolation factor that InterpolatedTransforms use to position themselves
 * Must be attached to a single object in each scene, such as a gamecontroller.
 * It is critical this script's execution order is set before InterpolatedTransform.
 */
public class InterpolationController : MonoBehaviour
{
    private float[] m_lastFixedUpdateTimes; // Stores the last two times at which a FixedUpdate occured.
    private int m_newTimeIndex; // Keeps track of which index is storing the newest value.

   
    private static float m_interpolationFactor;
    public static float InterpolationFactor
    {
        get { return m_interpolationFactor; }
    }

    
    public void Start()
    {
        m_lastFixedUpdateTimes = new float[2];
        m_newTimeIndex = 0;
    }

   
    public void FixedUpdate()
    {
        m_newTimeIndex = OldTimeIndex(); // Set new index to the older stored time.
        m_lastFixedUpdateTimes[m_newTimeIndex] = Time.fixedTime; // Store new time.
    }

    
    public void Update()
    {
        float newerTime = m_lastFixedUpdateTimes[m_newTimeIndex];
        float olderTime = m_lastFixedUpdateTimes[OldTimeIndex()];

        if (newerTime != olderTime)
        {
            m_interpolationFactor = (Time.time - newerTime) / (newerTime - olderTime);
        }
        else
        {
            m_interpolationFactor = 1;
        }
    }

    
    private int OldTimeIndex()
    {
        return (m_newTimeIndex == 0 ? 1 : 0);
    }
}

