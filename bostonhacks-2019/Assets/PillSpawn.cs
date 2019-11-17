using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PillSpawn : MonoBehaviour
{
    public string input;
    public GameObject pill;
    // Start is called before the first frame update
    void Start()
    {
        input = "red pill";
    }

    // Update is called once per frame
    void Update()
    {
        if (input.Equals("blue capsule"))
        {
            //TODO: THIS IS HARDCODED.
            GameObject bpill = pill.transform.GetChild(0).gameObject;
            bpill.SetActive(true);
            //pill.GetComponent<PillStats>().audio = "Take one blue capsule.";
        }
        if (input.Equals("red pill"))
        {
            GameObject rpill = pill.transform.GetChild(1).gameObject;
            rpill.SetActive(true);
            //pill.GetComponent<PillStats>().audio = "Take two red capsules.";
        }
        input = null;
    }
}
