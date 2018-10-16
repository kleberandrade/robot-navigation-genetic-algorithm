using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    public GameObject m_RobotPrefab;

    private RespawnPoint[] m_RespawnPoints;

    private List<DifferentialWheeledRobot> m_Robots;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }

    private void Start ()
    {
        m_RespawnPoints = FindObjectsOfType<RespawnPoint>();

        InitializeRobotPositions();
    }

    private void InitializeRobotPositions()
    {
        if (m_Robots == null)
        {
            m_Robots = new List<DifferentialWheeledRobot>();
            for (int i = 0; i < m_RespawnPoints.Length; i++)
            {
                GameObject robot = Instantiate<GameObject>(m_RobotPrefab, m_RespawnPoints[i].transform.position, m_RespawnPoints[i].transform.rotation);
                m_Robots.Add(robot.GetComponent<DifferentialWheeledRobot>());
            }
        }
        else
        {
            for (int i = 0; i < m_Robots.Count; i++)
            {
                m_Robots[i].transform.position = m_RespawnPoints[i].transform.position;
            }
        }
    }
	
	void Update () {
		
	}
}
