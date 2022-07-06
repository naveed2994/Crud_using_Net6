using Application.Customers.ReadModels;
using MediatR;

namespace Application.Customers.Queries
{
    public class CustomerList : IRequest<IEnumerable<CustomersModel>>
    {
        public CustomerList(int PageNo, int PageSize, string SearchText, string? nameSearch, string? fnameSearch, string? phone, DateTime? createdOn)
        {
            this.SearchText = SearchText;
            this.PageNo = PageNo;
            this.PagSize = PageSize;
            this.NameSearch = nameSearch;
            this.FnameSearch = fnameSearch;
            this.Phone = phone;
            this.CreatedOn = createdOn;
        }

        public string SearchText { get; set; }
        public int PageNo { get;  set; }
        public int PagSize { get;  set; }
        public string? NameSearch { get; set; }
        public string? FnameSearch { get; set; }
        public string? Phone { get; set; }
        public DateTime? CreatedOn { get; set; }

    }
}
