using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class body : MonoBehaviour
{
    public string Name;

    public void CallMyName()
    {
        Name = gameObject.name;
        Debug.Log($"Hello, my name is {Name}");
    }
}
