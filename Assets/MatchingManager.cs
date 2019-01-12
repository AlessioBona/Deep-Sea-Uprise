using System.Collections.Generic;
using UnityEngine;

public class MatchingManager : MonoBehaviour
{
    public static MatchingManager Instance;
    public List<Matcheable> Matcheables;

    public GameObject matchEffect;

    void Start()
    {
        Instance = this;
        if (Matcheables == null)
            Matcheables = new List<Matcheable>();
    }

    void Update()
    {
        var matcheablesArray = Matcheables.ToArray();
        for (int i = 0; i < Matcheables.Count; i++)
        {
            for (int j = i + 1; j < Matcheables.Count; j++)
            {
                var a = matcheablesArray[i];
                var b = matcheablesArray[j];
                if (a.Color != b.Color) continue;
                var distance = (a.transform.position - b.transform.position).magnitude;
                if (distance <= 1f * a.transform.localScale.magnitude)
                {
                    Match(a, b);
                }
            }
        }
    }

    private void Match(Matcheable a, Matcheable b)
    {
        GameObject obj = Instantiate(matchEffect, ((a.transform.position + b.transform.position) / 2), Quaternion.identity);
        obj.transform.position = new Vector3(obj.transform.position.x, 0, obj.transform.position.z);
        Destroy(a.gameObject);
        Destroy(b.gameObject);
        Debug.Log("Yay!");
    }
    
}
