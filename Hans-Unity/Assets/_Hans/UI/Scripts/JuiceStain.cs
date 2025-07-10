using UnityEngine;
using System.Collections;

public class JuiceStain : MonoBehaviour
{
    private Material mat;
    private Color originalColor;

    private void Awake()
    {
        // MeshRenderer ‚©‚çƒ}ƒeƒŠƒAƒ‹‚ðŽæ“¾
        mat = GetComponent<MeshRenderer>().material;
        originalColor = mat.color;
    }

    public void StartFadeOut()
    {
        StartCoroutine(FadeOutCoroutine());
    }

    private IEnumerator FadeOutCoroutine()
    {
        float duration = 2f;
        float timer = 0f;

        while (timer < duration)
        {
            float alpha = Mathf.Lerp(1f, 0f, timer / duration);
            mat.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);

            timer += Time.deltaTime;
            yield return null;
        }

        Destroy(gameObject);
    }
}