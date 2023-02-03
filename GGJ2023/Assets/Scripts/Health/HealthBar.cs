using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private GameObject healthBar;
    
    public void EnableBar()
    {
        gameObject.SetActive(true);
    }

    public void DisableBar()
    {
        gameObject.SetActive(false);
    }
    
    public void SetBarValue(float healthPercent)
    {
        healthBar.transform.localScale = new Vector3(healthPercent, 1f, 1f);
    }
}
