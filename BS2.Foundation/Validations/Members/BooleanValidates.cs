namespace BS2.Foundation.Validations.Members
{
    public partial class MemberValidates
    {
        public MemberValidates IsEquals(bool value, bool expected, string message, params string[] memberNames)
        {
            var success = value == expected;
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates IsNotEquals(bool value, bool unexpected, string message, params string[] memberNames)
        {
            var success = value != unexpected;
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates IsFalse(bool value, string message, params string[] memberNames)
        {
            var success = value == false;
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates IsTrue(bool value, string message, params string[] memberNames)
        {
            var success = value == true;
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates IsNotNullAndTrue(bool? value, string message, params string[] memberNames)
        {
            var success = value.HasValue && value.Value == true;
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates IsNotNullAndFalse(bool? value, string message, params string[] memberNames)
        {
            var success = value.HasValue && value.Value == false;
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates Not(bool value, string message, params string[] memberNames)
        {
            var success = !value;
            return Compute(success, value, message, memberNames);
        }
    }
}