
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PillSpawn : MonoBehaviour
{
    public GameObject pill;
    public PillStats pstat;

    // Start is called before the first frame update
    void Start()
    {
        pill.AddComponent<PillStats>();
        pstat = pill.GetComponent<PillStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pstat.name.Equals("blue capsule"))
        {
            GameObject bpill = pill.transform.GetChild(0).gameObject;
            bpill.SetActive(true);
            //pill.GetComponent<PillStats>().audio = "Take one blue capsule.";
        }
        if (pstat.name.Equals("red pill"))
        {
            GameObject rpill = pill.transform.GetChild(1).gameObject;
            rpill.SetActive(true);
            //pill.GetComponent<PillStats>().audio = "Take two red capsules.";
        }
    }
}
