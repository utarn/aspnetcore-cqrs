using System.ComponentModel.DataAnnotations;

namespace aspnetcore_cqrs.Mediator.People.Queries.GetPeopleQuery
{
    public class PeopleViewModel
    {
        [Display(Name = "รหัสปชช.")]
        public int PersonId { get; set; }
        [Display(Name = "ชื่อ-นามสกุล")]
        public string FullName { get; set; }
        [Display(Name = "อายุ")]
        public int Age { get; set; }
    }
}