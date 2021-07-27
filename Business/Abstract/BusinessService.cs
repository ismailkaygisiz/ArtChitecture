using Business.Constants;
using Core.Business;

namespace Business.Concrete
{
    public class BusinessService : ServiceBase
    {
        protected readonly BusinessMessages _businessMessages;

        public BusinessService()
        {
            _businessMessages = new BusinessMessages();
        }
    }
}