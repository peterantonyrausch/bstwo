namespace BS2.Foundation.Validations.Basics
{
    public partial class BasicValidates
    {
        public BasicValidates IsEquals(bool value, bool expected)
        {
            var success = value == expected;
            return Compute(success, value);
        }

        public BasicValidates IsNotEquals(bool value, bool unexpected)
        {
            var success = value != unexpected;
            return Compute(success, value);
        }

        public BasicValidates IsFalse(bool value)
        {
            var success = value == false;
            return Compute(success, value);
        }

        public BasicValidates IsTrue(bool value)
        {
            var success = value == true;
            return Compute(success, value);
        }

        public BasicValidates IsNotNullAndTrue(bool? value)
        {
            var success = value.HasValue && value.Value == true;
            return Compute(success, value);
        }

        public BasicValidates IsNotNullAndFalse(bool? value)
        {
            var success = value.HasValue && value.Value == false;
            return Compute(success, value);
        }

        public BasicValidates Not(bool value)
        {
            var success = !value;
            return Compute(success, value);
        }
    }
}