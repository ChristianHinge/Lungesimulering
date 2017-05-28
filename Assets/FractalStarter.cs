using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FractalStarter : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
        Generation gen = FindObjectOfType<Generation>();
        gen.generation = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
