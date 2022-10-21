using System;
using UnityEngine;

namespace Sprites
{
    [ExecuteInEditMode]
    public class SpriteOutline : MonoBehaviour {
        public Color color = Color.white;

        [Range(0, 16)]
        public int outlineSize = 1;

        private SpriteRenderer spriteRenderer;

        void OnEnable() 
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void OnMouseEnter()
        {
            UpdateOutline(true);
        }

        private void OnMouseExit()
        {
            UpdateOutline(false);
        }

        void UpdateOutline(bool outline) {
            MaterialPropertyBlock mpb = new MaterialPropertyBlock();
            spriteRenderer.GetPropertyBlock(mpb);
            mpb.SetFloat("_Outline", outline ? 1f : 0);
            mpb.SetColor("_OutlineColor", color);
            mpb.SetFloat("_OutlineSize", outlineSize);
            spriteRenderer.SetPropertyBlock(mpb);
        }
    }
}