using UnityEngine;
using TMPro;
using UnityEngine.XR.ARFoundation;

public class cookie : MonoBehaviour
{
    [SerializeField] private TMP_Text cookieText;
    [SerializeField] private ARCameraManager arcm;
    [SerializeField] private ARTrackedImageManager artim;
    private int cookieCount = 5; // For test purposes start with more cookies

    public void SwitchCamera()
    {
        if (arcm.currentFacingDirection == CameraFacingDirection.World)
        {
            arcm.requestedFacingDirection = CameraFacingDirection.User;
            //arsess.Reset(); //Reset AR Session to avoid crashing between changing cameras
        }
        else if (arcm.currentFacingDirection == CameraFacingDirection.User)
        {
            arcm.requestedFacingDirection = CameraFacingDirection.World;
            //arsess.Reset(); //Reset AR Session to avoid crashing between changing cameras
        }

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public void OnTrackablesChanged(ARTrackablesChangedEventArgs<ARTrackedImage> eventArgs)
    {
        foreach (var newImage in eventArgs.added)
        {
            cookieCount += 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        cookieText.text = ("Cookies: " + cookieCount);

    }
}
