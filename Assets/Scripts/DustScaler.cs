using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustScaler : MonoBehaviour
{
    private void Start()
    {
        ParticleSystem p = GetComponent<ParticleSystem>();
        var em = p.emission;
        var s = p.shape.box;
        em.rateOverTime = ((s.x * s.y * s.z) / 2f);
    }
}
