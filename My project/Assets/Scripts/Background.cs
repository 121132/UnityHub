using UnityEngine;
using UnityEngine.Rendering;

public class Background : MonoBehaviour
{
    private Camera camera;
    private CommandBuffer grassCommandBuffer;
    private Material backgroundMaterial;

    void Start()
    {
        camera = GetComponent<Camera>();
        grassCommandBuffer = new CommandBuffer();
        backgroundMaterial = new Material(Shader.Find("Unlit/HiddenGreenBackground"));
        
        camera.AddCommandBuffer(CameraEvent.BeforeForwardOpaque, grassCommandBuffer);
    }

    void OnRenderObject()
    {
        grassCommandBuffer.Clear();
        grassCommandBuffer.DrawMesh(MeshFactory.CreateFullScreenQuad(), Matrix4x4.identity, backgroundMaterial, 0);
    }
}

static class MeshFactory
{
    public static Mesh CreateFullScreenQuad()
    {
        Mesh mesh = new Mesh();
        mesh.vertices = new Vector3[]
        {
            new Vector3(-1, -1, 0),
            new Vector3( 1, -1, 0),
            new Vector3( 1,  1, 0),
            new Vector3(-1,  1, 0)
        };
        mesh.uv = new Vector2[]
        {
            new Vector2(0, 0),
            new Vector2(1, 0),
            new Vector2(1, 1),
            new Vector2(0, 1)
        };
        mesh.triangles = new int[]
        {
            0, 2, 1, 
            0, 3, 2
        };
        mesh.RecalculateNormals();
        return mesh;
    }
}