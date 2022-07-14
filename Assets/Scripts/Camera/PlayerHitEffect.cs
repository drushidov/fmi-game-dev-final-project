using UnityEngine;

public class PlayerHitEffect : MonoBehaviour
{
    public Material playerHitMaterial;

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, playerHitMaterial);
    }
}
