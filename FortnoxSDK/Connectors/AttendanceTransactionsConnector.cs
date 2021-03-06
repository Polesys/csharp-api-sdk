using System;
using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Search;
using Fortnox.SDK.Utility;

// ReSharper disable UnusedMember.Global

namespace Fortnox.SDK.Connectors
{
    /// <remarks/>
    public class AttendanceTransactionsConnector : SearchableEntityConnector<AttendanceTransaction, AttendanceTransactionSubset, AttendanceTransactionsSearch>, IAttendanceTransactionsConnector
	{

        /// <remarks/>
        public AttendanceTransactionsConnector()
		{
			Resource = "attendancetransactions";
		}

        /// <summary>
        /// Gets a attendenceTransaction
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="date"></param>
        /// <param name="code"></param>
        /// <returns>The found attendanceTransaction</returns>
        public AttendanceTransaction Get(string employeeId, DateTime? date, AttendanceCauseCode? code)
        {
			return GetAsync(employeeId, date, code).GetResult();
        }

        /// <summary>
        /// Updates a attendanceTransaction
        /// </summary>
        /// <param name="attendanceTransaction">The attendanceTransaction to update</param>
        /// <returns>The updated attendanceTransaction</returns>
        public AttendanceTransaction Update(AttendanceTransaction attendanceTransaction)
        {
			return UpdateAsync(attendanceTransaction).GetResult();
        }

        /// <summary>
        /// Creates a new attendanceTransaction
        /// </summary>
        /// <param name="attendanceTransaction">The attendanceTransaction to create</param>
        /// <returns>The created attendanceTransaction</returns>
        public AttendanceTransaction Create(AttendanceTransaction attendanceTransaction)
        {
			return CreateAsync(attendanceTransaction).GetResult();
        }

        /// <summary>
        /// Deletes a attendanceTransaction
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="date"></param>
        /// <param name="code"></param>
        public void Delete(string employeeId, DateTime? date, AttendanceCauseCode? code)
        {
			DeleteAsync(employeeId, date, code).GetResult();
        }

        /// <summary>
        /// Gets a list of attendanceTransactions
        /// </summary>
        /// <returns>A list of attendanceTransactions</returns>
        public EntityCollection<AttendanceTransactionSubset> Find(AttendanceTransactionsSearch searchSettings)
        {
			return FindAsync(searchSettings).GetResult();
        }

        public async Task<EntityCollection<AttendanceTransactionSubset>> FindAsync(AttendanceTransactionsSearch searchSettings)
        {
            return await BaseFind(searchSettings).ConfigureAwait(false);
        }
        public async Task DeleteAsync(string employeeId, DateTime? date, AttendanceCauseCode? code)
        {
            await BaseDelete(employeeId, date?.ToString(APIConstants.DateFormat), code?.GetStringValue()).ConfigureAwait(false);
        }
        public async Task<AttendanceTransaction> CreateAsync(AttendanceTransaction attendanceTransaction)
        {
            return await BaseCreate(attendanceTransaction).ConfigureAwait(false);
        }
        public async Task<AttendanceTransaction> UpdateAsync(AttendanceTransaction attendanceTransaction)
        {
            return await BaseUpdate(attendanceTransaction, attendanceTransaction.EmployeeId, attendanceTransaction.Date?.ToString(APIConstants.DateFormat), attendanceTransaction.CauseCode?.GetStringValue()).ConfigureAwait(false);
        }
        public async Task<AttendanceTransaction> GetAsync(string employeeId, DateTime? date, AttendanceCauseCode? code)
        {
            return await BaseGet(employeeId, date?.ToString(APIConstants.DateFormat), code?.GetStringValue()).ConfigureAwait(false);
        }
	}
}
