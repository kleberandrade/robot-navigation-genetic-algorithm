using UnityEngine;

public class RespawnPoint : MonoBehaviour
{
    private static readonly float m_Radius = 6.0f;

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1.0f, 0.0f, 0.0f, 0.25f);
        Gizmos.DrawSphere(transform.position + Vector3.down * (m_Radius * 0.5f), m_Radius);            
    }
}
