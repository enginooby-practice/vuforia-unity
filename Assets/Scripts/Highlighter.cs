using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EPOOutline;

// How to use: invoke Highlight() or assign tag and add collider on target
public enum Mouse { LEFT, RIGHT, MIDDLE }
// TODO: create hightlight samples => clone it to the highlighted object
// TODO: implement on right mouse click, layers, disable all tags/layers, enable all tags/layers, toggle mode
public class Highlighter : MonoBehaviour
{
    public static Highlighter Instance;
    enum MODE { Single, Multiple }

    [Tooltip("Single mode: maximum one object is highlighted at a time")]
    [SerializeField] private MODE mode = MODE.Single;

    [Header("ON LEFT MOUSE CLICK")]
    [SerializeField] List<string> outlinableTagsOnLeftMouseClick = new List<string>();

    [Header("ON MOUSE HOVER")]
    [SerializeField] List<string> outlinableTagsOnMouseHover = new List<string>();

    private Outlinable previousOutlinable;
    private GameObject previousHighlightedObject;
    private Camera mainCamera;
    private Ray ray;
    private RaycastHit hit;

    private void Awake()
    {
        Instance = this;
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (outlinableTagsOnLeftMouseClick.Count > 0) DetectLeftMouseClick();
        if (outlinableTagsOnMouseHover.Count > 0) DetectMouseHover();
    }

    private void DetectLeftMouseClick()
    {
        if (Input.GetMouseButtonDown((int)Mouse.LEFT))
        {
            ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit) && outlinableTagsOnLeftMouseClick.Contains(hit.collider.tag))
            {
                Highlight(hit.collider.gameObject);
            }
        }
    }

    private void DetectMouseHover()
    {
        ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit) && outlinableTagsOnMouseHover.Contains(hit.collider.tag))
        {
            if (!previousHighlightedObject || previousHighlightedObject != hit.collider.gameObject)
            {
                Highlight(hit.collider.gameObject);
            }
        }
    }

    // public method for other objects to call, even without colliders
    public void Highlight(GameObject target)
    {
        if (target.GetComponent<Outlinable>()) return;

        // add Outlinable to gameObject & Mesh gameobject to Outlightable
        var outlinable = target.AddComponent<Outlinable>();
        outlinable.OutlineTargets.Add(new OutlineTarget(target.GetComponent<Renderer>()));

        if (mode == MODE.Single && previousOutlinable)
        {
            Destroy(previousOutlinable);
        }
        previousOutlinable = outlinable;
        previousHighlightedObject = target;
    }
}
