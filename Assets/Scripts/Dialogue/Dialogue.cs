using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    // Not really used at the moment. Just in case I want to add more NPCs
    public string name;

    // For custom dialogue boxes (see inspector)
    [TextArea(3, 10)]
    public string[] sentences;
}
