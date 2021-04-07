namespace Fortnox.SDK.Search
{
    public class VoucherSearch : BaseSearch
    {
		[SearchParameter("sortby")]
		public Sort.By.Voucher? SortBy { get; set; }

		[SearchParameter("filter")]
		public Filter.Voucher? FilterBy { get; set; }


		[SearchParameter]
		public string CostCenter { get; set; }

		[SearchParameter]
		public string VoucherSeries { get; set; }
    }
}
