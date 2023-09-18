using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLine : MonoBehaviour
{
    static public ProjectileLine S; //Singleton

    [Header("Set in Inspector")]
    public float minDist = 0.1f;

    private LineRenderer line;
    private GameObject _poi;
    private List<Vector3> points;

    private void Awake()
    {
        S = this; //Set singleton

        //Get a reference to the LineRenderer
        line = GetComponent<LineRenderer>();

        //Disable the LineRenderer until it's needed
        line.enabled = false;

        //Initialize the points list
        points = new List<Vector3>();
    }

    //This is a property (that is, a method masquerading a field)
    public GameObject POI
    {
        get
        {
            return (_poi);
        }

        set
        {
            _poi = value;

            if(_poi != null)
            {
                //When _poi is set to something new, it resets everything
                line.enabled = false;
                points = new List<Vector3>();
                AddPoint();
            }
        }
    }

    //This can be used to clear the line directly
    public void Clear()
    {
        _poi = null;
        line.enabled = false;
        points = new List<Vector3>();
    }

    public void AddPoint()
    {
        //This is called to add a point to the line
        Vector3 pt = _poi.transform.position;

        if(points.Count > 0 && (pt - lastPoint).magnitude < minDist)
        {
            //If the point isn't far enough from the last point, it returns
            return;
        }

        if(points.Count == 0)
        {
            //If this is the launch point...
            Vector3 launchPosDiff = pt - Slingshot.LAUNCH_POS; //To be defeated

            //...it adds an extra bit of line to aiming later
            points.Add(pt + launchPosDiff);
            points.Add(pt);
            line.positionCount = 2;

            //Set the first 2 points
            line.SetPosition(0, points[0]);
            line.SetPosition(1, points[1]);

            //Enables the LineRenderer
            line.enabled = true;
        }

        else
        {
            //Normal behavior of adding a point
            points.Add(pt);
            line.positionCount = points.Count;
            line.SetPosition(points.Count - 1, lastPoint);
            line.enabled = true;
        }

        //Returns the location of the most recently added point
        public Vector3 lastPoint
        {
            get
            {
                if(points == null)
                {
                //If there are no points, returns Vector3.zero
                return (Vector3.zero);
                }

                return (points[points.Count - 1]);
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(poi == null)
        {
            //If there's no poi, search for one
            if(FollowCam.POI != null)
            {
                if(poi = FollowCam.POI.tag = "Projectile")
                {
                    poi = FollowCam.POI.tag = "Projectile";
                }
            }

            else
            {
                return; //Reutrn if we didn't find a poi
            }

            else
            {
                return; //Reutrn if we didn't find a poi
            }
    }

    //If there is a poi, it's loc is added every FixedUpdate
    AddPoint();

    if(FollowCam.POI == null)
    {
        //Once FollowCam.POI is null, make the local poi null too
        poi = null;
    }
}