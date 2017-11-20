using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPtext : MonoBehaviour {
    public Text HP_int;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        HP_int.text = "HP : " + PlayerCllider.HP;

    }
}
