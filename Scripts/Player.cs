using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine.EventSystems;
using UnityEngine;

using Debug = UnityEngine.Debug;

public class Player : MonoBehaviour
{
    public Interactable focus;
    public GameObject pickaxe;
    public GameObject axe;


    // Start is called before the first frame update
    void Start()
    {
        pickaxe = GameObject.FindWithTag("Pickaxe");
        axe = GameObject.FindWithTag("axe");
        axe.GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    SetFocus(interactable);
                }
            }
           
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //Switch to Pickaxe logic here
            pickaxe.GetComponent<Renderer>().enabled = true;
            axe.GetComponent<Renderer>().enabled = false;

            foreach (GameObject go in GameObject.FindGameObjectsWithTag("MiningRock"))
            {
                Rock rockScript = go.GetComponent<Rock>();
                rockScript.hasPickaxe = true;
            }

            foreach (GameObject go in GameObject.FindGameObjectsWithTag("tree"))
            {
                Tree treeScript = go.GetComponent<Tree>();
                treeScript.hasAxe = false;
            }

            Debug.Log("Button 1 pressed");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //Switch to Axe logic here
            pickaxe.GetComponent<Renderer>().enabled = false;
            axe.GetComponent<Renderer>().enabled = true;

            foreach (GameObject go in GameObject.FindGameObjectsWithTag("MiningRock"))
            {
                Rock rockScript = go.GetComponent<Rock>();
                rockScript.hasPickaxe = false;
            }

            foreach (GameObject go in GameObject.FindGameObjectsWithTag("tree"))
            {
                Tree treeScript = go.GetComponent<Tree>();
                treeScript.hasAxe = true;
            }

            Debug.Log("Button 2 pressed");
        }
    }

    void SetFocus(Interactable newFocus)
    {
        if (newFocus != focus)
        {
            if (focus != null)
                focus.OnDefocused();

            focus = newFocus;
        }
        newFocus.OnFocused(transform);
    }

    void RemoveFocus()
    {
        if(focus != null)
            focus.OnDefocused();

        focus = null;
    }
 }

