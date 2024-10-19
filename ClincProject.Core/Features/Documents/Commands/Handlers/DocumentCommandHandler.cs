using AutoMapper;
using ClincProject.Core.BasesCore;
using ClincProject.Core.Features.Documents.Commands.Models;
using ClincProject.Data.Entities;
using ClincProject.Service.Abstracts;
using MediatR;

namespace ClincProject.Core.Features.Documents.Commands.Handlers
{
    public class DocumentCommandHandler : CusResponseHandler,
        IRequestHandler<AddDocumentCommand, CusResponse<string>>,
        IRequestHandler<EditDocumentCommand, CusResponse<string>>,
        IRequestHandler<DeleteDocumentCommand, CusResponse<string>>
    {
        #region Fileds
        private readonly IDocumentService _documentService;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public DocumentCommandHandler(IDocumentService documentService, IMapper mapper)
        {
            _documentService = documentService;
            _mapper = mapper;
        }

        #endregion

        #region Functions
        public async Task<CusResponse<string>> Handle(AddDocumentCommand request, CancellationToken cancellationToken)
        {
            try
            {

                if (request == null)
                    return BadRequest<string>("request can't be blank.");

                var DocumentMapper = _mapper.Map<Document>(request);
                DocumentMapper.TimeCreated = new DateOnly(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);

                var IsAdded = await _documentService.CreateDocumentAsync(DocumentMapper);
                if (!IsAdded)
                    return BadRequest<string>("Added Operation Failed.");

                return Success("Added Operation Successfully.");
            }
            catch (Exception ex)
            {
                return ServerError<string>(ex.Message);
            }
        }

        public async Task<CusResponse<string>> Handle(EditDocumentCommand request, CancellationToken cancellationToken)
        {
            try
            {

                if (request == null)
                    return BadRequest<string>("request can't be blank.");

                var IsExist = await _documentService.IsDocumentExistByIdAsync(request.Id);
                if (!IsExist)
                    return NotFound<string>("not found this Id.");

                var DocumentMapper = _mapper.Map<Document>(request);
                DocumentMapper.TimeCreated = new DateOnly(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);

                var isEdit = await _documentService.EditDocumentAsync(DocumentMapper);
                if (!isEdit)
                    return BadRequest<string>("Edited Operation Failed.");

                return Success("Edited Operation Successfully.");
            }
            catch (Exception ex)
            {
                return ServerError<string>(ex.Message);
            }
        }

        public async Task<CusResponse<string>> Handle(DeleteDocumentCommand request, CancellationToken cancellationToken)
        {
            try
            {

                if (request == null)
                    return BadRequest<string>("request can't be blank.");

                var IsExist = await _documentService.GetDocumentByIdAsync(request.Id);
                if (IsExist == null)
                    return NotFound<string>("not found this Id.");



                var isDeleted = await _documentService.DeleteDocumentAsync(IsExist);
                if (!isDeleted)
                    return BadRequest<string>("Deleted Operation Failed.");

                return Success("Deleted Operation Successfully.");
            }
            catch (Exception ex)
            {
                return ServerError<string>(ex.Message);
            }
        }
        #endregion

    }
}
