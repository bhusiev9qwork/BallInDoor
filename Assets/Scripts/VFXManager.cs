using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager : MonoBehaviour
{
    [SerializeField] public List<Effect> effects;

    public static VFXManager Instance;

    private void Awake()
    {
        if (Instance == null) 
            Instance = this;
    }

    public  void PlayEffect(EffectType  effectType, Transform parentTr)
    {
        foreach (var effect in  effects)
        {
           
            if(effect!= null && effect.effectType == effectType)
            {
                Instantiate(effect, parentTr.position, Quaternion.identity, parentTr);
                effect.gameObject.SetActive(true);
            }
        }
      
    }
}
public enum EffectType
{
     ExplosionObstacle = 0
}
