using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tier3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        stoneWoodText stoneWoodScript = GameObject.Find("StoneWoodText").GetComponent<stoneWoodText>();
        if (stoneWoodScript.tier3Spawned)
        {
            gameObject.GetComponent<Renderer>().enabled = true;
            gameObject.GetComponent<BoxCollider>().enabled = true;
            stoneWoodScript.tier2Spawned = false;
        }
        else if (gameObject.GetComponent<Renderer>().enabled == true)
        {
            gameObject.GetComponent<Renderer>().enabled = false;
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
