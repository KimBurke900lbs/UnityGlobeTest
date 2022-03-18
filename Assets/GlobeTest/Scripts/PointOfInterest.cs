using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Point of Interest", menuName = "Point of Interest")]
public class PointOfInterest : ScriptableObject
{
    #region Properties
    public string Key => key;
    public string LocationName => locationName;
    public string CaseStudy => caseStudy;
    public float Latitude => latitude;
    public float Longitude => longitude;
    public bool Interactive => interactive;
    #endregion

    #region Serialized Private Variables
    [SerializeField] private string key = default;
    [SerializeField] private string locationName = default;
    [SerializeField] private string caseStudy = default;
    [SerializeField, Range(-90, 90), Tooltip("In degrees.")] private float latitude = default;
    [SerializeField, Range(-180, 180), Tooltip("In degrees. West is negative and East is positive.")] private float longitude = default;
    [SerializeField] private bool interactive = default;
    #endregion
}
