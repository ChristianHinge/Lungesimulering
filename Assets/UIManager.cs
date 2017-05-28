using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    public static UIManager instance;
    [SerializeField]
    Slider minSlider;
    [SerializeField]
    Slider maxSlider;
    [SerializeField]
    Slider astmaSlider;
    [SerializeField]
    Slider maxDifferenceSlider;
    [SerializeField]
    Toggle lockInterval;
    [SerializeField]
    Text maxTextVal;
    [SerializeField]
    Text minTextVal;
    [SerializeField]
    Text maxDiffText;
    [SerializeField]
    Text astmaText;

    [SerializeField]
    GameObject fractalTree;

    int maxDifference;
    bool lockedInterval;
    public int startGeneration { get { return (int)minSlider.value; } }
    public int slutGeneration { get { return (int)maxSlider.value; } }
    public GameObject tree;
    public float astmaFaktor
    {
        get
        {
            return (0.84f - ((0.03f) / 10) * astmaSlider.value);
        }
    }

    public void Awake()
    {
        instance = this;
    }
    public void Start()
    {
        ChangeMaxDifference();
        ChangeMin();
        ChangeMax();
        tree = Instantiate(fractalTree);
        ChangeAstma();
    }
    public void ChangeMin()
    {
        if (maxSlider.value < minSlider.value)
            maxSlider.value = minSlider.value;

        if (maxSlider.value - minSlider.value > maxDifference || lockedInterval)
            maxSlider.value = Mathf.Clamp(minSlider.value + maxDifference, 0, 23);

        minTextVal.text = minSlider.value.ToString();
    }
    public void ChangeMax()
    {
        if (minSlider.value > maxSlider.value)
            minSlider.value = maxSlider.value;

        if (maxSlider.value - minSlider.value > maxDifference || lockedInterval)
            minSlider.value = Mathf.Clamp(maxSlider.value - maxDifference,0,23);
        maxTextVal.text = maxSlider.value.ToString();
    }

    public void ChangeMaxDifference()
    {
        maxDifference = (int)maxDifferenceSlider.value;
        ChangeMin();
        maxDiffText.text = maxDifferenceSlider.value.ToString();
    }
    public void ChangeLocked()
    {
        lockedInterval = lockInterval.isOn;
        ChangeMin();
    }
    public void UpdateFractal()
    {
        Destroy(tree);
        tree = Instantiate(fractalTree);
    }
    public void ChangeAstma()
    {
        astmaText.color = Color.Lerp(Color.green, Color.red, astmaSlider.value / 10f);
        if (astmaSlider.value <= 1)
            astmaText.text = "Rask";
        if (astmaSlider.value >= 2)
            astmaText.text = "Mild Astma";
        if (astmaSlider.value >= 4)
            astmaText.text = "Astma";
        if (astmaSlider.value >= 7)
            astmaText.text = "Kritisk astma";
        if (astmaSlider.value == 10)
            astmaText.text = "Fatal astma";

    }

}
