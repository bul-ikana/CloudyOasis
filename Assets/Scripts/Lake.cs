using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Lake : WaterBody
{
    public ParticleSystem steam;
    
    void Start()
    {
        Form();
    }

    void Update()
    {
        
    }

    // --------------------------------------------------------- //

    private void Form () {
        water   = 0;
        UpdateScore();
    }

    

    // --------------------------------------------------------- //

    public void Evaporate(int size)
    {
        if (size > 0) {
            steam.Play();
            Deplete(size);
        } 
    }
}
