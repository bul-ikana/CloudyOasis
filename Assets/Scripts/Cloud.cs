using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Cloud : WaterBody
{
    public ParticleSystem rain;
    public ParticleSystem steam;

    private int dissipationSize     =   0;
    private float dissipationTime   =   0f;
    private float elapsedTime       =   -2f;

    void Update()
    {
        Dissipate();
    }

    // --------------------------------------------------------- //

    public void Set (float dt, int ds)
    {
        dissipationTime = dt;
        dissipationSize = ds;
    }


    public void Rain (int rainSize) 
    {
        rain.Play();
        Deplete(rainSize);
    }

    // --------------------------------------------------------- //

    private void Dissipate ()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= dissipationTime) {
            elapsedTime = elapsedTime % dissipationTime;
            steam.Play();
            Deplete(dissipationSize);
        }
    }
}
