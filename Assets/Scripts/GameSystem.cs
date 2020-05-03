using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour
{
    static private GameSystem m_Instance;
    static public GameSystem Instance { get { return m_Instance; } }

    private int rainSize;
    private int lakeInitSize;
    private int cloudInitSize;
    private int dissipationSize;
    private float dissipationTime;
    private float evaporationTime;
    private float evaporationRate;

    public Cloud cloud;
    public Lake lake;

    void Awake()
    {
        SetValues();
        SetObjects();
    }

    void OnDestroy()
    {
        m_Instance = null;
    }

    // --------------------------------------------------------- //

    private void SetValues ()
    {
        // CLoud
        rainSize        = 1;
        dissipationSize = 1;
        dissipationTime = 3f;
        cloudInitSize   = 100;

        // Lake
        lakeInitSize    = 0;
        evaporationTime = 5.1f;
        evaporationRate = 0.1f;
    }

    private void SetObjects ()
    {
        m_Instance  = this;

        cloud       = GameObject.Find("cloud").GetComponent<Cloud>();
        lake        = GameObject.Find("lake").GetComponent<Lake>();

        cloud.Fill(cloudInitSize);
        cloud.Set(dissipationTime, dissipationSize);

        lake.Fill(lakeInitSize);
        lake.Set(evaporationTime, evaporationRate);
    }



    // --------------------------------------------------------- //
    public void Rain()
    {
        cloud.Rain(rainSize);
        lake.Fill(rainSize);
    }
}
