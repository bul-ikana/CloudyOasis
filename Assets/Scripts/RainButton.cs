using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainButton : MonoBehaviour
{
    void OnMouseUpAsButton () {
		GameSystem.Instance.Rain();
	}
}
