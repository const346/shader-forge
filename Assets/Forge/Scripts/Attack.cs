using Cinemachine;
using System.Collections;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _cvc;

    [SerializeField] private Renderer _rendererX;
    [SerializeField] private Renderer _renderer;
    [SerializeField] private Animator _animator;
    [SerializeField] private Animator[] _animators;

    [SerializeField] private float _attackDelay = 2f;
    [SerializeField] private float _startDelay = 0.2f;



    private void Awake()
    {
        var noise = _cvc.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        noise.m_AmplitudeGain = 0f;
    }

    private IEnumerator Start()
    {
        var timeX = 0f;

        while (timeX < 1)
        {
            _rendererX.material.SetFloat("_amound", timeX);

            yield return null;
            timeX += Time.deltaTime / 2;
        }

        StartCoroutine(ResetAgr()); 
        StartCoroutine(CameraShake());
        _animator.SetTrigger("Attack");

        yield return new WaitForSeconds(_startDelay);

        var time = 0f;

        while (time < 0.9f)
        {
            _renderer.material.SetFloat("_radius", time);

            yield return null;
            time += Time.deltaTime * 1.5f;
        }


        foreach (var animator in _animators)
        {
            animator.SetTrigger("Damage");
        }
        
        while (time < 1)
        {
            _renderer.material.SetFloat("_radius", time);

            yield return null;
            time += Time.deltaTime * 1f;
        }

        _renderer.material.SetFloat("_radius", 1f);

        StartCoroutine(Start());
    }

    private IEnumerator ResetAgr()
    {
        yield return new WaitForSeconds(0.8f);
        _rendererX.material.SetFloat("_amound", 0);
    }

    private IEnumerator CameraShake()
    {
        yield return new WaitForSeconds(0.8f);

        var noise = _cvc.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>(); 
        noise.m_AmplitudeGain = 1f;

        yield return new WaitForSeconds(0.35f);

        noise.m_AmplitudeGain = 0f;
    }
}
