using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReticleUI : MonoBehaviour
{
    public PointerUI m_PointerUI;
    public SpriteRenderer m_CircleRendererUI;

    public Sprite m_OpenSpriteUI;
    public Sprite m_ClosedSpriteUI;

    private Camera m_CameraUI = null;

    private void Awake()
    {
        m_PointerUI.OnPointerUpdate += UpdateSpriteUI;

        m_CameraUI = Camera.main;
    }

    private void Update()
    {
        transform.LookAt(m_CameraUI.gameObject.transform);
    }

    private void OnDestroy()
    {
        m_PointerUI.OnPointerUpdate -= UpdateSpriteUI;
    }

    private void UpdateSpriteUI(Vector3 pointUI, GameObject hitObjectUI)
    {
        transform.position = pointUI;

        if(hitObjectUI)
        {
            m_CircleRendererUI.sprite = m_ClosedSpriteUI;
        }
        else
        {
            m_CircleRendererUI.sprite = m_OpenSpriteUI;
        }
    }
}
