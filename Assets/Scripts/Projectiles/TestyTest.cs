using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestyTest : MonoBehaviour
{
    [Range(0,1.1f)]
    public float lerpTest;
    public Material mat;

    private void OnDrawGizmos()
    {
        if(mat == null)
        {
            return;
        }
        mat.SetFloat("_Threshold", lerpTest);
    }

    void Update()
    {
        if (mat == null)
        {
            mat = GetComponent<Renderer>().material;
            return;
        }
        mat.SetFloat("_Threshold", lerpTest);

        if (gameObject.tag == "TargetMats")
        {
            lerpTest = Mathf.Clamp(lerpTest, 0.3f, 1.1f);
        }
        else
        {
            lerpTest = Mathf.Clamp(lerpTest, 0.0f, 1.1f);
        }
    }
}
