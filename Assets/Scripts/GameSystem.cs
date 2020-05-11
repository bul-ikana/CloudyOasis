using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour
{
    static private GameSystem m_Instance;
    static public GameSystem Instance { get { return m_Instance; } }

    private int index;

    public GameObject canvas;

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

    void Update () 
    {
        if (cloud.water == 0) {
            canvas.gameObject.SetActive(false);
            Time.timeScale = 0;
        }

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
        plant2cost = 20;
        plant3cost = 60;
        plant4cost = 240;
        plant5cost = 10000;
        plant6cost = 100000;

        plant1time = 1f;
        plant2time = 10f;
        plant3time = 100f;
        plant4time = 1000f;
        plant5time = 10000f;
        plant6time = 100000f;

        plant1water = 1;
        plant2water = 20;
        plant3water = 300;
        plant4water = 4000;
        plant5water = 50000;
        plant6water = 600000;
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

        plant1.Set(0, 0, 0f);
        plant2.Set(0, 0, 0f);
        plant3.Set(0, 0, 0f);
        plant4.Set(0, 0, 0f);
        plant5.Set(0, 0, 0f);
        plant6.Set(0, 0, 0f);

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
        if (lake.water >= plant1cost && phase0.Count > 0) {
            index = Random.Range(0, phase0.Count);
            phase0[index].Set(1, plant1water, plant1time);
            phase1.Add(phase0[index]);
            phase0.RemoveAt(index);
            lake.Deplete(plant1cost);
        }
    }

    public void Plant2 ()
    {
        if (lake.water >= plant2cost && phase1.Count > 0) {
            index = Random.Range(0, phase1.Count);
            phase1[index].Set(2, plant2water, plant2time);
            phase2.Add(phase1[index]);
            phase1.RemoveAt(index);
            lake.Deplete(plant2cost);
        }
    }

    public void Plant3 ()
    {
        if (lake.water >= plant3cost && phase2.Count > 0) {
            index = Random.Range(0, phase2.Count);
            phase2[index].Set(3, plant3water, plant3time);
            phase3.Add(phase2[index]);
            phase2.RemoveAt(index);
            lake.Deplete(plant3cost);
        }
    }

    public void Plant4 ()
    {
        if (lake.water >= plant4cost && phase3.Count > 0) {
            index = Random.Range(0, phase3.Count);
            phase3[index].Set(4, plant4water, plant4time);
            phase4.Add(phase3[index]);
            phase3.RemoveAt(index);
            lake.Deplete(plant4cost);
        }
    }

    public void Plant5 ()
    {
        if (lake.water >= plant5cost && phase4.Count > 0) {
            index = Random.Range(0, phase4.Count);
            phase4[index].Set(5, plant5water, plant5time);
            phase5.Add(phase4[index]);
            phase4.RemoveAt(index);
            lake.Deplete(plant5cost);
        }
    }

    public void Plant6 ()
    {
        if (lake.water >= plant6cost && phase5.Count > 0) {
            index = Random.Range(0, phase5.Count);
            phase5[index].Set(6, plant6water, plant6time);
            phase5.RemoveAt(index);
            lake.Deplete(plant6cost);
        }
    }
}
