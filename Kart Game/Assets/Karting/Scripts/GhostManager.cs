using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct GhostTransform
{
    public Vector3 position;
    public Quaternion rotation;

    public GhostTransform(Transform transform)
    {
        this.position = transform.position;
        this.rotation = transform.rotation;
    }
}


public class GhostManager : MonoBehaviour
{
    public Transform kart;
    public Transform ghostKart;

    public bool recording;
    public bool playing;

    private List<GhostTransform> recordedGhostTransforms = new List<GhostTransform>();
    private GhostTransform lastRecordedGhostTransform;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(recording == true)
        {
            if(kart.position != lastRecordedGhostTransform.position || kart.rotation != lastRecordedGhostTransform.rotation)
            {
                var newGhostTransform = new GhostTransform(kart);
                recordedGhostTransforms.Add(newGhostTransform);

                lastRecordedGhostTransform = newGhostTransform;
            }
        }

        if(playing == true)
        {
            Play();
        }
    }

    void Play()
    {
        ghostKart.gameObject.SetActive(true);
        StartCoroutine(StartGhost());
        playing = false;
    }

    IEnumerator StartGhost()
    {
        for(int i = 0; 1 < recordedGhostTransforms.Count; i++)
        {
            ghostKart.position = recordedGhostTransforms[i].position;
            ghostKart.rotation = recordedGhostTransforms[i].rotation;
            yield return new WaitForFixedUpdate();
        }
    }
}
