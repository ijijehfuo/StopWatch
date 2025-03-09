using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brain : MonoBehaviour
{
    private void Awake()
    {
        gameObject.BroadcastMessage("CallMyName", 12);
    }
}
