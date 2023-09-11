﻿namespace Movie.BL.Model.Gener
{
    public class GenerDTO
    {
        public int Id { get; set; }
        [MaxLength(20, ErrorMessage = "Max Length Is 20 Char")]
        public string Name { get; set; } = string.Empty;
    }
}
