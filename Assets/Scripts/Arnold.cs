using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arnold : MonoBehaviour {
    bool face = true;

    void Start()
	{
        InvokeRepeating("ShowFace", 2.0f, 1.0f);
    }

    public bool IsFace()
    {
        return face;
    }

    public void ShowFace()
    {
        face = !face;
    }
}
