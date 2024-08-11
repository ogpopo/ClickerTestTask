using System;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Util
{
    public class UIParticleSystem : MaskableGraphic
    {
        [SerializeField] private ParticleSystemRenderer _systemRenderer;
        [SerializeField] private Camera _bakeCamera;

        [SerializeField] private Texture _texture;

        public override Texture mainTexture => _texture ?? base.mainTexture;

        private void Update()
        {
            SetVerticesDirty();
        }

        protected override void OnPopulateMesh(Mesh mesh)
        {
            mesh.Clear();
            if (_systemRenderer != null && _bakeCamera != null)
            {
                _systemRenderer.BakeMesh(mesh, _bakeCamera);
            }
        }
    }
}