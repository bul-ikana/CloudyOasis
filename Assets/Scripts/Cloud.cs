using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class Cloud : MonoBehaviour
{
	public int water;
	public Text score;
    public float elapsed;
    public ParticleSystem steam;

    void Start()
    {
        Form();
    }

    void Update()
    {
    	Dissipate();
    }

    // --------------------------------------------------------- //

    private void Form () {
    	elapsed = 0f;
        water   = 100;
        UpdateScore();
    }

    private void Dissipate () {
        elapsed += Time.deltaTime;
        if (elapsed >= 3f) {
            steam.Play();
            elapsed = elapsed % 3f;
            water--;
            UpdateScore();
        }
    }

    private void UpdateScore () {
    	score.text = water.ToString();
    }
}
