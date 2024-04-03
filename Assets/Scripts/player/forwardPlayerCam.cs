using UnityEngine;

public class forwardPlayerCam : MonoBehaviour
{
    public static float pixelsToUnits = 1f;
    public static float scale = 1f;
    public float offSetFrog = 0.0f;

    public Vector2 nativeResolution = new Vector2(240, 160);

    [SerializeField] private float speed;
    private float currentPosX;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private Transform Frog;
    private void Update() {
        //player follow only
        transform.position = new Vector3(Frog.position.x + offSetFrog, transform.position.y, transform.position.z);

        //if we use scene to scene transitions instead of endless scrolling this camera would need a hitbox at end of scene to transition to next scene
        //transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentPosX, transform.position.y, transform.position,z), ref velocity, speed);
    }
    void Awake()
    {
        var camera = GetComponent<Camera>();
        if (camera.orthographic)
        {
            scale = Screen.height / nativeResolution.y;
            pixelsToUnits *= scale;
            //camera.orthographicSize = (Screen.height / 2.0f) / pixelsToUnits;
        }
    }
    /*public void MoveScene(Transform _newScene) {
        currentPosX = _newScene.position.x;
    } again if we use scene transitions*/
}