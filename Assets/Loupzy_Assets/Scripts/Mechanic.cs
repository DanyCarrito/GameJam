using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Mechanic : MonoBehaviour {
    private LineRenderer lineRenderer;
    public List<Transform> points = new List<Transform>();
    public Transform lastPoints;

    private void Awake() {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Vector2 wordPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(wordPoint, Vector2.zero);

            if (hit.collider != null) {
                bool isTouchButton = (hit.collider.CompareTag("Bad") || hit.collider.CompareTag("Good"));

                if (isTouchButton) {
                    makeLine(hit.collider.transform);
                }
            }
        }
    }


    private void makeLine(Transform finalPoint) {
        if (lastPoints == null) {
            lastPoints = finalPoint;
            points.Add(finalPoint);
        } else {
            if (!points.Contains(finalPoint) && !ArePointsAtSamePosition(finalPoint, points[points.Count - 1])) {
                points.Add(finalPoint);
                lineRenderer.enabled = true;
                SetupLine();

                //if (points.Count >= 3) {
                //    Win();
                //}
            } else {
                Debug.Log("No se puede unir con un punto de la lista");
            }
        }
    }

    public void RemoveLine() {
        print("se borro la linea");

        if (points.Count > 1) {
            points.RemoveAt(points.Count - 1);
        } else {
            Debug.Log("Cannot remove the last point. At least one point is required.");
        }

        lineRenderer.positionCount = points.Count;
        lineRenderer.enabled = points.Count > 1; 
        lastPoints = points.Count > 0 ? points[points.Count - 1] : null;
        SetupLine();
    }




    private bool ArePointsAtSamePosition(Transform newPoint, Transform previousPoint) {
        return Mathf.Approximately(previousPoint.position.x, newPoint.position.x) &&
               Mathf.Approximately(previousPoint.position.y, newPoint.position.y);
    }


    private void SetupLine() {
        int pointLength = points.Count;
        lineRenderer.positionCount = pointLength;
        for (int i = 0; i < pointLength; i++) {
            lineRenderer.SetPosition(i, points[i].position);
        }
    }

    public void Win() {
        bool allGood = true;

        foreach (Transform point in points) {
            if (!point.CompareTag("Good")) {
                allGood = false;
                break;
            }
        }

        if (allGood && points.Count > 0 && points.Count == GameObject.FindGameObjectsWithTag("Good").Length) {
            Debug.Log("¡Ganaste! Eres una buena persona");
            GameManager.instance.ChangeGameState(GameState.Victory);
        } else {
            Debug.Log("Perdiste. Eres un inbecil");
            GameManager.instance.ChangeGameState(GameState.GameOver);
        }
    }

}
