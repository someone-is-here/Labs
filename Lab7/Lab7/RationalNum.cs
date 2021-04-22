using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Lab7 {
    class RationalNum : IComparable<RationalNum>, IFormattable, IConvertible, ICloneable {
        private int Numerator { get; set; }
        private int denominator;
        private int Denominator {
            get {
                return denominator;
            }
            set {
                if (value != 0) {
                    denominator = value;
                }
            }
        }
        public RationalNum() {
            Numerator = 0;
            Denominator = 1;
        }
        public RationalNum(int numerator, int denominator) {
            Numerator = numerator;
            Denominator = denominator;
        }
        public RationalNum(int numerator) {
            Numerator = numerator;
            Denominator = 1;
        }
        public RationalNum(RationalNum obj) {
            Numerator = obj.Numerator;
            Denominator = obj.Denominator;
        }
        public static RationalNum operator +(RationalNum num1, RationalNum num2) {
            RationalNum obj = new RationalNum();
            if (num1.Denominator < 0) {
                num1.Denominator = -num1.Denominator;
                num1.Numerator = -num1.Numerator;
            }
            if (num2.Denominator < 0) {
                num2.Denominator = -num2.Denominator;
                num2.Numerator = -num2.Numerator;
            }
            obj.Numerator = num1.Numerator * num2.Denominator + num1.Denominator * num2.Numerator;
            obj.Denominator = num1.Denominator * num2.Denominator;
            if (obj.Numerator != 0) {
                int div = CommonDivisor(Math.Abs(obj.Numerator), Math.Abs(obj.Denominator));
                obj.Numerator /= div;
                obj.Denominator /= div;
            }
            return obj;
        }
        public override bool Equals(object obj) {
            if (obj is RationalNum newObj) {
                return (this.CompareTo(newObj) == 0);
            }
            return false;
        }
        public override int GetHashCode() {
            return 13 * (Numerator.GetHashCode() + Denominator.GetHashCode());
        }
        public static RationalNum operator -(RationalNum num1, RationalNum num2) {
            RationalNum obj = new RationalNum();
            if (num1.Denominator < 0) {
                num1.Denominator = -num1.Denominator;
                num1.Numerator = -num1.Numerator;
            }
            if (num2.Denominator < 0) {
                num2.Denominator = -num2.Denominator;
                num2.Numerator = -num2.Numerator;
            }
            obj.Numerator = num1.Numerator * num2.Denominator - num1.Denominator * num2.Numerator;
            obj.Denominator = num1.Denominator * num2.Denominator;
            if (obj.Numerator != 0) {
                int div = CommonDivisor(Math.Abs(obj.Numerator), Math.Abs(obj.Denominator));
                obj.Numerator /= div;
                obj.Denominator /= div;
            }
            return obj;
        }
        public static RationalNum operator *(RationalNum num1, RationalNum num2) {
            RationalNum obj = new RationalNum();
            if (num1.Denominator < 0) {
                num1.Denominator = -num1.Denominator;
                num1.Numerator = -num1.Numerator;
            }
            if (num2.Denominator < 0) {
                num2.Denominator = -num2.Denominator;
                num2.Numerator = -num2.Numerator;
            }
            obj.Numerator = num1.Numerator * num2.Numerator;
            obj.Denominator = num1.Denominator * num2.Denominator;
            if (obj.Numerator != 0) {
                int div = CommonDivisor(Math.Abs(obj.Numerator), Math.Abs(obj.Denominator));
                obj.Numerator /= div;
                obj.Denominator /= div;
            }
            return obj;
        }
        public static RationalNum operator /(RationalNum num1, RationalNum num2) {
            RationalNum temp = new RationalNum(num2.Denominator, num2.Numerator);
            return (num1 * temp);
        }
        public static bool operator >(RationalNum num1, RationalNum num2) {
            if (num1.Denominator < 0) {
                num1.Denominator = -num1.Denominator;
                num1.Numerator = -num1.Numerator;
            }
            if (num2.Denominator < 0) {
                num2.Denominator = -num2.Denominator;
                num2.Numerator = -num2.Numerator;
            }
            return (num1.Numerator * num2.Denominator > num2.Numerator * num1.Denominator);
        }
        public static bool operator <(RationalNum num1, RationalNum num2) {
            if (num1.Denominator < 0) {
                num1.Denominator = -num1.Denominator;
                num1.Numerator = -num1.Numerator;
            }
            if (num2.Denominator < 0) {
                num2.Denominator = -num2.Denominator;
                num2.Numerator = -num2.Numerator;
            }
            return (num1.Numerator * num2.Denominator < num2.Numerator * num1.Denominator);
        }
        public static bool operator >=(RationalNum num1, RationalNum num2) {
            if (num1.Denominator < 0) {
                num1.Denominator = -num1.Denominator;
                num1.Numerator = -num1.Numerator;
            }
            if (num2.Denominator < 0) {
                num2.Denominator = -num2.Denominator;
                num2.Numerator = -num2.Numerator;
            }
            return (num1.Numerator * num2.Denominator >= num2.Numerator * num1.Denominator);
        }
        public static bool operator <=(RationalNum num1, RationalNum num2) {
            if (num1.Denominator < 0) {
                num1.Denominator = -num1.Denominator;
                num1.Numerator = -num1.Numerator;
            }
            if (num2.Denominator < 0) {
                num2.Denominator = -num2.Denominator;
                num2.Numerator = -num2.Numerator;
            }
            return (num1.Numerator * num2.Denominator <= num2.Numerator * num1.Denominator);
        }
        public static bool operator ==(RationalNum num1, RationalNum num2) {
            if (num1.Denominator < 0) {
                num1.Denominator = -num1.Denominator;
                num1.Numerator = -num1.Numerator;
            }
            if (num2.Denominator < 0) {
                num2.Denominator = -num2.Denominator;
                num2.Numerator = -num2.Numerator;
            }
            return (num1.Numerator * num2.Denominator == num2.Numerator * num1.Denominator);
        }
        public static bool operator !=(RationalNum num1, RationalNum num2) {
            if (num1.Denominator < 0) {
                num1.Denominator = -num1.Denominator;
                num1.Numerator = -num1.Numerator;
            }
            if (num2.Denominator < 0) {
                num2.Denominator = -num2.Denominator;
                num2.Numerator = -num2.Numerator;
            }
            return (num1.Numerator * num2.Denominator != num2.Numerator * num1.Denominator);
        }
        public static implicit operator double(RationalNum num) {
            return (double)num.Numerator / num.Denominator;
        }
        public static explicit operator float(RationalNum num) {
            return (float)num.Numerator / num.Denominator;
        }
        public static explicit operator decimal(RationalNum num) {
            return (decimal)num.Numerator / num.Denominator;
        }
        public static explicit operator int(RationalNum num) {
            return num.Numerator / num.Denominator;
        }
        public static explicit operator long(RationalNum num) {
            return (long)num.Numerator / num.Denominator;
        }
        public int CompareTo(RationalNum num) {
            if (this > num) {
                return 1;
            } else if (this < num) {
                return -1;
            }
            return 0;
        }
        public override string ToString() {
            if (this.Denominator < 0) {
                this.Denominator = -this.Denominator;
                this.Numerator = -this.Numerator;
            }
            return $"{Numerator}/{Denominator}";
        }
        public string ToString(string format) {
            if (this.Denominator < 0) {
                this.Denominator = -this.Denominator;
                this.Numerator = -this.Numerator;
            }
            return this.ToString(format, CultureInfo.CurrentCulture);
        }
        public string ToString(string format, IFormatProvider provider) {
            if (String.IsNullOrEmpty(format)) {
                format = "F";
            }
            if (provider == null) {
                provider = CultureInfo.CurrentCulture;
            }
            if (this.Denominator < 0) {
                this.Denominator = -this.Denominator;
                this.Numerator = -this.Numerator;
            }
            switch (format.ToUpperInvariant()) {
                case "F":
                    return $"{(decimal)this.Numerator / this.Denominator}";
                case "E":
                    return $"{(double)this.Numerator / this.Denominator}";
                case "G":
                    return this.ToString();
                case "D":
                    return $"{(int)this.Numerator / this.Denominator}";
                default:
                    throw new FormatException(String.Format("The {0} format string is not supported.", format));
            }
        }
        private static int CommonDivisor(int num1, int num2) {
            int temp;
            while (num1 != num2) {
                if (num1 > num2) {
                    temp = num1;
                    num1 = num2;
                    num2 = temp;
                }
                num2 = num2 - num1;
            }
            return num1;
        }
        public object Clone() {
            return new RationalNum(Numerator, Denominator);
        }
        public TypeCode GetTypeCode() {
            return TypeCode.Object;
        }
        public static RationalNum Parse(string str) {
            if (TryParse(str, out RationalNum obj)) {
                return obj;
            } else {
                throw new Exception("String in incorrect format!");
            }
        }
        public static bool TryParse(string str, out RationalNum obj) {
            obj = null;
            Regex pattern1 = new Regex(@"^(-?\d+)/(-?\d+)$");
            Regex pattern2 = new Regex(@"^(-?\d+)$");
            Regex pattern4 = new Regex(@"^(-?\d+)[,|\.](\d+)$");
            if (pattern1.IsMatch(str)) {
                Match match = pattern1.Match(str);
                obj = new RationalNum(int.Parse(match.Groups[1].Value), int.Parse(match.Groups[2].Value));
                return true;
            } else if (pattern2.IsMatch(str)) {
                Match match = pattern2.Match(str);
                obj = new RationalNum(int.Parse(match.Groups[1].Value));
                return true;
            } else if (pattern4.IsMatch(str)) {
                Match match = pattern4.Match(str);
                int num = int.Parse(match.Groups[2].Value);
                int counter = 1;
                while (num > 9) {
                    num /= 10;
                    counter++;
                }
                if (match.Groups[1].Value[0] == '-') {
                    obj = new RationalNum(-(int.Parse(match.Groups[2].Value) + int.Parse(match.Groups[1].Value) * (int)Math.Pow(10, counter)), (int)Math.Pow(10, counter));
                } else {
                    obj = new RationalNum(int.Parse(match.Groups[2].Value) + int.Parse(match.Groups[1].Value) * (int)Math.Pow(10, counter), (int)Math.Pow(10, counter));
                }

                return true;
            }
            return false;
        }
        public bool ToBoolean(IFormatProvider provider) {
            return (this.Numerator == 0 ? true : false);
        }
        public char ToChar(IFormatProvider provider) {
            return Convert.ToChar((double)this, provider);
        }
        public sbyte ToSByte(IFormatProvider provider) {
            return Convert.ToSByte((double)this, provider);
        }
        public byte ToByte(IFormatProvider provider) {
            return Convert.ToByte((double)this, provider);
        }
        public short ToInt16(IFormatProvider provider) {
            return Convert.ToInt16((double)this, provider);
        }
        public ushort ToUInt16(IFormatProvider provider) {
            return Convert.ToUInt16((double)this, provider);
        }
        public int ToInt32(IFormatProvider provider) {
            return Convert.ToInt32((double)this, provider);
        }
        public uint ToUInt32(IFormatProvider provider) {
            return Convert.ToUInt32((double)this, provider);
        }
        public long ToInt64(IFormatProvider provider) {
            return Convert.ToInt64((double)this, provider);
        }
        public ulong ToUInt64(IFormatProvider provider) {
            return Convert.ToUInt64((double)this, provider);
        }
        public float ToSingle(IFormatProvider provider) {
            return Convert.ToSingle((double)this, provider);
        }
        public double ToDouble(IFormatProvider provider) {
            return (double)this;
        }
        public decimal ToDecimal(IFormatProvider provider) {
            return Convert.ToDecimal((double)this, provider);
        }
        public DateTime ToDateTime(IFormatProvider provider) {
            return Convert.ToDateTime((double)this, provider);
        }
        public string ToString(IFormatProvider provider) {
            return ToString("F", provider);
        }
        public object ToType(Type conversionType, IFormatProvider provider) {
            return Convert.ChangeType((double)this, conversionType);
        }
    }
}
