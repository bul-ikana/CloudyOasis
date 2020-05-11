using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    public List<List<Sprite>> sprites;
    public List<Sprite> phase1Sprites;
    public List<Sprite> phase2Sprites;
    public List<Sprite> phase3Sprites;
    public List<Sprite> phase4Sprites;
    public List<Sprite> phase5Sprites;
    public List<Sprite> phase6Sprites;

    private int plantWater      =   0;
    private float plantTime     =   0f;
    private float elapsedTime;

    private bool log = false;

    void Start ()
    {
        sprites = new List<List<Sprite>>();
        sprites.Add(phase1Sprites);
        sprites.Add(phase2Sprites);
        sprites.Add(phase3Sprites);
        sprites.Add(phase4Sprites);
        sprites.Add(phase5Sprites);
        sprites.Add(phase6Sprites);
        this.GetComponent<SpriteRenderer>().sprite = null;
    }

    void Update ()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= plantTime) {
            elapsedTime = elapsedTime % plantTime;
                GameSystem.Instance.lake.Fill(plantWater);
        } 
    }
    
    // --------------------------------------------------------- //

    public void Set(int phase, int pw, float pt)
    {
        elapsedTime = 0f;
        plantWater = pw;
        plantTime = pt;

        if (phase > 0) {
            this.GetComponent<SpriteRenderer>().sprite = sprites[phase - 1][Random.Range(0, sprites[phase - 1].Count)];   
        }
    }
}
