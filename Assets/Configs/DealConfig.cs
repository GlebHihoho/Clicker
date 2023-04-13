using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = nameof(Deal))]
public class DealConfig : ScriptableObject
{
    public Deal deal => _deal;

    [SerializeField] private Deal _deal;
}
