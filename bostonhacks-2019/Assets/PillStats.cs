using UnityEngine;
using System.Collections;

public class PillStats : MonoBehaviour
{
    public string name;
    public GameObject camera;
    public GameObject pill;
    public Vector3 location;
    public AudioSource audios;
    void Start()
    {
        camera = GameObject.Find("Main Camera");
        audios = pill.GetComponent<AudioSource>();
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
    public void SetAudioOne()
    {
        audios.clip = Resources.Load<AudioClip>("chimes");
    }
    public void SetAudioTwo()
    {
        audios.clip = Resources.Load<AudioClip>("glitter");
    }
}
