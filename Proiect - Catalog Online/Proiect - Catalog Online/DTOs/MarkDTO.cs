using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CatalogOnline_ClassLibrary.EntityModels;
using System.Text.Json.Serialization;

namespace Proiect___Catalog_Online.DTOs
{
    /// <summary>
    /// MarkDTO
    /// </summary>
    public class MarkDTO
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// StudentId
        /// </summary>
        public int StudentId { get; set; }

        /// <summary>
        /// SubjectId
        /// </summary>
        public int SubjectId { get; set; }

        /// <summary>
        /// Date
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// MarkDTO
        /// </summary>
        [Range(1, 10, ErrorMessage = "Nota poate fi intre 1 si 10 inclusiv")]
        public int Value { get; set; }

        /// <summary>
        /// Student
        /// </summary>
        [JsonIgnore]
        public virtual StudentDTO? Student { get; set; }

        /// <summary>
        /// Subject
        /// </summary>
        [JsonIgnore]
        public virtual SubjectDTO? Subject { get; set; }


        /// <summary>
        /// MarkDTO
        /// </summary>
        public MarkDTO()
        {

        }

        /// <summary>
        /// MarkDTO
        /// </summary>
        /// <param name="mark">mark</param>
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

        /// <summary>
        /// StudentSubjectDTO - Creat pentru a returna doar datele cerute in utlimul endpoint din partea 3
        /// </summary>
        public class StudentSubjectDTO
        {
            /// <summary>
            /// StudentId
            /// </summary>
            public int StudentId { get; set; }

            /// <summary>
            /// Value
            /// </summary>
            public int Value { get; set; }

            /// <summary>
            /// Date
            /// </summary>
            public DateTime Date { get; set; }

            /// <summary>
            /// StudentSubjectDTO Constructor
            /// </summary>
            /// <param name="mark">Mark</param>
            public StudentSubjectDTO(Mark mark)
            {
                StudentId = mark.StudentId;
                Value = mark.Value;
                Date = mark.Date;
            }
        }
    }
}
