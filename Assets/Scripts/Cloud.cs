using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Cloud : WaterBody
{
    public ParticleSystem rain;
    public ParticleSystem steam;

    void Start()
    {
        Form();
    }

    void Update()
    {

    }

    // --------------------------------------------------------- //

    private void Form ()
    {
        water = 100;
        UpdateScore();
    }

    // --------------------------------------------------------- //

    public void Dissipate (int size)
    {
        steam.Play();
        Deplete(size);
    }

    public void Rain (int rainSize) 
    {
        rain.Play();
        Deplete(rainSize);
    }
}
