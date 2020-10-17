using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Dialogue
{
    public string name;
    //place emotions here
    public GameObject[] emotions;

    [TextArea(3, 10)]
    public string[] sentences;
}
