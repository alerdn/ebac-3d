using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ClothType
{
    SPEED
}

public class ClothManager : Singleton<ClothManager>
{
    [SerializeField] private List<ClothSetup> _clothSetups;

    public ClothSetup GetSetupByType(ClothType type)
    {
        return _clothSetups.Find(setup => setup.Type == type);
    }
}

[Serializable]
public class ClothSetup
{
    public ClothType Type;
    public Texture2D Texture;
}