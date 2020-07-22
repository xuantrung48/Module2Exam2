using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Exam2.Models
{
    public class CakeViewModel
    {
        [Required(ErrorMessage = "Nhập vào tên bánh!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Nhập vào thành phần!")]
        public string Ingredient { get; set; }

        [Required(ErrorMessage = "Chọn hạn sử dụng!")]
        public DateTime ExpiryDate { get; set; }
        [Required(ErrorMessage = "Chọn ngày sản xuất!")]
        public DateTime ManufacturingDate { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Nhập sai giá!")]
        [Required(ErrorMessage = "Nhập giá bán!")]
        public int Price { get; set; }
        [Required(ErrorMessage = "Chọn thể loại!")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
