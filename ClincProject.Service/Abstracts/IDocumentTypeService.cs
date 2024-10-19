using ClincProject.Data.Entities;

namespace ClincProject.Service.Abstracts
{
    public interface IDocumentTypeService
    {
        public Task<bool> CreateDocumentTypeAsync(DocumentType documentType);
        public Task<bool> EditDocumentTypeAsync(DocumentType documentType);
        public Task<bool> DeleteDocumentTypeAsync(DocumentType documentType);
        public Task<DocumentType> GetDocumentTypeByIdAsync(int Id);
        public Task<bool> IsDocumentTypeExistByIdAsync(int Id);
        public Task<bool> IsDocumentTypeExistByNameAsync(string typeName);
        public Task<List<DocumentType>> GetDocumentTypeAsync();
    }
}
