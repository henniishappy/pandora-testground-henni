using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using System.Linq;

public class ChaosController : MonoBehaviour
{
    public VisualEffect chaos;

    [SerializeField]
    private int nucleotide = -1;

    [SerializeField]  private int[] nucCounts = new int[4];
    [SerializeField]  private Vector3[] speeds = new Vector3[4];
    [SerializeField]  private Vector3[] magnitudes = new Vector3[4];
    [SerializeField]  private Vector3[] positions = new Vector3[4];
    [SerializeField]  private float[] radia = new float[4];
   

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            speeds[i] = new Vector3(Random.Range(0.0f, 2.0f), Random.Range(0.0f, 2.0f), Random.Range(0.0f, 2.0f));
        }
    }

    // Update is called once per frame
    void Update()
    {
        setNucleotideCounts(nucleotide);
        updateNucleotideSpheres();
    }


    public void getNextNuc(int nextNuc)
    {
        nucleotide = nextNuc;
    }

    private void setNucleotideCounts(int nextNuc)
    {
        if (nextNuc >= 0)
        {
            nucCounts[nextNuc]++;

            //https://code-maze.com/csharp-sum-up-elements-of-an-array/
            chaos.SetInt("Sequence_Length", nucCounts.Sum());
            chaos.SetInt("A_Count", nucCounts[0]);
            chaos.SetInt("C_Count", nucCounts[1]);
            chaos.SetInt("G_Count", nucCounts[2]);
            chaos.SetInt("T_Count", nucCounts[3]);
        }
    }

    private void updateNucleotideSpheres()
    {
        for (int i = 0; i < 4; i++)
        {
            magnitudes[i] = setMagnitude(i);
            positions[i] = getSpherePosition(speeds[i], magnitudes[i]);
            radia[i] = getSphereRadius(i);
   
        }

        chaos.SetVector3("A_Pos", positions[0]);
        chaos.SetFloat("A_Radius", radia[0]);

        chaos.SetVector3("C_Pos", positions[1]);
        chaos.SetFloat("C_Radius", radia[1]);

        chaos.SetVector3("G_Pos", positions[2]);
        chaos.SetFloat("G_Radius", radia[2]);

        chaos.SetVector3("T_Pos", positions[3]);
        chaos.SetFloat("T_Radius", radia[3]);

    }

    private Vector3 setSpeed(int nucInd)
    {
        return new Vector3(1, 1, 1);
    }

    private Vector3 setMagnitude(int nucInd)
    {
        float mag = nucCounts[nucInd] * 0.01f;
        return new Vector3(mag, 2 * mag, mag);
    }

    private Vector3 getSpherePosition(Vector3 speed, Vector3 magnitude)
    {
        float x = Mathf.Sin(Time.time * speed.x) * magnitude.x;
        float y = Mathf.Cos(Time.time * speed.y) * magnitude.y;
        float z = Mathf.Cos(Time.time * speed.z) * magnitude.z;

        return new Vector3(x, y, z);
    }

    private float getSphereRadius(int nucInd)
    {
        float radius = (float) nucCounts[nucInd] / nucCounts.Sum();
        Debug.Log(radius.ToString());
        return radius;
    }

}
