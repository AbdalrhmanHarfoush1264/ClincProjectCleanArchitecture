using AutoMapper;
using ClincProject.Core.BasesCore;
using ClincProject.Core.Features.DocumentTypes.Queriers.Models;
using ClincProject.Core.Features.DocumentTypes.Queriers.Response;
using ClincProject.Core.Features.DocumentTypes.Queriers.Responses;
using ClincProject.Service.Abstracts;
using MediatR;

namespace ClincProject.Core.Features.DocumentTypes.Queriers.Handlers
{
    public class DocumentTypeQueryHandler : CusResponseHandler,
        IRequestHandler<GetDocumentTypeListQuery, CusResponse<List<GetDocumentTypeListResponse>>>,
        IRequestHandler<GetDocumentTypeByIdQuery, CusResponse<GetDocumentTypeByIdResponse>>
    {
        #region Fileds
        private readonly IDocumentTypeService _documentTypeService;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public DocumentTypeQueryHandler(IMapper mapper, IDocumentTypeService documentTypeService)
        {
            _mapper = mapper;
            _documentTypeService = documentTypeService;
        }
        #endregion

        #region Functions
        public async Task<CusResponse<List<GetDocumentTypeListResponse>>> Handle(GetDocumentTypeListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var DocumentTypeList = await _documentTypeService.GetDocumentTypeAsync();
                var DocumentTypeListMapper = _mapper.Map<List<GetDocumentTypeListResponse>>(DocumentTypeList);

                return Success(DocumentTypeListMapper);

            }
            catch (Exception ex)
            {
                return ServerError<List<GetDocumentTypeListResponse>>(ex.Message);
            }
        }

        public async Task<CusResponse<GetDocumentTypeByIdResponse>> Handle(GetDocumentTypeByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var DocumentType = await _documentTypeService.GetDocumentTypeByIdAsync(request.Id);
                if (DocumentType == null)
                    return NotFound<GetDocumentTypeByIdResponse>("DocumentType with this id not found.");

                var DocumentTypeMapper = _mapper.Map<GetDocumentTypeByIdResponse>(DocumentType);

                return Success(DocumentTypeMapper);

            }
            catch (Exception ex)
            {
                return ServerError<GetDocumentTypeByIdResponse>(ex.Message);
            }
        }
        #endregion

    }
}
