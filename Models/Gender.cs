namespace HRaport.Models
{
    public enum Gender
    {
        Male,
        Female,
        NonBinary
    }

    public static class GenderExtensionMethods
    {
        public static string ToPolishString(this Gender gender)
        {
            return gender switch
            {
                Gender.Male => "Mężczyzna",
                Gender.Female => "Kobieta",
                Gender.NonBinary => "Niebinarne",
                _ => gender.ToString()
            };
        }
    }
}
