using UnityEngine;

public class BackgroundStretch : MonoBehaviour
{
    // Reference to the Transform component of the background object
    private Transform backgroundTransform;

    private void Awake()
    {
        // Get the Transform component of the background object
        backgroundTransform = GetComponent<Transform>();

        // print size of width and height of screen
        Debug.Log(Screen.width);
        Debug.Log(Screen.height);


    }

    private void Update()
    {
        // Check if the screen orientation has changed
        if (
            Screen.orientation == ScreenOrientation.LandscapeLeft ||
            Screen.orientation == ScreenOrientation.LandscapeRight
        )
        {
            // Stretch the background when the screen rotates
            StretchBackground();
        }
        else if (
            Screen.orientation == ScreenOrientation.Portrait
        )
        {
            backgroundTransform.localScale = new Vector3(1, 1, 1);
        }
    }

    private void StretchBackground()
    {
        float ratio = (float) Screen.width / Screen.height;
        backgroundTransform.localScale = new Vector3(1 + ratio, 1, 1);
    }
}
