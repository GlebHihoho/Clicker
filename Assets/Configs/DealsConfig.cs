using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = nameof(DealConfig))]
public class LevelsConfig : ScriptableObject
{
    public DealConfig[] Levels => _levels;

    [SerializeField] private DealConfig[] _levels;
}
