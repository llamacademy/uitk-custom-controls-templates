using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

namespace LlamAcademy.UI
{
    [RequireComponent(typeof(PanelRenderer))]
    public class InputHandler : MonoBehaviour
    {
        private PanelRenderer PanelRenderer;
        private VisualElement XPDropContainer;

        private void Awake()
        {
            PanelRenderer = GetComponent<PanelRenderer>();
            PanelRenderer.RegisterUIReloadCallback(HandleUIReload);
        }

        private void Update()
        {
            if (Mouse.current.leftButton.wasReleasedThisFrame)
            {
                XPDrop xpDrop = new XPDrop();
                XPDropContainer.Add(xpDrop);
                xpDrop.SetAmount(Random.Range(1, 200));
            }
        }

        private void OnDestroy()
        {
            PanelRenderer.UnregisterUIReloadCallback(HandleUIReload);
        }

        private void HandleUIReload(PanelRenderer panelRenderer, VisualElement rootElement, int version)
        {
            XPDropContainer = rootElement.Q("xp-drop-container");
        }

    }
}