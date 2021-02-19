using System.Text.RegularExpressions;

namespace HBC.Controllers
{
    public interface IValidatePostcodes
    {
        public bool CheckPostcode(string postcode);
    }

    public class PostcodeValidator : IValidatePostcodes
    {
        public bool CheckPostcode(string postcode)
        {
            Regex postcodeRegex = new Regex(@"[A-Za-z][1-9][1-9][A-Za-z]{2}");

            var matches = postcodeRegex.Matches(postcode);

            return matches.Count > 0;
        }
    }
}