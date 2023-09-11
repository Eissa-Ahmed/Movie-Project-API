namespace Movie.BL.Model.GenerDTO.GenerDTO
{
    public class UpdateGenerDTO
    {
        /*[MaxLength(20, ErrorMessage = "Max Length Is 20 Char")]*/
        [Required(ErrorMessage = "Name Is Required")]
        public string Name { get; set; } = string.Empty;
    }
}
