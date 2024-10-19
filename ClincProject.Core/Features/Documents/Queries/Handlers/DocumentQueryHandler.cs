using AutoMapper;
using ClincProject.Core.BasesCore;
using ClincProject.Core.Features.Documents.Queries.Models;
using ClincProject.Core.Features.Documents.Queries.Responses;
using ClincProject.Core.Wappers;
using ClincProject.Data.Entities;
using ClincProject.Service.Abstracts;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace ClincProject.Core.Features.Documents.Queries.Handlers
{
    public class DocumentQueryHandler : CusResponseHandler,
        IRequestHandler<GetDocumentListQuery, CusResponse<List<GetDocumentListResponse>>>,
        IRequestHandler<GetDocumentByIdQuery, CusResponse<GetSingleDocumentResponse>>,
        IRequestHandler<GetDocumentPaginatedQuery, PaginatedResult<GetDocumentPaginatedResponse>>
    {


        #region Fileds
        private readonly IDocumentService _documentService;
        private readonly IMapper _mapper;
        private ILogger<DocumentQueryHandler> _logger;
        #endregion

        #region Constructors
        public DocumentQueryHandler(IDocumentService documentService, IMapper mapper, ILogger<DocumentQueryHandler> logger)
        {
            _documentService = documentService;
            _mapper = mapper;
            _logger = logger;
        }
        #endregion

        #region Functions
        public async Task<CusResponse<List<GetDocumentListResponse>>> Handle(GetDocumentListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var DocumentList = await _documentService.GetDocumentListAsync();
                var DocumentListMapper = _mapper.Map<List<GetDocumentListResponse>>(DocumentList);

                return Success(DocumentListMapper);

            }
            catch (Exception ex)
            {
                return ServerError<List<GetDocumentListResponse>>(ex.Message);
            }
        }

        public async Task<CusResponse<GetSingleDocumentResponse>> Handle(GetDocumentByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {

                var Document = await _documentService.GetDocumentByIdAsync(request.Id);
                if (Document == null)
                    return NotFound<GetSingleDocumentResponse>("not found this Id.");

                var DocumentMapper = _mapper.Map<GetSingleDocumentResponse>(Document);
                return Success(DocumentMapper);

            }
            catch (Exception ex)
            {
                return ServerError<GetSingleDocumentResponse>(ex.Message);
            }
        }

        public async Task<PaginatedResult<GetDocumentPaginatedResponse>> Handle(GetDocumentPaginatedQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<Document, GetDocumentPaginatedResponse>> expression =
                    entity => new GetDocumentPaginatedResponse(entity.DocumentId,
                    entity.DocumentName, entity.TimeCreated, entity.Details, entity.DocumentType.TypeName,
                    entity.Appointment.Doctor.FirstName + " " + entity.Appointment.Doctor.LastName);

                var filterResult = _documentService.FilterDocumentPaginatedQuerable(request.DoctorName, request.TypeName);
                var paginatedList = await filterResult.Select(expression).ToPaginatedListAsync(request.PageNumber,
                    request.PageSize);

                return paginatedList;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in GetDocumentPaginatedQuery");
                throw;
            }
        }
        #endregion

    }
}
