using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour
{
    static private GameSystem m_Instance;
    static public GameSystem Instance { get { return m_Instance; } }

    // Cloud
    private int rainSize;
    private int cloudInitSize;
    private int dissipationSize;
    private float dissipationTime;

    // Lake
    private int lakeInitSize;
    private float evaporationTime;
    private float evaporationRate;

    // Plants
    private int plant1cost;
    private int plant2cost;
    private int plant3cost;
    private int plant4cost;
    private int plant5cost;
    private int plant6cost;

    private int plant1water;
    private int plant2water;
    private int plant3water;
    private int plant4water;
    private int plant5water;
    private int plant6water;

    private float plant1time;
    private float plant2time;
    private float plant3time;
    private float plant4time;
    private float plant5time;
    private float plant6time;

    private List<Plant> phase0;
    private List<Plant> phase1;
    private List<Plant> phase2;
    private List<Plant> phase3;
    private List<Plant> phase4;
    private List<Plant> phase5;
    private List<Plant> phase6;

    public Lake lake;
    public Cloud cloud;
    public Plant plant1;
    public Plant plant2;
    public Plant plant3;
    public Plant plant4;
    public Plant plant5;
    public Plant plant6;
    private Plant tempPlant;

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

        // Plants
        plant1cost = 10;
        plant2cost = 100;
        plant3cost = 1000;
        plant4cost = 10000;
        plant5cost = 100000;
        plant6cost = 1000000;

        plant1time = 10f;
        plant2time = 100f;
        plant3time = 1000f;
        plant4time = 10000f;
        plant5time = 100000f;
        plant6time = 1000000f;

        plant1water = 10;
        plant2water = 100;
        plant3water = 1000;
        plant4water = 10000;
        plant5water = 100000;
        plant6water = 1000000;
    }

    private void SetObjects ()
    {
        m_Instance  = this;

        cloud       = GameObject.Find("cloud").GetComponent<Cloud>();
        lake        = GameObject.Find("lake").GetComponent<Lake>();

        plant1      = GameObject.Find("plant1").GetComponent<Plant>();
        plant2      = GameObject.Find("plant2").GetComponent<Plant>();
        plant3      = GameObject.Find("plant3").GetComponent<Plant>();
        plant4      = GameObject.Find("plant4").GetComponent<Plant>();
        plant5      = GameObject.Find("plant5").GetComponent<Plant>();
        plant6      = GameObject.Find("plant6").GetComponent<Plant>();

        cloud.Fill(cloudInitSize);
        cloud.Set(dissipationTime, dissipationSize);

        lake.Fill(lakeInitSize);
        lake.Set(evaporationTime, evaporationRate);

        plant1.Set(
            plant1cost, plant2cost, plant3cost, plant4cost, plant5cost, plant6cost,
            plant1water, plant2water, plant3water, plant4water, plant5water, plant6water,
            plant1time, plant2time, plant3time, plant4time, plant5time, plant6time
        );

        plant2.Set(
            plant1cost, plant2cost, plant3cost, plant4cost, plant5cost, plant6cost,
            plant1water, plant2water, plant3water, plant4water, plant5water, plant6water,
            plant1time, plant2time, plant3time, plant4time, plant5time, plant6time
        );

        plant3.Set(
            plant1cost, plant2cost, plant3cost, plant4cost, plant5cost, plant6cost,
            plant1water, plant2water, plant3water, plant4water, plant5water, plant6water,
            plant1time, plant2time, plant3time, plant4time, plant5time, plant6time
        );

        plant4.Set(
            plant1cost, plant2cost, plant3cost, plant4cost, plant5cost, plant6cost,
            plant1water, plant2water, plant3water, plant4water, plant5water, plant6water,
            plant1time, plant2time, plant3time, plant4time, plant5time, plant6time
        );

        plant5.Set(
            plant1cost, plant2cost, plant3cost, plant4cost, plant5cost, plant6cost,
            plant1water, plant2water, plant3water, plant4water, plant5water, plant6water,
            plant1time, plant2time, plant3time, plant4time, plant5time, plant6time
        );

        plant6.Set(
            plant1cost, plant2cost, plant3cost, plant4cost, plant5cost, plant6cost,
            plant1water, plant2water, plant3water, plant4water, plant5water, plant6water,
            plant1time, plant2time, plant3time, plant4time, plant5time, plant6time
        );

        phase0 = new List<Plant>();
        phase1 = new List<Plant>();
        phase2 = new List<Plant>();
        phase3 = new List<Plant>();
        phase4 = new List<Plant>();
        phase5 = new List<Plant>();

        phase0.Add(plant1);
        phase0.Add(plant2);
        phase0.Add(plant3);
        phase0.Add(plant4);
        phase0.Add(plant5);
        phase0.Add(plant6);
    }



    // --------------------------------------------------------- //
    public void Rain()
    {
        cloud.Rain(rainSize);
        lake.Fill(rainSize);
    }

    public void Plant1 ()
    {   
        int index = Random.Range(0, phase0.Count);
        tempPlant = phase0[index];
        tempPlant.setPhase(1);
        phase0.RemoveAt(index);
        phase1.Add(tempPlant);
    }

    public void Plant2 ()
    {
        int index = Random.Range(0, phase1.Count);
        tempPlant = phase1[index];
        tempPlant.setPhase(2);
        phase1.RemoveAt(index);
        phase2.Add(tempPlant);
    }

    public void Plant3 ()
    {
        int index = Random.Range(0, phase2.Count);
        tempPlant = phase2[index];
        tempPlant.setPhase(3);
        phase2.RemoveAt(index);
        phase3.Add(tempPlant);
    }

    public void Plant4 ()
    {
        int index = Random.Range(0, phase3.Count);
        tempPlant = phase3[index];
        tempPlant.setPhase(4);
        phase3.RemoveAt(index);
        phase4.Add(tempPlant);
    }

    public void Plant5 ()
    {
        int index = Random.Range(0, phase4.Count);
        tempPlant = phase4[index];
        tempPlant.setPhase(5);
        phase4.RemoveAt(index);
        phase5.Add(tempPlant);
    }

    public void Plant6 ()
    {
        int index = Random.Range(0, phase5.Count);
        tempPlant = phase5[index];
        tempPlant.setPhase(6);
        phase5.RemoveAt(index);
    }
}
