using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.XR;
using UnityEngine.XR.ARFoundation;

/**
 * Modified ARFoundation Script from Unity for placing on flat surface
 */

[RequireComponent(typeof(ARSessionOrigin))]
public class ARFoundationplaceOnPlane : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Instantiates this prefab on a plane at the touch location.")]
    GameObject m_PlacedPrefab;
    public bool allowPlace;

    /// <summary>
    /// The prefab to instantiate on touch.
    /// </summary>
    public GameObject placedPrefab
    {
        get { return m_PlacedPrefab; }
        set { m_PlacedPrefab = value; }
    }

    /// <summary>
    /// The object instantiated as a result of a successful raycast intersection with a plane.
    /// </summary>
    //public GameObject spawnedObject { get; private set; }
    public GameObject spawnedObject;
    public bool debug;


    ARSessionOrigin m_SessionOrigin;

    static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

    void Awake()
    {
        
        m_SessionOrigin = GetComponent<ARSessionOrigin>();
    }

    private void Start()
    {
        if (!debug)
        {
            spawnedObject.SetActive(false);
        }
        else
        {
            print("start");
            NewEventManager.TriggerEvent("start");
        }
    }

    void Update()
    {
        if ((Input.touchCount > 0)&&allowPlace)
        {
            Touch touch = Input.GetTouch(0);

            if (m_SessionOrigin.Raycast(touch.position, s_Hits, TrackableType.PlaneWithinPolygon))
            {
                Pose hitPose = s_Hits[0].pose;

                if (spawnedObject == null)
                {
                    spawnedObject = Instantiate(m_PlacedPrefab, hitPose.position, hitPose.rotation);
                }
                else
                {
                    spawnedObject.transform.position = hitPose.position;
                    spawnedObject.SetActive(true);
                    GetComponent<ARPlaneManager>().enabled = false;
                    NewEventManager.TriggerEvent("start");
                }

                allowPlace = false;
            }
        }
    }

    public void allowPlaceSwap()
    {
        allowPlace = true;
    }
}
