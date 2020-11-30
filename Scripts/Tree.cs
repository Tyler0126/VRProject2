using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Debug = UnityEngine.Debug;
using UnityEngine.UI;

public class Tree : MonoBehaviour
{
    private static AudioClip axeHit;
    static AudioSource axeHitAudiosrc;

    private static AudioClip treeChop;
    static AudioSource chopAudiosrc;

    int axeSwings = 0;
    public float respawnTime = 15;
    public bool hasAxe = false;

    // Start is called before the first frame update
    void Start()
    {
        axeHit = Resources.Load<AudioClip>("axeHit");
        axeHitAudiosrc = GetComponent<AudioSource>();

        treeChop = Resources.Load<AudioClip>("treeChop");
        chopAudiosrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (hasAxe)
        {
            if (axeSwings < 5)
            {
                axeHitAudiosrc.PlayOneShot(axeHit);
                axeSwings++;
            }
            else if (axeSwings == 5)
            {
                axeSwings++;
                StartCoroutine(destroyAndRecreate());
            }
        }
    }

    IEnumerator destroyAndRecreate()
    {
        stoneWoodText stoneWoodScript = GameObject.Find("StoneWoodText").GetComponent<stoneWoodText>();
        stoneWoodScript.wood++;
        chopAudiosrc.PlayOneShot(treeChop);

        gameObject.GetComponent<Renderer>().enabled = false;

        yield return new WaitForSeconds(respawnTime);

        gameObject.GetComponent<Renderer>().enabled = true;
        axeSwings = 0;
    }
}
