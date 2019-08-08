using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    /**
     * Interface that every player class needs to implement
     *  Set all values.
     */
    #region BaseStats
    [SerializeField]
    private int _Level;
    public int Level
    {
        get { return _Level; }
        set { _Level = value; }
    }
    
    [SerializeField]
    private int _Luk;
    public int Luk
    {
        get { return _Luk; }
        set { _Luk = value; }
    }
    [SerializeField]
    private int _Dex;
    public int Dex
    {
        get { return _Dex; }
        set { _Dex = value; }
    }
    [SerializeField]
    private int _Str;
    public int Str
    {
        get { return _Str; }
        set { _Str = value; }
    }
    [SerializeField]
    private int _Int;
    public int Int
    {
        get { return _Int; }
        set { _Int = value; }
    }
    [SerializeField]
    private int _Att;
    public int Attack
    {
        get { return _Att; }
        set { _Att = value; }
    }
    [SerializeField]
    private int _StarForce;
    public int SF
    {
        get { return _StarForce; }
        set { _StarForce = value; }
    }
    [SerializeField]
    private int _ArcaneForce;
    public int AF
    {
        get { return _ArcaneForce; }
        set { _ArcaneForce = value; }
    }

    #endregion

    #region Bonus Stats

    [SerializeField]
    private float _PerAtt;
    public float PerAtt
    {
        get { return _PerAtt; }
        set { _PerAtt = value; }
    }

    private float _TotalAtt;
    public float TotalAtt
    {
        get { return _TotalAtt; }
        set { _TotalAtt = value; }
    }

    #endregion

    private void Start()
    {
        TotalAtt = Attack * (PerAtt/100);
    }
}
