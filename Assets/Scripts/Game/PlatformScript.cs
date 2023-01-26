using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Platform平台的脚本
/// </summary>
public class PlatformScript : MonoBehaviour
{
    public SpriteRenderer[] spriteRenderers;
    public GameObject obstacle;
    private bool isStartTimer;
    private float fallTime;
    private Rigidbody2D m_Body;

    private void Awake()
    {
        m_Body = GetComponent<Rigidbody2D>();
    }
    /// <summary>
    /// 初始化平台
    /// 平台图片、掉落时间、生成障碍的方向
    /// </summary>
    /// <param name="sprite"></param>
    /// <param name="fallTime"></param>
    /// <param name="obstacleDir"></param>
    public void Init(Sprite sprite, float fallTime, int obstacleDir)
    {
        m_Body.bodyType = RigidbodyType2D.Static;
        this.fallTime = fallTime;
        isStartTimer = true;
        for (int i = 0; i < spriteRenderers.Length; i++)
        {
            spriteRenderers[i].sprite = sprite;
        }

        if (obstacleDir == 0)//朝右边
        {
            if (obstacle != null)
            {
                obstacle.transform.localPosition = new Vector3(-obstacle.transform.localPosition.x,
                    obstacle.transform.localPosition.y, 0);
            }
        }
    }
    private void Update()
    {
        if (GameManager.Instance.IsGameStarted == false || GameManager.Instance.PlayerIsMove == false) return;

        if (isStartTimer)
        {
            fallTime -= Time.deltaTime;
            if (fallTime < 0)//倒计时结束
            {
                //掉落
                isStartTimer = false;
                if (m_Body.bodyType != RigidbodyType2D.Dynamic)
                {
                    // 让平台掉落
                    m_Body.bodyType = RigidbodyType2D.Dynamic;
                    StartCoroutine(DelayHide());
                }
            }
        }
        if (transform.position.y - Camera.main.transform.position.y < -6)
        {
            StartCoroutine(DelayHide());
        }
    }
    /// <summary>
    /// 延时隐藏
    /// </summary>
    private IEnumerator DelayHide()
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
}
