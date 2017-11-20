using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCllider : MonoBehaviour {
    public static int HP;

	// Use this for initialization
	void Start () {
        HP = 10;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
}
