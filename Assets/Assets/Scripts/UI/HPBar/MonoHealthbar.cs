using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(Margin))]
[Serializable]
public class MonoHealthbar : MonoTexture {
    

#region Public Attributes


    /// <summary>
    /// The outline bar look.
    /// </summary>
    public Texture2D FillTexture;

    public int Health = 90;

    [HideInInspector]
    public GUIStyle progress_full;
    
    void OnGUI()
    {
        GUI.depth = -Zindex;

        if (this.OutlineTexture != null)
        {
            GUI.BeginGroup(new Rect(this.PosX, this.PosY, this.Width, this.Height), this.OutlineTexture);

            if (this.FillTexture != null)
            {
                GUI.BeginGroup(new Rect(0, 0, this.Width * this.Health / 100, this.Height));
                GUI.Box(new Rect(0, 0, this.Width, this.Height), this.FillTexture, progress_full);
                GUI.EndGroup();

                if (Input.GetMouseButtonDown(0))
                {
                    Health = Health - 1;


                }
            }

            GUI.EndGroup();
        }
    }
#endregion
//End Public Attributes

}
