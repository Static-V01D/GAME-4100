using UnityEngine;
using UnityEngine.Rendering;

public class SwitchRenderPipelineAsset : MonoBehaviour
{
    public RenderPipelineAsset exampleAssetA;
    

    void Update()
    {
      
        
            GraphicsSettings.renderPipelineAsset = exampleAssetA;
            Debug.Log("Default render pipeline asset is: " + GraphicsSettings.renderPipelineAsset.name);
      
        
    }
}