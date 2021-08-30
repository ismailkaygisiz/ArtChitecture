using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;

namespace Core.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics)
        {
            foreach (var logic in logics)
                if (!logic.Success)
                    return logic;

            return new SuccessResult();
        }
    }
}