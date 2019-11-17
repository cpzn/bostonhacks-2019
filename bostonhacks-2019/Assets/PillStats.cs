using UnityEngine;
using System.Collections;

public class PillStats : MonoBehaviour
{
    public string name;
    public GameObject camera;
    public Vector3 location;
    void Start()
    {
        camera = GameObject.Find("Main Camera");
        int roll = Random.Range(1, 3);
        if (roll == 1)
        {
            name = "blue capsule";
            location = camera.transform.position + new Vector3(1, 5, 45);
            transform.position = location;
        }
        if (roll == 2)
        {
            name = "red pill";
            location = camera.transform.position + new Vector3(4, 5, 45);
            transform.position = location;
        }
    }
}
