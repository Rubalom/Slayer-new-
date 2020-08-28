using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class AttackStatus : MonoBehaviour
{
    [SerializeField] private Image mainImage;
    [SerializeField] private Image mask;
    [SerializeField] private Color32 readyColor;
    [SerializeField] private Color32 notreadyColor;

    public enum Status
    {
        Attacking,
        Reloading,
        Ready
    }

    Status status;

    private void Start()
    {
        SetReadyStatus();
    }

    public void SetStatus(Status s)
    {
        switch (s)
        {
            default:
                break;

            case Status.Attacking:
                SetAttackingStatus();
                break;

            case Status.Ready:
                SetReadyStatus();
                break;

            case Status.Reloading:
                SetReloadingStatus();
                break;
        }
    }

    private void SetAttackingStatus()
    {
        status = Status.Attacking;
        Color32 c = mask.color;
        mask.fillAmount = 1;
        mask.color = new Color32(c.r, c.g, c.b, 255);
    }

    private void SetReloadingStatus()
    {
        status = Status.Reloading;
        Color32 c = mask.color;
        mainImage.color = notreadyColor;
        mask.color = new Color32(c.r, c.g, c.b, 94);
        SetReloadAmount(0f);
    }

    private void SetReadyStatus()
    {
        status = Status.Ready;
        Color32 c = mask.color;
        mainImage.color = readyColor;
        mask.fillAmount = 1;
        mask.color = new Color32(c.r, c.g, c.b, 94);
    }

    public void SetReloadAmount(float amount)
    {
        if (status != Status.Reloading)
            return;
        mask.fillAmount = amount;
        
    }

}
