using DefaultNamespace;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int NeutralCount;
    public GameObject ObjectToSpawn;

    public Color ColorA;
    public Color ColorB;
    public Color ColorC;
    public int ColorACount;
    public int ColorBCount;
    public int ColorCCount;
    public float NeutralSize;
    public float ColoredSize;

    public float SpawnRadius;

    private Vector3 RandomPosition()
    {
        var vec = transform.position + Random.insideUnitCircle.ToPlaneVector3() * SpawnRadius;
        vec.y = 0;
        return vec;
       
    }
    
    void Start()
    {
        if (ObjectToSpawn==null)
            return;
        for (int i = 0; i < NeutralCount; i++)
        {
            var go = Instantiate(ObjectToSpawn, RandomPosition(), Quaternion.identity);
            go.transform.localScale = Vector3.one * NeutralSize;
        }

        for (int i = 0; i < ColorACount*2; i++)
        {
            var go = Instantiate(ObjectToSpawn, RandomPosition(), Quaternion.identity);
            go.transform.localScale = Vector3.one * ColoredSize;
            var matcheable = go.AddComponent<Matcheable>();
            matcheable.SetColor(ColorA);
        }

        for (int i = 0; i < ColorBCount*2; i++)
        {
            var go = Instantiate(ObjectToSpawn, RandomPosition(), Quaternion.identity);
            go.transform.localScale = Vector3.one * ColoredSize;
            var matcheable = go.AddComponent<Matcheable>();
            matcheable.SetColor(ColorB);
        }
        for (int i = 0; i < ColorCCount*2; i++)
        {
            var go = Instantiate(ObjectToSpawn, RandomPosition(), Quaternion.identity);
            go.transform.localScale = Vector3.one * ColoredSize;
            var matcheable = go.AddComponent<Matcheable>();
            matcheable.SetColor(ColorC);
        }

        
        gameObject.SetActive(false);
    }
}
