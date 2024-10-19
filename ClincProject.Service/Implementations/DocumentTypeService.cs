using ClincProject.Data.Entities;
using ClincProject.Infrastructure.InfrastructureBases;
using ClincProject.Service.Abstracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ClincProject.Service.Implementations
{
    public class DocumentTypeService : IDocumentTypeService
    {
        #region Fileds
        private readonly IGenericRepository<DocumentType> _documentTypeRepository;
        private readonly ILogger<DocumentTypeService> _logger;
        private readonly IGenericRepository<Document> _documentRepository;

        #endregion

        #region Constructors

        public DocumentTypeService(IGenericRepository<DocumentType> documentTypeRepository,
            ILogger<DocumentTypeService> logger, IGenericRepository<Document> documentRepository)
        {
            _logger = logger;
            _documentRepository = documentRepository;
            _documentTypeRepository = documentTypeRepository;
        }
        #endregion

        #region Handle Functions

        public async Task<bool> CreateDocumentTypeAsync(DocumentType documentType)
        {
            try
            {
                var IsAdded = await _documentTypeRepository.AddAsync(documentType);
                if (IsAdded == null)
                    return false;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in CreateDocumentTypeAsync");
                throw;
            }

        }
        public async Task<bool> EditDocumentTypeAsync(DocumentType documentType)
        {
            try
            {
                var isUpdated = await _documentTypeRepository.UpdateAsync(documentType);
                return isUpdated;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in EditDocumentTypeAsync");
                throw;
            }
        }
        public async Task<bool> DeleteDocumentTypeAsync(DocumentType documentType)
        {
            try
            {
                var AnyDocumentUseThisId = await _documentRepository.GetTableNoTracking()
                    .Where(x => x.DocumentTypeId == documentType.DocumentTypeId).AnyAsync();

                if (AnyDocumentUseThisId)
                    return false;

                var IsDeleted = await _documentTypeRepository.DeleteAsync(documentType);
                return IsDeleted;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in DeleteDocumentTypeAsync");
                throw;
            }
        }
        public async Task<DocumentType> GetDocumentTypeByIdAsync(int Id)
        {
            try
            {
                var result = await _documentTypeRepository.GetTableNoTracking()
                    .Where(x => x.DocumentTypeId == Id).FirstOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in GetDocumentTypeByIdAsync");
                throw;
            }
        }
        public async Task<bool> IsDocumentTypeExistByIdAsync(int Id)
        {
            try
            {
                var IsExist = await _documentTypeRepository.GetTableNoTracking().
                   Where(x => x.DocumentTypeId == Id)
                   .AnyAsync();

                return IsExist;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in IsDocumentTypeExistByIdAsync");
                throw;
            }

        }
        public async Task<bool> IsDocumentTypeExistByNameAsync(string typeName)
        {
            try
            {
                var IsExist = await _documentTypeRepository.GetTableNoTracking().
                   Where(x => x.TypeName.ToLower() == typeName.ToLower())
                   .AnyAsync();

                return IsExist;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in IsDocumentTypeExistByNameAsync");
                throw;
            }

        }
        public async Task<List<DocumentType>> GetDocumentTypeAsync()
        {
            try
            {
                var list = await _documentTypeRepository.GetTableNoTracking().ToListAsync();
                return list;
            }
            catch (Exception ex)
            {

                _logger.LogDebug(ex, "Error in GetDocumentTypeAsync");
                throw;
            }
        }
        #endregion
    }
}