using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utility
{
    // Calculates and returns camera bounds with given padding (default to 1f)
    public static Bounds GetBounds(this Camera cam, float padding = 1f)
    {
        // Define camera dimensions float
        float camHeight, camWidth;
        // Get position of camera
        Vector3 camPos = cam.transform.position;
        // Calculate height and width of camera
        camHeight = 2f * cam.orthographicSize;
        camWidth = camHeight * cam.aspect;
        // Apply padding
        camHeight += padding;
        camWidth += padding;
        // Create a camera bounds from above information
        return new Bounds(camPos, new Vector3(camWidth, camHeight, 100));
    }
}
