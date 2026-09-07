using System.ComponentModel.DataAnnotations;

namespace MyProjectsNew.Entities
{
    public class GoodsName
    {
        [Key]
        public int Code { get; set; }
        public string Name { get; set; }
        public string CustomerGoodsName { get; set; }
        public string GoodsCount { get; set; } 
        public string GoodsPrice { get; set; } 

    }
}
