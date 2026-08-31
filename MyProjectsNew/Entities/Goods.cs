using System.ComponentModel.DataAnnotations;

namespace MyProjectsNew.Entities
{
    public class Goods
    {
        [Key]
        public int Code { get; set; }
        public string Name { get; set; } = string.Empty;

        public string Count { get; set; } = string.Empty;
        public string Price { get; set; } = string.Empty;

    }
}
