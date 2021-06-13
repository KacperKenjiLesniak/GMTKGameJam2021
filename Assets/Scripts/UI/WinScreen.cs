using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreen : MonoBehaviour
{
    void Start()
    {
        MusicManager.instance.PlayClip(0);
    }
}
