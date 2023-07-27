using NaughtyAttributes;
using UnityEngine;

public class ClothChanger : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer _renderer;
    [SerializeField] private Texture2D _texture;

    private Texture2D _defaultTexture;

    private void Start()
    {
        _defaultTexture = (Texture2D)_renderer.materials[0].GetTexture("_EmissionMap");
    }

    [Button]
    public void ChangeTexture()
    {
        _renderer.materials[0].SetTexture("_EmissionMap", _texture);
    }

    public void ChangeTexture(ClothSetup setup)
    {
        _renderer.materials[0].SetTexture("_EmissionMap", setup.Texture);
    }

    public void ResetTexture()
    {
        _renderer.materials[0].SetTexture("_EmissionMap", _defaultTexture);
    }
}
