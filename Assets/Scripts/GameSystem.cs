using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour
{
    static private GameSystem m_Instance;
    static public GameSystem Instance { get { return m_Instance; } }

    private int rainSize;
    private int dissipationSize;
    private float dissipationTime;
    private float evaporationTime;
    private float evaporationRate;

    private int evaporationSize = 0;
    private float elapsedDissipationTime = 0f;
    private float elapsedEvaporationTime = 0f;

    private Cloud cloud;
    private Lake lake;

    void Awake()
    {
        SetValues();
        SetObjects();
    }

    void OnDestroy()
    {
        m_Instance = null;
    }

    void Update()
    {
        DissipateCloud();
        EvaporateLake();
    }

    // --------------------------------------------------------- //

    private void SetValues ()
    {
        rainSize        = 1;
        dissipationSize = 1;
        dissipationTime = 3f;
        evaporationTime = 5.1f;
        evaporationRate = 0.1f;
    }

    private void SetObjects ()
    {
        m_Instance  = this;
        cloud       = GameObject.Find("cloud").GetComponent<Cloud>();
        lake        = GameObject.Find("lake").GetComponent<Lake>();
    }

    private void DissipateCloud()
    {
        elapsedDissipationTime += Time.deltaTime;
        if (elapsedDissipationTime >= dissipationTime) {
            elapsedDissipationTime = elapsedDissipationTime % dissipationTime;
            cloud.Dissipate(dissipationSize);
        }
    }

    private void EvaporateLake()
    {
        elapsedEvaporationTime += Time.deltaTime;
        if (elapsedEvaporationTime >= evaporationTime) {
            elapsedEvaporationTime = elapsedEvaporationTime % evaporationTime;

            evaporationSize = Mathf.FloorToInt(lake.water * evaporationRate);
            lake.Evaporate(evaporationSize);
            cloud.Fill(evaporationSize);
        }
    }

    // --------------------------------------------------------- //
    public void Rain()
    {
        cloud.Rain(rainSize);
        lake.Fill(rainSize);
    }
}
