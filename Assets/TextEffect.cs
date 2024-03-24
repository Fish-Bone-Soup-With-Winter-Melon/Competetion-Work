using UnityEngine;
using TMPro;
using System.Collections;

public class TextEffect : MonoBehaviour
{
    public TextMeshProUGUI textComponent; // 使用TextMeshProUGUI
    public float blinkInterval = 0.05f; // 闪烁间隔时间
    private float alpha = 1f; // 文本的Alpha值
    private bool cnt = false;

    void Start()
    {
        // 开始闪烁
        StartCoroutine(Blink());
    }

    IEnumerator Blink()
    {
        while (true)
        {
            // 切换Alpha值
            if (alpha >= 1)
            {
                cnt = true;
            }
            if (alpha <= 0)
            {
                cnt = false;
            }
            alpha = (cnt) ? alpha-0.05f : alpha+0.05f;
            textComponent.color = new Color(textComponent.color.r, textComponent.color.g, textComponent.color.b, alpha);

            // 等待指定的时间
            yield return new WaitForSeconds(blinkInterval);
        }
    }
}