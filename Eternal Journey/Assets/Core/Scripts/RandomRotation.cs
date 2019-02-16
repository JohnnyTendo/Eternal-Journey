using UnityEngine;

public class RandomRotation : MonoBehaviour
{

    public bool[] xyzRandom = new bool[3];
    float[] rotation = { 0f, 0f, 0f };
    
    void Start()
    {
        for (int i = 0; i < rotation.Length; i++)
        {
            if (xyzRandom[i])
            {
                rotation[i] = Random.Range(0f, 360f);
                //Debug.Log(this.name + " has rotated along Axis#" + i + " by " + rotation[i] + "°");
            }
        }
        gameObject.transform.rotation *= Quaternion.Euler(rotation[0], rotation[1], rotation[2]);
    }
}
