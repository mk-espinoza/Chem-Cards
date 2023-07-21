using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

/* Naming Convention for Unity 
 * ---------------------------
 * 
 * Public members:
 *  pascal case (PascalCase)
 *  
 * Private members:
 *  underscore + camelcase (_camelCase)
 *  
 *  --------------------------
 *  Based on: https://unity.com/how-to/naming-and-code-style-tips-c-scripting-unity
 * */


public class ARPlaceTrackedImages : MonoBehaviour
{
    // This array will hold all our models
    public GameObject[] TrackedImagePrefabs;
    // This dictionary will be a mapping of name of ref image and instantiated prefab
    private readonly Dictionary<string, GameObject> _markerNamesToInstPrefab = new Dictionary<string, GameObject>();
    // Cache AR tracked images manager from Unity's AR Tracked Image Manager
    private ARTrackedImageManager _trackedImagesManager;


    // Awake is called before GameObject is activated
    private void Awake()
    {
        _trackedImagesManager = GetComponent<ARTrackedImageManager>();
    }

    // OnEnabled is called after GameObject is activated
    // This is a good place to set subsciptions to event handlers
    private void OnEnable() => _trackedImagesManager.trackedImagesChanged += OnTrackedImagesChanged;

    // Start is called before the first frame update
    private void Start() { }

    // Update is called once per frame
    private void Update() {}

    // Event handler for changes with TrackedImagesManager
    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var newImage in eventArgs.added)
        {

            string addedImageName = newImage.referenceImage.name;
            foreach (GameObject prefab in TrackedImagePrefabs)
            {
                MoleculeController controller = prefab.GetComponent<MoleculeController>();
                if (controller.CheckImageName(addedImageName) && !_markerNamesToInstPrefab.ContainsKey(addedImageName))
                {
                    GameObject gameObject = Instantiate(prefab, newImage.transform);
                    _markerNamesToInstPrefab.Add(addedImageName, gameObject);
                }
            }
        }

        foreach (var updatedImage in eventArgs.updated)
        {
            bool isTrackingState = updatedImage.trackingState == TrackingState.Tracking;
            GameObject gameObject = _markerNamesToInstPrefab[updatedImage.referenceImage.name];
            gameObject.SetActive(isTrackingState);
        }

        foreach (var deletedImage in eventArgs.removed)
        {
            Destroy(_markerNamesToInstPrefab[deletedImage.referenceImage.name]);
            _markerNamesToInstPrefab.Remove(deletedImage.referenceImage.name);
        }
    }

    
    // OnDisable is called after GameObject is deactivated (but not destroyed yet)
    // This is a good place to unsubscibe from event handlers
    private void OnDisable() => _trackedImagesManager.trackedImagesChanged -= OnTrackedImagesChanged;
}
