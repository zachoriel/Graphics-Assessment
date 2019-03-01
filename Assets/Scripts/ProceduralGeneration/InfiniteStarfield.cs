using UnityEngine;
using System.Collections;

public class InfiniteStarfield : MonoBehaviour
{
    Transform tx;
    ParticleSystem.Particle[] points;

    public int maxStars = 100;
    public float starSize = 1;
    public float starDistance = 10;
    public float starClipDistance = 1;
    private float starDistanceSqr;
    private float starClipDistanceSqr;

    // Use this for initialization
    void Start()
    {
        tx = base.transform;
        starDistanceSqr = starDistance * starDistance;
        starClipDistanceSqr = starClipDistance * starClipDistance;
    }

    private void CreateStars()
    {
        points = new ParticleSystem.Particle[maxStars];

        for (int i = 0; i < maxStars; i++)
        {
            points[i].position = Random.insideUnitSphere * starDistance + tx.position;
            points[i].startColor = new Color(Random.value, Random.value, Random.value, 1);
            points[i].startSize = starSize;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (points == null)
        {
            CreateStars();
        }

        for (int i = 0; i < maxStars; i++)
        {

            if ((points[i].position - tx.position).sqrMagnitude > starDistanceSqr)
            {
                points[i].position = Random.insideUnitSphere.normalized * starDistance + tx.position;
            }

            if ((points[i].position - tx.position).sqrMagnitude <= starClipDistanceSqr)
            {
                float percent = (points[i].position - tx.position).sqrMagnitude / starClipDistanceSqr;
                points[i].startColor = new Color(Random.value, Random.value, Random.value, percent);
                points[i].startSize = percent * starSize;
            }
        }
        GetComponent<ParticleSystem>().SetParticles(points, points.Length);
    }
}