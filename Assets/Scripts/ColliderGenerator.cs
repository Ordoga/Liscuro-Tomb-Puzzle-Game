using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderGenerator : MonoBehaviour
{
    [SerializeField] FollowHolder lantern;

    PolygonCollider2D polygon;
    LightMesh2D lightMesh;

    void Start()
    {
        polygon = GetComponent<PolygonCollider2D>();

        if (polygon ==null) {
            polygon = gameObject.AddComponent<PolygonCollider2D>();
        }

        lightMesh = GetComponent<LightMesh2D>();
        lantern = GetComponent<FollowHolder>();
    }

    void FixedUpdate() {

        Vector2[] points = new Vector2[lightMesh.geometry.optimizedPointsCount];

        Vector2 position = transform.position;

        for (int i = 0; i < lightMesh.geometry.optimizedPointsCount; i++)
        {
            points[i] = lightMesh.geometry.optimizedPoints[i] - position;
        }

        polygon.points = points;

    }
}
