using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Solution : MonoBehaviour
{
    [SerializeField]
    private string solutionName;

    [SerializeField]
    private Color solutionColor;

    [SerializeField]
    private Gradient burnColor;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Splint"))
        {
            other.GetComponent<MeshRenderer>().material.color = solutionColor;
            other.GetComponent<Splint>().CoverInSolution(this);
        }
    }
    public Gradient getBurnColor()
    {
        return burnColor;
    }
}
