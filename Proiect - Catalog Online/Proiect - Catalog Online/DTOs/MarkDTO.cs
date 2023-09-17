using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CatalogOnline_ClassLibrary.EntityModels;

namespace Proiect___Catalog_Online.DTOs
{
    public class MarkDTO
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        public int SubjectId { get; set; }
        public DateTime Date { get; set; }

        [Range(1, 10, ErrorMessage = "Nota poate fi intre 1 si 10 inclusiv")]
        public int Value { get; set; }

        public virtual StudentDTO? Student { get; set; }
        public virtual SubjectDTO? Subject { get; set; }


        public MarkDTO()
        {

        }

        public MarkDTO(Mark mark)
        {
            Id = mark.Id;
            StudentId = mark.StudentId;
            SubjectId = mark.SubjectId;
            Date = mark.Date;
            Value = mark.Value;

            if (mark.Student != null)
            {
                Student = new StudentDTO(mark.Student);
            }

            if (mark.Subject != null)
            {
                Subject = new SubjectDTO(mark.Subject);
            }
        }
    }
}
