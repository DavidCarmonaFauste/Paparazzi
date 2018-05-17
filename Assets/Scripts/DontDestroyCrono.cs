using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyCrono : MonoBehaviour {

    public static DontDestroyCrono instance = null;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else Destroy(this.gameObject);
    }
}
