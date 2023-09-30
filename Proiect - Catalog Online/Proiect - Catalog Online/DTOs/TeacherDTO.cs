using CatalogOnline_ClassLibrary.EntityModels;

namespace Proiect___Catalog_Online.DTOs
{
    /// <summary>
    /// TeacherDTO
    /// </summary>
    public class TeacherDTO
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Rank
        /// </summary>
        public int Rank { get; set; }

        /// <summary>
        /// Address
        /// </summary>
        public virtual AddressDTO? Address { get; set; }

        /// <summary>
        /// TeacherDTO Constructor
        /// </summary>
        public TeacherDTO()
        {

        }

        /// <summary>
        /// TeacherDTO constructor
        /// </summary>
        /// <param name="teacher">teacher object</param>
        public TeacherDTO(Teacher teacher)
        {
            Id = teacher.Id;
            Name = teacher.Name;
            Rank = teacher.Rank;

            if (teacher.Address != null)
            {
                Address = new AddressDTO(teacher.Address);
            }
        }
    }
}
