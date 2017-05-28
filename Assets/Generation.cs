using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generation : MonoBehaviour {
    [SerializeField]
    GameObject generationObject;
    [SerializeField]
    Transform center;
    public int generation = 0;
    public int haeldning = 10;

    void Start()
    {
        transform.localRotation = Quaternion.Euler(new Vector3(haeldning, 0, 0));
        Debug.Log(center.localPosition);
        if (generation == 0)
            throw new UnityException();
        else if (generation >= 2)
            return;
        Generation nextGen = Instantiate(generationObject, center.position, Quaternion.identity,transform).GetComponent<Generation>();
        nextGen.generation = generation + 1;
        nextGen.haeldning = 10;

        nextGen = Instantiate(generationObject, center.position, Quaternion.identity, transform).GetComponent<Generation>();
        nextGen.generation = generation + 1;
        nextGen.haeldning = -10;
    }

}
