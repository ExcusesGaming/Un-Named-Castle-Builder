using Excuses.Libraries.UI;
using UnityEngine;

public class ToggleData : MonoBehaviour
{
    public bool IsActive = false;

    public void ChangeActiveState(UIImage image)
    {
        if(IsActive)
        {
            IsActive = false;
            image.imageOBJ.SetActive(false);
        }
        else
        {
            IsActive = true;
            image.imageOBJ.SetActive(true);
        }
    }
}
