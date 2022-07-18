using Application.Customers.ReadModels;
using MediatR;

namespace Application.Customers.Queries
{
    public class InvoiceList : IRequest<IEnumerable<InvoiceModel>>
    {
        public int PageNo { get; set; }

        public InvoiceList(int pageNo, int pageSize, string searchText)
        {
            PageNo = pageNo;
            PageSize = pageSize;
            SearchText = searchText;
        }

        public int PageSize { get; set; }
        public string SearchText { get; set; }

    }
}
