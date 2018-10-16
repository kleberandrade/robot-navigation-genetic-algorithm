using UnityEngine;

public class Sensor : MonoBehaviour
{
    public float m_MaxRange;

    public float m_Range;

    public LayerMask m_LayerMask;

    public Color m_RayColor;

	private void FixedUpdate ()
    {
        RaycastHit hit;
		if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, m_Range, m_LayerMask)){
            m_Range = hit.distance;
        }
        else
        {
            m_Range = m_MaxRange;
        }

        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * m_Range, m_RayColor);
	}
}
