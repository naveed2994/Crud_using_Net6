using Application.Customers.CommandHandlers;
using Application.Customers.Queries;
using Application.Customers.ReadModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Serilog;
using System.Text;
using UI.Helpers;

namespace UI.Controllers

{
    public class ProductController : Controller
    {
        private IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            //var response = await _mediator.Send(new CustomerList());
            //return response;
            return View();
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<string> GetAllCustomers(string sEcho, int iDisplayStart, int iDisplayLength, string? nameSearch, string? fnameSearch, string? phone, DateTime? createdOn, SearchModel search, string[] aoColumns, string sSearch)
        {
            //var searchValue = Request.Form.TryGetValue("search[value]",)[0];
            var response = await _mediator.Send(new CustomerList(iDisplayStart, iDisplayLength, sSearch, nameSearch, fnameSearch, phone, createdOn));

            StringBuilder sb = new StringBuilder();
            sb.Clear();
            sb.Append("{");
            sb.Append("\"sEcho\": ");
            sb.Append(sEcho);
            sb.Append(",");
            sb.Append("\"iTotalRecords\": ");
            sb.Append(10);
            sb.Append(",");
            sb.Append("\"iTotalDisplayRecords\": ");
            sb.Append(10);
            sb.Append(",");
            sb.Append("\"aaData\": ");
            sb.Append(JsonConvert.SerializeObject(response));
            sb.Append("}");
            return sb.ToString();

            //return response;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<bool> CreateCustomer([FromBody] CreateCustomerCommand model)
        {
            var res = await _mediator.Send(model);
            if (res != Guid.Empty)
            {
                return true;
            }
            return false;
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<bool> UpdateCustomer([FromBody] UpdateCustomerCommand model)
        {
            var res = await _mediator.Send(model);
            if (res != Guid.Empty)
            {
                return true;
            }
            return false;
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> AddCustomer(Guid? id)
        {
            if (id != null)
            {
                var _id = (Guid)id;
                var res = await _mediator.Send(new GetCustomerDetail(_id));
                return PartialView("AddCustomer", res);
            }
            return PartialView("AddCustomer", new CustomersModel());
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<bool> Delete([FromBody] Guid id)
        {
            var response = await _mediator.Send(new DeleteCommand(id));
            return response;
        }
    }
}
