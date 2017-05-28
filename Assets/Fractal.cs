using System.Collections;
using UnityEngine;

public class Fractal : MonoBehaviour {

    public Mesh mesh;
    public Material material;
    public float childScale;
    public float astmaChildScale;
    public int maxDepth;
    private int depth;
    private MeshRenderer meshRenderer;
    private void Start()
    {
        gameObject.AddComponent<MeshFilter>().mesh = mesh;
        gameObject.AddComponent<MeshRenderer>().material = material;
        if (depth == 0)
        {
            depth = UIManager.instance.startGeneration;
            maxDepth = UIManager.instance.slutGeneration;
            astmaChildScale = UIManager.instance.astmaFaktor;
            Debug.Log(astmaChildScale);
        }
        meshRenderer = GetComponent<MeshRenderer>();
        if (name != "Fractal Astma")
            meshRenderer.material.color = new Color(0, 0, 0, 0.2f);
        else
            meshRenderer.material.color = Color.Lerp(new Color(1, 0, 0), new Color(0, 0, 1), (float)depth / 23);

        if (name == "Fractal Astma")
        {
            Destroy(this);
            return;
        }

        if (depth < maxDepth)
        {
            new GameObject("Fractal Astma").AddComponent<Fractal>().Initialize(this);
            StartCoroutine(CreateChildren());
        }
        else if (depth == maxDepth)
        {
            new GameObject("Fractal Astma").AddComponent<Fractal>().Initialize(this);
        }


    }
    private IEnumerator CreateChildren()
    {
        int angle;
        switch (depth)
        {
            case 0:
                angle = 65;
                break;
            case 1:
                angle = 15;
                break;
            case 2:
                angle = 40;
                break;
            default:
                angle = 35;
                break;
        }
        new GameObject("Fractal Child").AddComponent<Fractal>().Initialize(this, new Vector3(0,90,-angle + 10*(Random.value-0.5f)));
        yield return new WaitForSeconds(0.1f);
        new GameObject("Fractal Child").AddComponent<Fractal>().Initialize(this, new Vector3(0, 90, angle + 10 * (Random.value - 0.5f)));
        Destroy(this);
    }

    private void Initialize(Fractal fractalParent, Vector3 orientation)
    {
        astmaChildScale = fractalParent.astmaChildScale;
        childScale = fractalParent.childScale;
        mesh = fractalParent.mesh;
        material = fractalParent.material;
        maxDepth = fractalParent.maxDepth;
        depth = fractalParent.depth + 1;

        Quaternion angle = Quaternion.Euler(orientation);

        float radAngle = orientation.z * Mathf.PI / 180;
        
        transform.parent = fractalParent.transform;
        if (depth > maxDepth)
            transform.localScale = Vector3.one;
        else
            transform.localScale = childScale * Vector3.one;
        transform.localPosition = new Vector3(0, 6, 0);
        transform.localRotation = angle;

    }

    private void Initialize(Fractal fractalParent)
    {
        astmaChildScale = fractalParent.astmaChildScale;
        childScale = fractalParent.childScale;
        transform.parent = fractalParent.transform;
        mesh = fractalParent.mesh;
        material = fractalParent.material;
        maxDepth = fractalParent.maxDepth;
        depth = fractalParent.depth;
        transform.localScale = new Vector3(Mathf.Pow(astmaChildScale, depth) / Mathf.Pow(childScale, depth), 1, Mathf.Pow(astmaChildScale, depth) / Mathf.Pow(childScale, depth));
        transform.localPosition = Vector3.zero;
        transform.rotation = fractalParent.transform.rotation;

    }//
}
