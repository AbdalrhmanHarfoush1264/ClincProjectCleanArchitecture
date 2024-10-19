using ClincProject.Data.Entities;
using ClincProject.Infrastructure.InfrastructureBases;
using ClincProject.Service.Abstracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ClincProject.Service.Implementations
{
    public class DocumentService : IDocumentService
    {
        #region Fileds
        private readonly IGenericRepository<Document> _documentRepository;
        private readonly ILogger<DocumentService> _logger;
        #endregion

        #region Constrcutors
        public DocumentService(IGenericRepository<Document> documentRepository,
            ILogger<DocumentService> logger)
        {
            _documentRepository = documentRepository;
            _logger = logger;
        }
        #endregion

        #region Functions
        public async Task<bool> CreateDocumentAsync(Document document)
        {
            try
            {
                var IsAdded = await _documentRepository.AddAsync(document);
                if (IsAdded == null)
                    return false;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in CreateDocumentAsync");
                throw;
            }

        }

        public async Task<bool> EditDocumentAsync(Document document)
        {
            try
            {
                var isUpdated = await _documentRepository.UpdateAsync(document);
                return isUpdated;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in EditDocumentAsync");
                throw;
            }

        }

        public async Task<bool> DeleteDocumentAsync(Document document)
        {
            try
            {
                var IsDeleted = await _documentRepository.DeleteAsync(document);
                return IsDeleted;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in DeleteDocumentAsync");
                throw;
            }

        }

        public async Task<List<Document>> GetDocumentListAsync()
        {
            try
            {
                var result = await _documentRepository.GetTableNoTracking()
                    .Include(x => x.Appointment.Doctor)
                    .Include(x => x.DocumentType).ToListAsync();

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in GetDocumentListAsync");
                throw;
            }
        }

        public async Task<Document> GetDocumentByIdAsync(int Id)
        {
            try
            {
                var result = await _documentRepository.GetTableNoTracking()
                    .Where(x => x.DocumentId == Id)
                    .Include(x => x.Appointment.Doctor)
                    .Include(x => x.DocumentType).FirstOrDefaultAsync();

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in GetDocumentByIdAsync");
                throw;
            }
        }

        public async Task<bool> IsDocumentExistByIdAsync(int Id)
        {
            try
            {
                var IsExist = await _documentRepository.GetTableNoTracking().
                   Where(x => x.DocumentId == Id)
                   .AnyAsync();

                return IsExist;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in IsDocumentExistByIdAsync");
                throw;
            }

        }

        public IQueryable<Document> FilterDocumentPaginatedQuerable(string? doctorName = null, string? typeName = null)
        {
            try
            {
                var query = _documentRepository.GetTableNoTracking()
                    .Include(x => x.DocumentType)
                    .Include(x => x.Appointment.Doctor)
                    .AsQueryable();


                if (doctorName != null)
                {
                    query = query.Where(x => (x.Appointment.Doctor.FirstName.ToLower() + " " +
                    x.Appointment.Doctor.LastName.ToLower()) == doctorName.ToLower());
                }
                else if (typeName != null)
                {
                    query = query.Where(x => x.DocumentType.TypeName.ToLower() == typeName.ToLower());
                }

                return query;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in FilterDocumentPaginatedQuerable");
                throw;
            }
        }
        #endregion
    }
}
