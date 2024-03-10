using UnityEngine;
using TMPro;
using System.Collections;

public class TextEffect : MonoBehaviour
{
    public TextMeshProUGUI textComponent; // ʹ��TextMeshProUGUI
    public float blinkInterval = 0.05f; // ��˸���ʱ��
    private float alpha = 1f; // �ı���Alphaֵ
    private bool cnt = false;

    void Start()
    {
        // ��ʼ��˸
        StartCoroutine(Blink());
    }

    IEnumerator Blink()
    {
        while (true)
        {
            // �л�Alphaֵ
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

            // �ȴ�ָ����ʱ��
            yield return new WaitForSeconds(blinkInterval);
        }
    }
}