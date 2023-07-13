using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {

        ICustomerDal _customerService;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerService = customerDal;
        }

        public IResult Add(Customer customer)
        {
            _customerService.Add(customer);

            return new SuccesResult(Messages.Added);
        }

        public IResult Delete(Customer customer)
        {
            _customerService.Delete(customer);
            return new SuccesResult(Messages.Added);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccesDataResult<List<Customer>>(_customerService.GetAll(), Messages.ProductListed);
        }

        public IDataResult<Customer> GetById(int customerId)
        {
            return new SuccesDataResult<Customer>(_customerService.Get(c => c.Id == customerId), Messages.ProductListed);
        }

        public IResult Update(Customer customer)
        {
            _customerService.Update(customer);

            return new SuccesResult(Messages.Updated);
        }
    }
}
