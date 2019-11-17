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
    }

    // Update is called once per frame
    void Update()
    {
        pill.AddComponent<PillStats>();
        if (input.Equals("blue capsule"))
        {
            //TODO: THIS IS HARDCODED.
            pill.GetComponent<PillStats>().mesh = AssetDatabase.LoadAssetAtPath<Mesh>("Assets/Models/blue_pill.fbx");
            pill.GetComponent<PillStats>().location = "bedroom";
            pill.GetComponent<PillStats>().audio = "Take one blue capsule.";
        }
        if (input.Equals("red pill"))
        {
            pill.GetComponent<PillStats>().mesh = AssetDatabase.LoadAssetAtPath<Mesh>("Assets/Models/red_pill.fbx");
            pill.GetComponent<PillStats>().location = "bedroom";
            pill.GetComponent<PillStats>().audio = "Take two red capsules.";
        }

        input = null;
    }
}
