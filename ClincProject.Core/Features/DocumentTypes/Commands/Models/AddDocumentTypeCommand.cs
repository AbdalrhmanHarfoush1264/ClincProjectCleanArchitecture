using ClincProject.Core.BasesCore;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace ClincProject.Core.Features.DocumentTypes.Commands.Models
{
    public class AddDocumentTypeCommand : IRequest<CusResponse<string>>
    {
        [Required(ErrorMessage = "Type Name can't be blank.")]
        public string TypeName { get; set; } = null!;
    }
}
