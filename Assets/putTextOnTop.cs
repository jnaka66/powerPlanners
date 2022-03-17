using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class putTextOnTop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        renderer.sortingOrder = 2;
    }
}
