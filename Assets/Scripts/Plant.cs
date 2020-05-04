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

    private int phase = 0;

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

    // void start
    
    // --------------------------------------------------------- //

    public void Set(
        int p1c, int p2c, int p3c, int p4c, int p5c, int p6c,
        int p1w, int p2w, int p3w, int p4w, int p5w, int p6w,
        float p1t, float p2t, float p3t, float p4t, float p5t, float p6t
        )
    {

    }

    public void setPhase (int phase)
    {
        this.GetComponent<SpriteRenderer>().sprite = sprites[phase - 1][Random.Range(0, sprites[phase - 1].Count)];   
    }

}
