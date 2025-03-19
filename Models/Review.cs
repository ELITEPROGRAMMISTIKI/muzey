using System.ComponentModel.DataAnnotations;

namespace muzey.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string? Name { get; set; }  // делаем nullable
        [Required(ErrorMessage = "Текст отзыва обязателен")]
        public string Text { get; set; }
        public DateTime DateReview { get; set; }
    }
}