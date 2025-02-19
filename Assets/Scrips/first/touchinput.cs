using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.InputSystem;

public class touchinput : MonoBehaviour
{
    [SerializeField] private TMP_Text debugtext;
    [SerializeField] private GameObject ballprefab;
    private ARRaycastManager arrcm;

    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    TrackableType trackableTypes = TrackableType.PlaneWithinPolygon;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void SingleTap(InputAction.CallbackContext ctx)
    {

        if (ctx.phase == InputActionPhase.Performed)
        {

            var touchPos = ctx.ReadValue<Vector2>();
            debugtext.text = touchPos.ToString();

            if(arrcm.Raycast(touchPos, hits, trackableTypes))
            {
                var ball = Instantiate(ballprefab, hits[0].pose.position, new Quaternion());
            }
        }
    }
    private void Start()
    {
        arrcm = GetComponent<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
