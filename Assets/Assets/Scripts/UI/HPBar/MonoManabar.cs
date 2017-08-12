using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(Margin))]
[Serializable]
public class MonoManabar : MonoTexture2 {
    

#region Public Attributes


    /// <summary>
    /// The outline bar look.
    /// </summary>
    public Texture2D FillTexture2;

    public int E_Health = 90;

    [HideInInspector]
    public GUIStyle E_progress_full;
    
    void OnGUI()
    {
        GUI.depth = -Zindex;

        if (this.OutlineTexture != null)
        {
            GUI.BeginGroup(new Rect(this.PosX, this.PosY, this.Width, this.Height), this.OutlineTexture);

            if (this.FillTexture2 != null)
            {
                GUI.BeginGroup(new Rect(0, 0, this.Width * this.E_Health / 100, this.Height));
                GUI.Box(new Rect(0, 0, this.Width, this.Height), this.FillTexture2, E_progress_full);
                GUI.EndGroup();

                if (Input.GetMouseButtonDown(1))
                {
                    E_Health = E_Health - 1;


                }
            }

            GUI.EndGroup();
        }
    }
#endregion
//End Public Attributes

}
