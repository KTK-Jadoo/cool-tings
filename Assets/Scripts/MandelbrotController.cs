using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MandelbrotController : MonoBehaviour
{
    public Material mandelbrotMaterial;
    public float basePanSpeed = 0.01f; // Base panning speed
    public float zoomSpeed = 0.1f; // Zoom sensitivity
    public int minIterations = 50; // Minimum iterations
    public int maxIterations = 1000; // Maximum iterations
    public int iterationStep = 10; // Step size for adjusting iterations
    public float panScalingExponent = 2.0f; // Exponent for scaling panning speed (2 = quadratic, 3 = cubic)

    private Vector2 offset = Vector2.zero; // Mandelbrot offset
    private float zoom = 1.0f; // Zoom level
    private int currentIterations; // Current maximum iterations

    void Start()
    {
        if (mandelbrotMaterial == null)
        {
            Debug.LogError("Mandelbrot material is not assigned.");
        }

        // Initialize iterations
        currentIterations = Mathf.Clamp(minIterations, minIterations, maxIterations);
        mandelbrotMaterial.SetInt("_MaxIterations", currentIterations);
    }

    void Update()
    {
        HandleZoom();
        HandlePan();
        HandleIterationAdjustment();
        HandleReset();
        UpdateShaderParameters();
    }

    private void HandleZoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0)
        {
            zoom *= 1.0f - scroll * zoomSpeed;
        }
    }

    private void HandlePan()
    {
        // Adjust panning speed based on zoom level using exponential scaling
        float adjustedPanSpeed = basePanSpeed / Mathf.Pow(zoom, panScalingExponent);

        if (Input.GetKey(KeyCode.W)) offset.y += adjustedPanSpeed; // Pan up
        if (Input.GetKey(KeyCode.S)) offset.y -= adjustedPanSpeed; // Pan down
        if (Input.GetKey(KeyCode.A)) offset.x -= adjustedPanSpeed; // Pan left
        if (Input.GetKey(KeyCode.D)) offset.x += adjustedPanSpeed; // Pan right
    }

    private void HandleIterationAdjustment()
    {
        if (Input.GetKeyDown(KeyCode.Equals) || Input.GetKeyDown(KeyCode.Plus)) // Increase iterations
        {
            currentIterations = Mathf.Clamp(currentIterations + iterationStep, minIterations, maxIterations);
            mandelbrotMaterial.SetInt("_MaxIterations", currentIterations);
        }

        if (Input.GetKeyDown(KeyCode.Minus) || Input.GetKeyDown(KeyCode.Underscore)) // Decrease iterations
        {
            currentIterations = Mathf.Clamp(currentIterations - iterationStep, minIterations, maxIterations);
            mandelbrotMaterial.SetInt("_MaxIterations", currentIterations);
        }
    }

    private void HandleReset()
    {
        if (Input.GetKeyDown(KeyCode.R)) // Reset view
        {
            offset = Vector2.zero;
            zoom = 1.0f;
            currentIterations = minIterations; // Reset iterations
        }
    }

    private void UpdateShaderParameters()
    {
        mandelbrotMaterial.SetFloat("_Zoom", zoom);
        mandelbrotMaterial.SetVector("_Offset", offset);
        mandelbrotMaterial.SetInt("_MaxIterations", currentIterations);
    }
}
