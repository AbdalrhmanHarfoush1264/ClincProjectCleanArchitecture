using ClincProject.Core.BasesCore;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace ClincProject.Core.Features.DocumentTypes.Commands.Models
{
    public class EditDocumentTypeCommand : IRequest<CusResponse<string>>
    {
        [Required(ErrorMessage = "Id: can't be blank.")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Type Name can't be blank.")]
        public string TypeName { get; set; } = null!;
    }
}
