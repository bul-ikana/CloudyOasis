using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class WaterBody : MonoBehaviour
{
	public int water;
	public Text score;

    // --------------------------------------------------------- //

	protected void UpdateScore () {
        score.text = water.ToString();
    }

    // --------------------------------------------------------- //

    public void Fill (int size)
    {
        water += size;
        UpdateScore();
    }

    public void Deplete (int size)
    {
        water -= size;
        UpdateScore();
    }
}
