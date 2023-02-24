using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Models;

namespace API.Domain
{
    public interface IQuoteDataRepository
    {
        Task<QuoteSubmissionData> GetQuoteRequestDataById(int id);
        Task<IEnumerable<QuoteSubmissionData>> GetAllQuoteRequestData();
        Task<bool> AddQuoteRequestData(QuoteSubmissionData quoteRequestData);
        Task<bool> UpdateQuoteRequestData(QuoteSubmissionData quoteRequestData);
        Task<bool> DeleteQuoteRequestData(QuoteSubmissionData quoteRequestData);
    }
}