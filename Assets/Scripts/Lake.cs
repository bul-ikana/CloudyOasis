using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Lake : WaterBody
{
    public ParticleSystem steam;

    private int evaporationSize     =   0;
    private float elapsedTime       =   0f;
    private float evaporationTime   =   0f;
    private float evaporationRate   =   0f;

    void Update()
    {
        Evaporate();
    }

    // --------------------------------------------------------- //

    public void Set (float et, float er) 
    {
        evaporationTime = et;
        evaporationRate = er;
    }

    // --------------------------------------------------------- //

    private void Evaporate()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= evaporationTime) {
            elapsedTime = elapsedTime % evaporationTime;

            evaporationSize = Mathf.FloorToInt(water * evaporationRate);

            if (evaporationSize > 0) {
                steam.Play();
                Deplete(evaporationSize);
                GameSystem.Instance.cloud.Fill(evaporationSize);
            }
        } 
    }
}
