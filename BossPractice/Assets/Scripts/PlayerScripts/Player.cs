using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    /**
     * floaterface that every player class needs to implement
     *  Set all values.
     */
    #region BaseStats
    [SerializeField]
    private float _Level;
    public float Level
    {
        get { return _Level; }
        set { _Level = value; }
    }

    [SerializeField]
    private float _Luk;
    public float Luk
    {
        get { return _Luk; }
        set { _Luk = value; }
    }
    [SerializeField]
    private float _Dex;
    public float Dex
    {
        get { return _Dex; }
        set { _Dex = value; }
    }
    [SerializeField]
    private float _Str;
    public float Str
    {
        get { return _Str; }
        set { _Str = value; }
    }
    [SerializeField]
    private float _Int;
    public float Int
    {
        get { return _Int; }
        set { _Int = value; }
    }
    [SerializeField]
    private float _Att;
    public float Attack
    {
        get { return _Att; }
        set { _Att = value; }
    }
    [SerializeField]
    private float _StarForce;
    public float SF
    {
        get { return _StarForce; }
        set { _StarForce = value; }
    }
    [SerializeField]
    private float _ArcaneForce;
    public float AF
    {
        get { return _ArcaneForce; }
        set { _ArcaneForce = value; }
    }
    [SerializeField]
    private float _Health;
    public float Health
    {
        get { return _Health; }
        set { _Health = value; }
    }

    [SerializeField]
    private float _Experiance;
    public float Experiance
    {
        get { return _Experiance; }
        set { _Experiance = value; }
    }
    [SerializeField]
    private float _IgnoreDefence;
    public float IED
    {
        get { return _IgnoreDefence; }
        set { _IgnoreDefence = value; }
    }
    [SerializeField]
    private float _Damage;
    public float DamagePercent
    {
        get { return _Damage; }
        set { _Damage = value; }
    }
    [SerializeField]
    private float _FinalDamage;
    public float FinalDamagePercent
    {
        get { return _FinalDamage; }
        set { _FinalDamage = value; }
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
    [SerializeField]
    private float _TotalAtt;
    public float TotalAtt
    {
        get { return _TotalAtt; }
        set { _TotalAtt = value; }
    }

    [SerializeField]
    private float _UpperRange;
    public float UpperRange
    {
        get { return _UpperRange; }
        set { _UpperRange = value; }
    }
    [SerializeField]
    private float _LowerRange;
    public float LowerRange
    {
        get { return _LowerRange; }
        set { _LowerRange = value; }
    }
    [SerializeField]
    private float _WeaponMultiplier;
    public float Multiplier
    {
        get { return _WeaponMultiplier; }
        set { _WeaponMultiplier = value; }
    }

    #endregion

}


//Upper Actual Damage Range: { Multiplier * StatValue * TotalATT/100} rounded off
//Lower Actual Damage Range: { UpperActual * Mastery% /100} rounded off