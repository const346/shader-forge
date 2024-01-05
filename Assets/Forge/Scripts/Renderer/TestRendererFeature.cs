using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TestRendererFeature : ScriptableRendererFeature
{
    [System.Serializable]
    public class FeatureSettings
    {
        public bool IsEnabled = true;
        public RenderPassEvent WhenToInsert = RenderPassEvent.AfterRendering;
        public Material Material;
    }

    public FeatureSettings settings = new FeatureSettings();

    private TestRenderPass _customRenderPass;

    public override void Create()
    {
        _customRenderPass = new TestRenderPass(
          nameof(TestRenderPass),
          settings.WhenToInsert,
          settings.Material
        );
    }

    public override void AddRenderPasses(
        ScriptableRenderer renderer, 
        ref RenderingData renderingData)
    {
        if (settings.IsEnabled)
        {
            renderer.EnqueuePass(_customRenderPass);
        }
    }
}
