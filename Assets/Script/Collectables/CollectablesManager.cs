using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class CollectablesManager : MonoBehaviour
{
    #region Singleton
    private static CollectablesManager _instance;

    public static CollectablesManager Instance => _instance;

    public float BuffChance { get => buffChance; set => buffChance = value; }

    private void Awake()
    {
        if(_instance != null)
        {
            Destroy(gameObject);
        }
        else 
        { 
            _instance = this; 
        }
    }
    #endregion

    public List<Collectable> AvailableBuffs;
    public List<Collectable> AvailableDebuffs;

    [UnityEngine.Range(0, 100)]
    public float buffChance;

    [UnityEngine.Range(0, 100)]
    public float DebuffChance;


}
