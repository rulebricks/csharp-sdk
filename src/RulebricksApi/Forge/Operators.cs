using System;
using System.Collections.Generic;
using RulebricksApi.Forge.Types;
using RulebricksApi.Forge.Fields;

namespace RulebricksApi.Forge
{
    public class BooleanField : Field
    {
        public BooleanField(string name, string description, bool defaultValue = false)
            : base(name, description, FieldType.Boolean, defaultValue)
        {
        }

        public Dictionary<string, object> IsTrue()
        {
            return BuildOperator("is true");
        }

        public Dictionary<string, object> IsFalse()
        {
            return BuildOperator("is false");
        }

        public Dictionary<string, object> Any()
        {
            return BuildOperator("any");
        }

        public override Dictionary<string, object> BuildOperator(string operatorName, params object[] args)
        {
            return new Dictionary<string, object>
            {
                { "field", Name },
                { "operator", operatorName },
                { "args", args }
            };
        }
    }

    public class NumberField : Field
    {
        public NumberField(string name, string description, double defaultValue = 0)
            : base(name, description, FieldType.Number, defaultValue)
        {
        }

        public Dictionary<string, object> Equals(double value)
        {
            return BuildOperator("equals", new Argument<double>(value, FieldType.Number).ToDict());
        }

        public Dictionary<string, object> DoesNotEqual(double value)
        {
            return BuildOperator("does not equal", new Argument<double>(value, FieldType.Number).ToDict());
        }

        public Dictionary<string, object> GreaterThan(double value)
        {
            return BuildOperator("greater than", new Argument<double>(value, FieldType.Number).ToDict());
        }

        public Dictionary<string, object> LessThan(double value)
        {
            return BuildOperator("less than", new Argument<double>(value, FieldType.Number).ToDict());
        }

        public Dictionary<string, object> GreaterThanOrEqualTo(double value)
        {
            return BuildOperator("greater than or equal to", new Argument<double>(value, FieldType.Number).ToDict());
        }

        public Dictionary<string, object> LessThanOrEqualTo(double value)
        {
            return BuildOperator("less than or equal to", new Argument<double>(value, FieldType.Number).ToDict());
        }

        public Dictionary<string, object> Between(double start, double end)
        {
            return BuildOperator("between",
                new Argument<double>(start, FieldType.Number).ToDict(),
                new Argument<double>(end, FieldType.Number).ToDict());
        }

        public Dictionary<string, object> NotBetween(double start, double end)
        {
            return BuildOperator("not between",
                new Argument<double>(start, FieldType.Number).ToDict(),
                new Argument<double>(end, FieldType.Number).ToDict());
        }

        public Dictionary<string, object> IsEven()
        {
            return BuildOperator("is even");
        }

        public Dictionary<string, object> IsOdd()
        {
            return BuildOperator("is odd");
        }

        public Dictionary<string, object> IsPositive()
        {
            return BuildOperator("is positive");
        }

        public Dictionary<string, object> IsNegative()
        {
            return BuildOperator("is negative");
        }

        public Dictionary<string, object> IsZero()
        {
            return BuildOperator("is zero");
        }

        public Dictionary<string, object> IsNotZero()
        {
            return BuildOperator("is not zero");
        }

        public Dictionary<string, object> Any()
        {
            return BuildOperator("any");
        }

        public override Dictionary<string, object> BuildOperator(string operatorName, params object[] args)
        {
            return new Dictionary<string, object>
            {
                { "field", Name },
                { "operator", operatorName },
                { "args", args }
            };
        }
    }

    public class StringField : Field
    {
        public StringField(string name, string description, string defaultValue = "")
            : base(name, description, FieldType.String, defaultValue)
        {
        }

        public Dictionary<string, object> Contains(string value)
        {
            return BuildOperator("contains", new Argument<string>(value, FieldType.String).ToDict());
        }

        public Dictionary<string, object> DoesNotContain(string value)
        {
            return BuildOperator("does not contain", new Argument<string>(value, FieldType.String).ToDict());
        }

        public Dictionary<string, object> Equals(string value)
        {
            return BuildOperator("equals", new Argument<string>(value, FieldType.String).ToDict());
        }

        public Dictionary<string, object> DoesNotEqual(string value)
        {
            return BuildOperator("does not equal", new Argument<string>(value, FieldType.String).ToDict());
        }

        public Dictionary<string, object> IsEmpty()
        {
            return BuildOperator("is empty");
        }

        public Dictionary<string, object> IsNotEmpty()
        {
            return BuildOperator("is not empty");
        }

        public Dictionary<string, object> StartsWith(string value)
        {
            return BuildOperator("starts with", new Argument<string>(value, FieldType.String).ToDict());
        }

        public Dictionary<string, object> EndsWith(string value)
        {
            return BuildOperator("ends with", new Argument<string>(value, FieldType.String).ToDict());
        }

        public Dictionary<string, object> IsIncludedIn(IEnumerable<string> values)
        {
            return BuildOperator("is included in", new Argument<IEnumerable<string>>(values, FieldType.List).ToDict());
        }

        public Dictionary<string, object> IsNotIncludedIn(IEnumerable<string> values)
        {
            return BuildOperator("is not included in", new Argument<IEnumerable<string>>(values, FieldType.List).ToDict());
        }

        public Dictionary<string, object> ContainsAnyOf(IEnumerable<string> values)
        {
            return BuildOperator("contains any of", new Argument<IEnumerable<string>>(values, FieldType.List).ToDict());
        }

        public Dictionary<string, object> DoesNotContainAnyOf(IEnumerable<string> values)
        {
            return BuildOperator("does not contain any of", new Argument<IEnumerable<string>>(values, FieldType.List).ToDict());
        }

        public Dictionary<string, object> IsOfLength(int length)
        {
            return BuildOperator("is of length", new Argument<int>(length, FieldType.Number).ToDict());
        }

        public Dictionary<string, object> IsNotOfLength(int length)
        {
            return BuildOperator("is not of length", new Argument<int>(length, FieldType.Number).ToDict());
        }

        public Dictionary<string, object> IsLongerThan(int length)
        {
            return BuildOperator("is longer than", new Argument<int>(length, FieldType.Number).ToDict());
        }

        public Dictionary<string, object> IsShorterThan(int length)
        {
            return BuildOperator("is shorter than", new Argument<int>(length, FieldType.Number).ToDict());
        }

        public Dictionary<string, object> IsUppercase()
        {
            return BuildOperator("is uppercase");
        }

        public Dictionary<string, object> IsLowercase()
        {
            return BuildOperator("is lowercase");
        }

        public Dictionary<string, object> IsNumeric()
        {
            return BuildOperator("is numeric");
        }

        public Dictionary<string, object> ContainsOnlyDigits()
        {
            return BuildOperator("contains only digits");
        }

        public Dictionary<string, object> ContainsOnlyLetters()
        {
            return BuildOperator("contains only letters");
        }

        public Dictionary<string, object> IsValidEmail()
        {
            return BuildOperator("is a valid email address");
        }

        public Dictionary<string, object> IsValidUrl()
        {
            return BuildOperator("is a valid URL");
        }

        public Dictionary<string, object> MatchesRegex(string pattern)
        {
            return BuildOperator("matches RegEx", new Argument<string>(pattern, FieldType.String).ToDict());
        }

        public Dictionary<string, object> Any()
        {
            return BuildOperator("any");
        }

        public override Dictionary<string, object> BuildOperator(string operatorName, params object[] args)
        {
            return new Dictionary<string, object>
            {
                { "field", Name },
                { "operator", operatorName },
                { "args", args }
            };
        }
    }

    public class DateField : Field
    {
        public DateField(string name, string description, DateTime? defaultValue = null)
            : base(name, description, FieldType.Date, defaultValue ?? DateTime.Now)
        {
        }

        public Dictionary<string, object> IsInThePast()
        {
            return BuildOperator("is in the past");
        }

        public Dictionary<string, object> IsInTheFuture()
        {
            return BuildOperator("is in the future");
        }

        public Dictionary<string, object> DaysAgo(int days)
        {
            return BuildOperator("days ago", new Argument<int>(days, FieldType.Number).ToDict());
        }

        public Dictionary<string, object> IsLessThanDaysAgo(int days)
        {
            return BuildOperator("is less than N days ago", new Argument<int>(days, FieldType.Number).ToDict());
        }

        public Dictionary<string, object> IsMoreThanDaysAgo(int days)
        {
            return BuildOperator("is more than N days ago", new Argument<int>(days, FieldType.Number).ToDict());
        }

        public Dictionary<string, object> DaysFromNow(int days)
        {
            return BuildOperator("days from now", new Argument<int>(days, FieldType.Number).ToDict());
        }

        public Dictionary<string, object> IsToday()
        {
            return BuildOperator("is today");
        }

        public Dictionary<string, object> IsThisWeek()
        {
            return BuildOperator("is this week");
        }

        public Dictionary<string, object> IsThisMonth()
        {
            return BuildOperator("is this month");
        }

        public Dictionary<string, object> IsThisYear()
        {
            return BuildOperator("is this year");
        }

        public Dictionary<string, object> After(DateTime date)
        {
            return BuildOperator("after", new Argument<DateTime>(date, FieldType.Date).ToDict());
        }

        public Dictionary<string, object> Before(DateTime date)
        {
            return BuildOperator("before", new Argument<DateTime>(date, FieldType.Date).ToDict());
        }

        public Dictionary<string, object> Between(DateTime start, DateTime end)
        {
            return BuildOperator("between",
                new Argument<DateTime>(start, FieldType.Date).ToDict(),
                new Argument<DateTime>(end, FieldType.Date).ToDict());
        }

        public Dictionary<string, object> Any()
        {
            return BuildOperator("any");
        }

        public override Dictionary<string, object> BuildOperator(string operatorName, params object[] args)
        {
            return new Dictionary<string, object>
            {
                { "field", Name },
                { "operator", operatorName },
                { "args", args }
            };
        }
    }

    public class ListField : Field
    {
        public ListField(string name, string description, IEnumerable<object>? defaultValue = null)
            : base(name, description, FieldType.List, defaultValue ?? Array.Empty<object>())
        {
        }

        public Dictionary<string, object> Contains(object value)
        {
            return BuildOperator("contains", new Argument<object>(value, FieldType.Generic).ToDict());
        }

        public Dictionary<string, object> DoesNotContain(object value)
        {
            return BuildOperator("does not contain", new Argument<object>(value, FieldType.Generic).ToDict());
        }

        public Dictionary<string, object> IsEmpty()
        {
            return BuildOperator("is empty");
        }

        public Dictionary<string, object> IsNotEmpty()
        {
            return BuildOperator("is not empty");
        }

        public Dictionary<string, object> IsOfLength(int length)
        {
            return BuildOperator("is of length", new Argument<int>(length, FieldType.Number).ToDict());
        }

        public Dictionary<string, object> ContainsAllOf(IEnumerable<object> values)
        {
            return BuildOperator("contains all of", new Argument<IEnumerable<object>>(values, FieldType.List).ToDict());
        }

        public Dictionary<string, object> ContainsAnyOf(IEnumerable<object> values)
        {
            return BuildOperator("contains any of", new Argument<IEnumerable<object>>(values, FieldType.List).ToDict());
        }

        public Dictionary<string, object> ContainsNoneOf(IEnumerable<object> values)
        {
            return BuildOperator("contains none of", new Argument<IEnumerable<object>>(values, FieldType.List).ToDict());
        }

        public Dictionary<string, object> ContainsDuplicates()
        {
            return BuildOperator("contains duplicates");
        }

        public Dictionary<string, object> DoesNotContainDuplicates()
        {
            return BuildOperator("does not contain duplicates");
        }

        public Dictionary<string, object> Any()
        {
            return BuildOperator("any");
        }

        public override Dictionary<string, object> BuildOperator(string operatorName, params object[] args)
        {
            return new Dictionary<string, object>
            {
                { "field", Name },
                { "operator", operatorName },
                { "args", args }
            };
        }
    }
}
