using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalScript : MonoBehaviour
{

    public GameObject player;
    bool selected;
    static int numActive;

    MeshRenderer rend;
    GameObject child;
    BoxCollider coll;

    // Use this for initialization
    void Start()
    {
        rend= gameObject.GetComponent<MeshRenderer>();
        //child = transform.GetChild(0).gameObject;
        coll = gameObject.GetComponent<BoxCollider>();
        player = GameObject.FindGameObjectWithTag("Player");
        
        if (gameObject.tag!="Finish")
        {
            //child.SetActive(false);
            rend.enabled = false;
            coll.enabled = false;
            //StartCoroutine("PortalHide");
        }
    }

    IEnumerator PortalHide()
    {
            yield return new WaitForSeconds(Random.Range(15, 25));
        //child.SetActive(false);
        rend.enabled = false;
        coll.enabled = false;
        print("portal hide");
        //StartCoroutine("showPortalNew");
    }

    IEnumerator showPortalNew()
    {
        yield return new WaitForSeconds(Random.Range(15, 25));
        StopCoroutine("PortalHide");
        //child.SetActive(true);
        rend.enabled = true;
        coll.enabled = true;
        //StartCoroutine("PortalHide");
    }

    public void showPortal()
    {
        print("portal Show");
        StopCoroutine("PortalHide");
        //child.SetActive(true);
        rend.enabled = true;
        coll.enabled = true;
        StartCoroutine("PortalHide");
    }



    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        //print("name "+gameObject.name+Vector3.Distance(transform.position, player.transform.position));
        if (Vector3.Distance(transform.position, player.transform.position) < 0.15f)
        {
            player.GetComponent<GhostScript>().target = transform;
            
        }
        //Application.LoadLevel(0);
    }

  

}
