using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
public static class SceneMousePosition
{
    static SceneMousePosition()
    {
        SceneView.duringSceneGui += OnSceneGUI;
    }

    private static void OnSceneGUI(SceneView sceneView)
    {
        Event e = Event.current;
        Ray ray = HandleUtility.GUIPointToWorldRay(e.mousePosition);

        // Cast against a horizontal plane at Y=0 (you can change this)
        Plane ground = new Plane(Vector3.up, Vector3.zero);
        if (ground.Raycast(ray, out float distance))
        {
            Vector3 worldPos = ray.GetPoint(distance);

            Handles.BeginGUI();
            GUI.Label(
                new Rect(10, sceneView.position.height - 40, 400, 20), 
                $"Mouse World Position: {worldPos:F2}"
            );
            Handles.EndGUI();
        }
    }
}