namespace ValidationAttributes.Attributes
{
    class MyRequiredAttribute : MyValidationAttribute
    {
        public override bool IsValid(object obj)
        {
            string input = (string)obj;

            return !string.IsNullOrEmpty(input);
        }
    }
}
