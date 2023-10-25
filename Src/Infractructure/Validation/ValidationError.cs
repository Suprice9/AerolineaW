using FluentValidation.Results;

namespace Infractructure.Validation
{
    public static class ValidationError
    {
        public static List<string> ToStringList(this List<ValidationFailure> failures)
        {
            List<string> list = new();
            foreach (var item in failures)
            {
                list.Add(item.ErrorMessage);
            }

            return list;
        }
    }
}
