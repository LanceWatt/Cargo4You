using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace API.Domain
{
    public class QuoteDataRepository : IQuoteDataRepository
    {
        private readonly DataContext _context;

        public QuoteDataRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> AddQuoteRequestData(QuoteSubmissionData quoteSubmissionData)
        {
            _context.QuoteRequestData.Add(quoteSubmissionData);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteQuoteRequestData(QuoteSubmissionData quoteSubmissionData)
        {
            _context.QuoteRequestData.Remove(quoteSubmissionData);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<QuoteSubmissionData>> GetAllQuoteRequestData()
        {
            return await _context.QuoteRequestData.ToListAsync();
        }

        public async Task<QuoteSubmissionData> GetQuoteRequestDataById(int id)
        {
            return await _context.QuoteRequestData.FindAsync(id);
        }

        public async Task<bool> UpdateQuoteRequestData(QuoteSubmissionData quoteSubmissionData)
        {
            _context.Entry(quoteSubmissionData).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}