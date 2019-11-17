using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUp : MonoBehaviour
{
    public GameObject menu;
    void Start()
    {
        menu.active = false;
    }
    public void MoveUp()
    {
        menu.active = !menu.active;
    }
}
