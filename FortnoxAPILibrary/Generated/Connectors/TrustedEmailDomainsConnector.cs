using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class TrustedEmailDomainsConnector : EntityConnector<TrustedEmailDomain, EntityCollection<TrustedEmailDomain>, Sort.By.TrustedEmailDomains?>
	{
	    /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter("filter")]
		public Filter.TrustedEmailDomains? FilterBy { get; set; }

        /// <remarks/>
		public TrustedEmailDomainsConnector()
		{
			Resource = "emailtrusteddomains";
		}

		/// <summary>
		/// Find a trustedEmailDomains based on id
		/// </summary>
		/// <param name="id">Identifier of the trustedEmailDomains to find</param>
		/// <returns>The found trustedEmailDomains</returns>
		public TrustedEmailDomain Get(int? id)
		{
			return BaseGet(id.ToString());
		}

		/// <summary>
		/// Creates a new trustedEmailDomains
		/// </summary>
		/// <param name="trustedEmailDomains">The trustedEmailDomains to create</param>
		/// <returns>The created trustedEmailDomains</returns>
		public TrustedEmailDomain Create(TrustedEmailDomain trustedEmailDomains)
		{
			return BaseCreate(trustedEmailDomains);
		}

		/// <summary>
		/// Deletes a trustedEmailDomains
		/// </summary>
		/// <param name="id">Identifier of the trustedEmailDomains to delete</param>
		public void Delete(int? id)
		{
			BaseDelete(id.ToString());
		}

		/// <summary>
		/// Gets a list of trustedEmailDomainss
		/// </summary>
		/// <returns>A list of trustedEmailDomainss</returns>
		public EntityCollection<TrustedEmailDomain> Find()
		{
			return BaseFind();
		}
    }
}
