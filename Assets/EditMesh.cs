using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EditMesh : MonoBehaviour
{

    private bool flag = true;

    private void Update()
    {
        if (flag) Destroy(gameObject);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "floor" && flag)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.red;
            gameObject.GetComponent<EditMesh>().enabled = false;

        }
    }
}
