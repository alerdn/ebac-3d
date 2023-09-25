using NaughtyAttributes;
using UnityEngine;

public class ClothChanger : MonoBehaviour
{
    public Texture CurrentTexture;

    [SerializeField] private SkinnedMeshRenderer _renderer;
    [SerializeField] private Texture2D _texture;

    private Texture2D _defaultTexture;

    private void Start()
    {
        _defaultTexture = (Texture2D)_renderer.materials[0].GetTexture("_EmissionMap");
    }

    public void ChangeTexture(ClothSetup setup)
    {
        CurrentTexture = setup.Texture;
        _renderer.materials[0].SetTexture("_EmissionMap", CurrentTexture);
    }

    public void SetTexture(Texture texture)
    {
        if (texture == null) return;

        CurrentTexture = texture;
        _renderer.materials[0].SetTexture("_EmissionMap", CurrentTexture);
    }


    public void ResetTexture()
    {
        CurrentTexture = _defaultTexture;
        _renderer.materials[0].SetTexture("_EmissionMap", CurrentTexture);
    }
}
