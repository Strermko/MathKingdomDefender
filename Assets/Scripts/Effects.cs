using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effects : MonoBehaviour
{
    [SerializeField] GameObject goodVFX;
    [SerializeField] GameObject badVFX;

    private ParticleSystem _gParticles;
    private ParticleSystem _bParticles;

    private void Start()
    {
        _gParticles = goodVFX.GetComponent<ParticleSystem>();
        _bParticles = badVFX.GetComponent<ParticleSystem>();
    }
    
    public void GoodOut() { _gParticles.Play(); }
    public void BadOut() { _bParticles.Play(); }
}
