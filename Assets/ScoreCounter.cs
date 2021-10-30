using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public int Score;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cow")
        {
            Score++;
            print(Score);
        }
    }
}
