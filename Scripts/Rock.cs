using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Debug = UnityEngine.Debug;
using UnityEngine.UI;

public class Rock : MonoBehaviour
{

    private static AudioClip pickaxeHit;
    static AudioSource hitAudioSrc;

    private static AudioClip rockCrumble;
    static AudioSource crumbleAudioSrc;

    int pickaxeSwings = 0;
    public float respawnTime = 15;
    public bool hasPickaxe = true;


    // Start is called before the first frame update
    void Start()
    {
        pickaxeHit = Resources.Load<AudioClip>("pickaxeHit");
        hitAudioSrc = GetComponent<AudioSource>();

        rockCrumble = Resources.Load<AudioClip>("rockCrumble");
        crumbleAudioSrc = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (hasPickaxe)
        {
            if (pickaxeSwings < 5)
            {
                hitAudioSrc.PlayOneShot(pickaxeHit);
                pickaxeSwings++;
            }
            else if (pickaxeSwings == 5)
            {
                pickaxeSwings++;
                StartCoroutine(destroyAndRecreate());
            }
        }
    }

    IEnumerator destroyAndRecreate()
    {
        stoneWoodText stoneWoodScript = GameObject.Find("StoneWoodText").GetComponent<stoneWoodText>();
        stoneWoodScript.stone++;
        crumbleAudioSrc.PlayOneShot(rockCrumble);

        gameObject.GetComponent<Renderer>().enabled = false;

        yield return new WaitForSeconds(respawnTime);

        gameObject.GetComponent<Renderer>().enabled = true;
        pickaxeSwings = 0;
    }





}
