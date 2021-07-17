using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    Image hpBar;
    Transform hpTransform;

    private void Awake()
    {
        hpBar = GetComponent<Image>();
        hpTransform = transform;
    }

    private void LateUpdate()
    {
        hpTransform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }

    public void UpdateHP(float health)
    {
        hpBar.fillAmount = health;
    }


}