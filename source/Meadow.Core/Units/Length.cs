﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;
using Meadow.Units.Conversions;

namespace Meadow.Units
{
    /// <summary>
    /// Represents Length
    /// </summary>
    [Serializable]
    [ImmutableObject(false)]
    [StructLayout(LayoutKind.Sequential)]
    public struct Length : IUnitType, IComparable, IFormattable, IConvertible, IEquatable<double>, IComparable<double>
    {
        /// <summary>
        /// Creates a new `Length` object.
        /// </summary>
        /// <param name="value">The Length value.</param>
        /// <param name="type">Meters by default.</param>
        public Length(double value, UnitType type = UnitType.Meters)
        {
            //always store reference value
            Unit = type;
            Value = LengthConversions.Convert(value, type, UnitType.Meters);
        }

        /// <summary>
        /// The Length expressed as a value.
        /// </summary>
        public double Value { get; set; }
        //{
        //    get => LengthConversions.Convert(Value, UnitType.Meters, Unit);
        //    set => Value = LengthConversions.Convert(value, Unit, UnitType.Meters);
        //}

        //private double Value;

        /// <summary>
        /// The unit that describes the value.
        /// </summary>
        public UnitType Unit { get; set; }

        /// <summary>
        /// The type of units available to describe the Length.
        /// </summary>
        public enum UnitType
        {
            Kilometers,
            Meters,
            Centimeters,
            Decimeters,
            Millimeters,
            Microns,
            Nanometers,
            Miles,
            NauticalMiles,
            Yards,
            Feet,
            Inches,
        }


        public double Kilometers => From(UnitType.Kilometers);
        public double Meters => From(UnitType.Meters);
        public double Centimeters => From(UnitType.Centimeters);
        public double Decimeters => From(UnitType.Decimeters);
        public double Millimeters => From(UnitType.Millimeters);
        public double Microns => From(UnitType.Microns);
        public double Nanometer => From(UnitType.Nanometers);
        public double Miles => From(UnitType.Miles);
        public double NauticalMiles => From(UnitType.NauticalMiles);
        public double Yards => From(UnitType.Yards);
        public double Feet => From(UnitType.Feet);
        public double Inches => From(UnitType.Inches);

        [Pure]
        public double From(UnitType convertTo)
        {
            return LengthConversions.Convert(Value, UnitType.Meters, convertTo);
        }

        [Pure]
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) { return false; }
            if (Equals(this, obj)) { return true; }
            return obj.GetType() == GetType() && Equals((Length)obj);
        }

        [Pure] public bool Equals(Length other) => Value == other.Value;

        [Pure] public override int GetHashCode() => Value.GetHashCode();

        [Pure] public static bool operator ==(Length left, Length right) => Equals(left.Meters, right.Meters);
        [Pure] public static bool operator !=(Length left, Length right) => !Equals(left.Meters, right.Meters);
        [Pure] public int CompareTo(Length other) => Equals(this, other) ? 0 : Value.CompareTo(other.Value);
        [Pure] public static bool operator <(Length left, Length right) => Comparer<double>.Default.Compare(left.Meters, right.Meters) < 0;
        [Pure] public static bool operator >(Length left, Length right) => Comparer<double>.Default.Compare(left.Meters, right.Meters) > 0;
        [Pure] public static bool operator <=(Length left, Length right) => Comparer<double>.Default.Compare(left.Meters, right.Meters) <= 0;
        [Pure] public static bool operator >=(Length left, Length right) => Comparer<double>.Default.Compare(left.Meters, right.Meters) >= 0;

        [Pure] public static implicit operator Length(int value) => new Length(value);

        [Pure] public static Length operator +(Length lvalue, Length rvalue) => new Length(lvalue.Meters + rvalue.Meters, UnitType.Meters);
        [Pure] public static Length operator -(Length lvalue, Length rvalue) => new Length(lvalue.Meters - rvalue.Meters, UnitType.Meters);
        [Pure] public static Length operator /(Length lvalue, Length rvalue) => new Length(lvalue.Meters / rvalue.Meters, UnitType.Meters);
        [Pure] public static Length operator *(Length lvalue, Length rvalue) => new Length(lvalue.Meters * rvalue.Meters, UnitType.Meters);

        [Pure] public override string ToString() => Value.ToString();
        [Pure] public string ToString(string format, IFormatProvider formatProvider) => Value.ToString(format, formatProvider);

        /// <summary>
        /// Returns the absolute length, that is, the length without regards to
        /// negative polarity
        /// </summary>
        /// <returns></returns>
        [Pure] public Length Abs() { return new Length(Math.Abs(this.Meters), UnitType.Meters); }


        // IComparable
        [Pure] public int CompareTo(object obj) => Value.CompareTo(obj);

        [Pure] public TypeCode GetTypeCode() => Value.GetTypeCode();
        [Pure] public bool ToBoolean(IFormatProvider provider) => ((IConvertible)Value).ToBoolean(provider);
        [Pure] public byte ToByte(IFormatProvider provider) => ((IConvertible)Value).ToByte(provider);
        [Pure] public char ToChar(IFormatProvider provider) => ((IConvertible)Value).ToChar(provider);
        [Pure] public DateTime ToDateTime(IFormatProvider provider) => ((IConvertible)Value).ToDateTime(provider);
        [Pure] public decimal ToDecimal(IFormatProvider provider) => ((IConvertible)Value).ToDecimal(provider);
        [Pure] public double ToDouble(IFormatProvider provider) => Value;
        [Pure] public short ToInt16(IFormatProvider provider) => ((IConvertible)Value).ToInt16(provider);
        [Pure] public int ToInt32(IFormatProvider provider) => ((IConvertible)Value).ToInt32(provider);
        [Pure] public long ToInt64(IFormatProvider provider) => ((IConvertible)Value).ToInt64(provider);
        [Pure] public sbyte ToSByte(IFormatProvider provider) => ((IConvertible)Value).ToSByte(provider);
        [Pure] public float ToSingle(IFormatProvider provider) => ((IConvertible)Value).ToSingle(provider);
        [Pure] public string ToString(IFormatProvider provider) => Value.ToString(provider);
        [Pure] public object ToType(Type conversionType, IFormatProvider provider) => ((IConvertible)Value).ToType(conversionType, provider);
        [Pure] public ushort ToUInt16(IFormatProvider provider) => ((IConvertible)Value).ToUInt16(provider);
        [Pure] public uint ToUInt32(IFormatProvider provider) => ((IConvertible)Value).ToUInt32(provider);
        [Pure] public ulong ToUInt64(IFormatProvider provider) => ((IConvertible)Value).ToUInt64(provider);

        [Pure]
        public int CompareTo(double? other)
        {
            return (other is null) ? -1 : (Value).CompareTo(other.Value);
        }

        [Pure] public bool Equals(double? other) => Value.Equals(other);
        [Pure] public bool Equals(double other) => Value.Equals(other);
        [Pure] public int CompareTo(double other) => Value.CompareTo(other);
        // can't do this.
        //public int CompareTo(double? other) => Value.CompareTo(other);
    }
}