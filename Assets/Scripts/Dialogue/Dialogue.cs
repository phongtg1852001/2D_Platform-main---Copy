using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public string npcName;
    [TextArea(3, 10)]
    public string[] sentences;
}
