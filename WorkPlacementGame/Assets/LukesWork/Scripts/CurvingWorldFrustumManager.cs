using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[ExecuteAlways]
public class CurvingWorldFrustumManager : MonoBehaviour
{
    const string CURVING_FEATURE = "ENABLE_BENDING";

    private void Awake()
    {
        if (Application.isPlaying)
        {
            Shader.EnableKeyword(CURVING_FEATURE);
        }
        else
        {
            Shader.DisableKeyword(CURVING_FEATURE);
        }
    }

    private void OnEnable()
    {
        RenderPipelineManager.beginCameraRendering += OnBeginCameraRendering;
        RenderPipelineManager.endCameraRendering += OnEndCameraRendering;
    }

    private void OnDisable()
    {
        RenderPipelineManager.beginCameraRendering -= OnBeginCameraRendering;
        RenderPipelineManager.endCameraRendering -= OnEndCameraRendering;
    }

    void OnBeginCameraRendering(ScriptableRenderContext context, Camera camera)
    {
        camera.cullingMatrix = Matrix4x4.Ortho(-100, 100, -100, 100, 0.1f, 1000) * camera.worldToCameraMatrix;
    }

    void OnEndCameraRendering(ScriptableRenderContext context, Camera camera)
    {
        camera.ResetCullingMatrix();
    }
}
