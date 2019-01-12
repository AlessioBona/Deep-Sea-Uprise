using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matcheable : MonoBehaviour
{
    public Color Color;

    void Start()
    {
        MatchingManager.Instance.Matcheables.Add(this);
    }

    public void SetColor(Color color)
    {
        Color = color;
        GetComponent<Renderer>().material.color = color;
    }
    
    private void OnDestroy()
    {
        MatchingManager.Instance.Matcheables.Remove(this);
    }
}
