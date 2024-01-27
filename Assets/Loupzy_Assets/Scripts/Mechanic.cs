using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mechanic : MonoBehaviour
{
    private LineRenderer lineRenderer;
    public List<Transform> points= new List<Transform>();
    public Transform lastPoints;

    private void Awake() {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update() {
        if(Input.GetMouseButtonDown(0)) {
            //print("Mouse clicked");
            Vector2 wordPoint=Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit= Physics2D.Raycast(wordPoint, Vector2.zero);

            if(hit.collider != null) {
                makeLine(hit.collider.transform);
                //print(hit.collider.name);
            }
        }

    }
    private void makeLine(Transform finalPoint) {
        if (lastPoints == null) {
            lastPoints = finalPoint;
            points.Add(finalPoint);
        } else {
            if (!points.Contains(finalPoint) && !ArePointsAtSameY(finalPoint, points[points.Count - 1])) {
                points.Add(finalPoint);
                lineRenderer.enabled = true;
                SetupLine();
            } else {
                Debug.Log("No se puede unir con dos en la misma altura");
            }
        }
    }

    private bool ArePointsAtSameY(Transform newPoint, Transform previousPoint) {
        if (previousPoint.position.y == newPoint.position.y) {
            return true;
        }
        return false;
    }



    private void SetupLine() {
        int pointLength=points.Count;
        lineRenderer.positionCount = pointLength;
        for(int i = 0; i < pointLength; i++) {
            lineRenderer.SetPosition(i, points[i].position);
        }
    }

    public void Win() {
        bool allGood = true;

        foreach (Transform point in points) {
            if (point.CompareTag("Good") == false) {
                allGood = false;
                break; 
            }
        }

        if (allGood) {
            Debug.Log("You win!");
        } else {
            Debug.Log("You lose!");
        }
    }

}


